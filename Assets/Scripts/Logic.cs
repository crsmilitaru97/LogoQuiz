using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public static Logic instance;

    public GameObject[] panels;
    public Image[] icons, specialButtons;
    public AudioSource asFinish, asNo;
    public Image finalWordBar, lettersBar;
    public Image image, imageFinal;
    public Image flag;
    public Text[] specialTexts;

    public Text wordFinal, aboutFinal, yearsFinal;
    public Text hintText;
    public Text pointsTotalText;
    public Text ticketsTotalText;

    public GameObject finalWordParent;
    public GameObject nextPanel;
    public GameObject quitPanel;
    public GameObject helpPanel;
    public GameObject rewardConfirmMessage;

    public GameObject bonusLevelText;
    public Text perfectText;

    public GameObject freePointsMessage;
    public GameObject categoryFinalPanel;

    public Image rightIndicator, leftIndicator;

    [Header("Help")]
    public Button helpButton;
    public Button hintButton;
    public Button revealButton;
    public Button solveButton;

    private readonly List<Key> keys = new List<Key>();
    private readonly List<Key> finalKeys = new List<Key>();

    public static Word[] currentWords;
    public static Word currentWord;
    public static Category currentCategory;
    public static Key currentFinalKey;

    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZȘȚÂĂÎ";
    private static readonly Vector2 keySize = new Vector2(96, 96);
    private Vector2 keyZoomSize = new Vector2(keySize.x + 20, keySize.y + 20);
    private int currentIndexInWord;
    private const int adStepToPlay = 3;

    private bool isHintShown;
    private bool isLettersRevealed;

    public GameObject groupGuess, groupWrite;

    private InterstitialAd finishWordAd;
    private RewardedAd getPointsAd;

    #region BasicEvents
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        InitializeRewardedAd();
        ticketsTotalText.text = Values.tickets.ToString();
        SelectCategory();

        Color.RGBToHSV(currentCategory.darkColor, out float h, out float s, out float v);
        s /= 3;

        for (int i = 0; i < lettersBar.transform.childCount; i++)
        {
            keys.Add(lettersBar.transform.GetChild(i).GetComponent<Key>());
        }
        for (int i = 0; i < finalWordParent.transform.childCount; i++)
        {
            finalKeys.Add(finalWordParent.transform.GetChild(i).GetComponent<Key>());
            //var newColor = finalWordParent.transform.GetChild(i).GetComponent<Button>().colors;
            //newColor.disabledColor = Color.HSVToRGB(h, s, v);
            //finalWordParent.transform.GetChild(i).GetComponent<Button>().colors = newColor;

            FZColors.ChangeButtonColors(finalWordParent.transform.GetChild(i).GetComponent<Button>(), Color.white, currentCategory.normalColor);
        }

        Values.UpdateTextWithValue(pointsTotalText, Values.points);

        groupGuess.GetComponent<Image>().color = currentCategory.normalColor;

        LoadNewWord();
        CheckPoints();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ShowPanel(quitPanel);
    }
    #endregion

    private void TryGetNewWordIndex_Forward(int currentIndex)
    {
        // x -> final
        for (int i = currentIndex + 1; i < currentCategory.words.Length; i++)
        {
            if (currentCategory.words[i].isDone == false)
            {
                Values.currentWordIndex = i;
                return;
            }
        }

        // @ 0 -> x
        for (int i = 0; i < currentIndex; i++)
        {
            if (currentCategory.words[i].isDone == false)
            {
                Values.currentWordIndex = i;
                return;
            }
        }

        CategoryFullyDone();
    }

    private void TryGetNewWordIndex_Backward(int currentIndex)
    {
        // x -> 0
        for (int i = currentIndex - 1; i >= 0; i--)
        {
            if (currentCategory.words[i].isDone == false)
            {
                Values.currentWordIndex = i;
                return;
            }
        }
    }

    private void CategoryFullyDone()
    {
        ShowPanel(categoryFinalPanel);

        imageFinal.gameObject.SetActive(false);
        imageFinal.gameObject.SetActive(true);
    }

    private void SetWord()
    {
        isHintShown = false;
        isLettersRevealed = false;
        CheckPoints();

        bool isFirstWord = true;
        for (int i = 0; i < Values.currentWordIndex; i++)
        {
            if (!currentCategory.words[i].isDone)
            {
                isFirstWord = false;
                break;
            }
        }
        if (!currentWord.isGuess)
            leftIndicator.gameObject.SetActive(!isFirstWord);
        else
        {
            rightIndicator.gameObject.SetActive(false);
            leftIndicator.gameObject.SetActive(false);
        }

        perfectText.gameObject.SetActive(false);

        image.gameObject.SetActive(false);
        image.gameObject.SetActive(true);

        nextPanel.SetActive(false);

        Refresh();

        image.sprite = Resources.Load<Sprite>($"Logos/{currentCategory.categoryName}/{currentWord.wordText.ToLowerInvariant()}");

        if (currentWord.isGuess)
        {
            groupWrite.SetActive(false);
            SetGuessGroup();
        }
        else
        {
            groupGuess.SetActive(false);
            SetWriteGroup();
        }

        try
        {
            flag.gameObject.SetActive(true);
            flag.sprite = Resources.Load<Sprite>($"Flags/{currentWord.country.ToLowerInvariant()}");
        }
        catch (Exception)
        {
            flag.gameObject.SetActive(false);
        }

        hintButton.gameObject.SetActive(!string.IsNullOrEmpty(currentWord.hint));
        revealButton.gameObject.SetActive(!currentWord.isGuess);
    }

    private void SetGuessGroup()
    {
        bonusLevelText.SetActive(true);
        helpButton.gameObject.SetActive(false);
        groupGuess.SetActive(true);

        for (int i = 0; i < groupGuess.transform.childCount; i++)
        {
            var guessObj = groupGuess.transform.GetChild(i).gameObject;
            List<string> variants = currentWord.variants;
            variants.Add(currentWord.wordText);

            if (i < variants.Count)
            {
                guessObj.GetComponent<Guess>().value = variants[i];
                guessObj.SetActive(true);
                guessObj.GetComponent<Guess>().RenderValue();
            }
            else
            {
                guessObj.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void SetWriteGroup()
    {
        bonusLevelText.SetActive(false);
        helpButton.gameObject.SetActive(true);
        groupWrite.SetActive(true);

        finalWordBar.gameObject.SetActive(false);
        finalWordBar.gameObject.SetActive(true);

        var pos = finalWordParent.GetComponent<RectTransform>();
        pos.localPosition = new Vector2((finalKeys.Count - currentWord.wordText.Length) * (75 / 2), pos.localPosition.y);

        List<string> symbols = new List<string> { "!", "'", "-", ".", " " };

        List<string> letters = new List<string>();
        foreach (var letter in currentWord.wordText)
        {
            if (!symbols.Contains(letter.ToString()))
                letters.Add(letter.ToString());
        }
        List<char> choosedChars = new List<char>();
        for (int i = letters.Count + 1; i < 15; i++)
        {
            char randChar;
            do
                randChar = chars[UnityEngine.Random.Range(0, chars.Length)];
            while (choosedChars.Contains(randChar));

            choosedChars.Add(randChar);
            letters.Add(randChar.ToString());
        }
        choosedChars.Clear();

        for (int i = 0; i < finalKeys.Count; i++)
        {
            if (i < currentWord.wordText.Length)
            {
                finalKeys[i].isSymbol = (symbols.Contains(currentWord.wordText[i].ToString()));

                if (finalKeys[i].isSymbol)
                    finalKeys[i].value = currentWord.wordText[i].ToString();

                finalKeys[i].RenderValue();
            }
            else
                finalKeys[i].gameObject.SetActive(false);
        }

        HighlightKey(0);

        letters.Sort();

        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].value = letters[i].ToString().ToUpper();
            keys[i].GetComponentInChildren<Text>().text = keys[i].value;
        }
    }

    public void LoadNewWord()
    {
        currentWord = currentWords[Values.currentWordIndex];
        SetWord();
    }

    public Word TryGetBonusWord()
    {
        foreach (var item in currentCategory.bonusWords)
        {
            if (item.isDone == false)
                return item;
        }
        return null;
    }
    public void GetRewardOK()
    {
    }

    public void ShowPanel(GameObject panel)
    {
        HideAllPanels();

        if (panel != null)
            panel.SetActive(true);

        if (panel == helpPanel)
            freePointsMessage.SetActive(true);
    }

    public void HideAllPanels()
    {
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
        if (Values.points > 50)
            freePointsMessage.SetActive(false);
    }

    public void Refresh()
    {
        hintText.text = string.Empty;

        foreach (var key in keys)
        {
            key.value = string.Empty;
            key.GetComponent<Button>().interactable = true;
            key.GetComponentInChildren<Text>().text = string.Empty;
            key.gameObject.SetActive(true);
        }
        foreach (var key in finalKeys)
        {
            key.GetComponent<Image>().enabled = true;
            key.isSymbol = false;
            key.value = string.Empty;
            key.GetComponent<Button>().interactable = false;
            key.GetComponentInChildren<Text>().text = string.Empty;
            key.gameObject.SetActive(true);
        }
    }
    string[] perfects = { "Felicitări!", "Bravo!", "Perfect!", "Extraordinar!" };
    public void SolveWord(bool rewarded)
    {
        if (rewarded)
        {
            if (Settings.audioEnabled)
                asFinish.Play();

            if (Settings.vibrationEnabled)
                Handheld.Vibrate();

            if (currentWord.isGuess)
                AddToPoints(10);
            else
                AddToPoints(5);

            perfectText.gameObject.SetActive(true);
            perfectText.text = perfects[UnityEngine.Random.Range(0, perfects.Length)];
        }

        FZSave.Bool.Set($"{currentCategory.categoryName}_{currentWord.wordText}_done", true);

        currentWord.isDone = true;

        currentIndexInWord = 0;

        wordFinal.text = currentWord.wordText;
        imageFinal.sprite = Resources.Load<Sprite>($"LogosFull/{currentCategory.categoryName}/{currentWord.wordText}");
        if (!string.IsNullOrEmpty(currentWord.about))
            aboutFinal.text = currentWord.about;
        else
            aboutFinal.text = string.Empty;

        yearsFinal.text = string.Empty;
        if (currentWord.startYear > 0)
            yearsFinal.text = currentWord.startYear.ToString();
        if (currentWord.endYear > 0)
            yearsFinal.text += "-" + currentWord.endYear.ToString();


        ShowPanel(nextPanel);
        if (currentWord.isGuess && currentWord.guessed || !currentWord.isGuess)
        {
            AddToTickets(1);
        }

        if (AdsManager.adStep % adStepToPlay == 0)
        {
            AdsManager.ShowInterstitial(finishWordAd);
            finishWordAd.OnAdClosed += HandleOnAdClosed;
        }
    }

    public void NextWord()
    {
        AdsManager.adStep++;
        Debug.Log("Ad step: " + AdsManager.adStep);

        if (AdsManager.adStep % adStepToPlay == 0)
        {
            finishWordAd = new InterstitialAd("");
            finishWordAd = AdsManager.LoadInterstitial();
        }

        ShowPanel(null);

        if (UnityEngine.Random.value < 0.1f) //Bonus word
        {
            if (TryGetBonusWord() != null)
            {
                currentWord = TryGetBonusWord();
                SetWord();
                return;
            }
            else TryGetNewWordIndex_Forward(Values.currentWordIndex);

        }
        else
            TryGetNewWordIndex_Forward(Values.currentWordIndex);

        LoadNewWord();
    }

    public void Skip()
    {
        TryGetNewWordIndex_Forward(Values.currentWordIndex);

        LoadNewWord();
        ShowPanel(null);
    }

    public void SkipBack()
    {
        TryGetNewWordIndex_Backward(Values.currentWordIndex);

        LoadNewWord();
        ShowPanel(null);
    }

    public void SelectCategory()
    {
        currentCategory = WordsDB.categoriesRO[Values.currentCategoryIndex];

        finalWordBar.color = currentCategory.darkColor;
        lettersBar.color = currentCategory.normalColor;

        // Colors
        foreach (var icon in icons)
        {
            icon.color = currentCategory.darkColor;
        }
        foreach (var icon in specialButtons)
        {
            icon.color = currentCategory.normalColor;
        }
        foreach (var text in specialTexts)
        {
            text.color = currentCategory.darkColor;
        }

        currentWords = currentCategory.words;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void AddToPoints(int value)
    {
        Values.points += value;
        pointsTotalText.GetComponentInChildren<FZText>().SlowlyUpdateNumberText(Values.points);
        PlayerPrefs.SetInt("points", Values.points);

        CheckPoints();
    }

    private void AddToTickets(int value)
    {
        Values.tickets++;
        ticketsTotalText.GetComponent<FZText>().SlowlyUpdateNumberText(Values.tickets);
        PlayerPrefs.SetInt("tickets", Values.tickets);

        //CheckTickets();
    }

    private void CheckPoints()
    {
        if (Values.points < 50)
            freePointsMessage.SetActive(true);
        else
            freePointsMessage.SetActive(false);

        if (!isHintShown)
            hintButton.interactable = (Values.points >= 25);
        if (!isLettersRevealed)
            revealButton.interactable = (Values.points >= 50);
        solveButton.interactable = (Values.points >= 100);
    }

    public void OnKeyPress(Key pressedKey)
    {
        if (Settings.audioEnabled)
            lettersBar.GetComponent<AudioSource>().Play();

        if (currentIndexInWord < currentWord.wordText.Length)
        {
            finalWordBar.GetComponent<Animator>().SetBool("expanded", false);

            PlayerPrefs.SetInt("pressedKeys", ++Values.pressedKeys);

            Change(pressedKey);

            if (currentIndexInWord + 1 < finalKeys.Count)
            {
                while (finalKeys[currentIndexInWord].value != string.Empty || finalKeys[currentIndexInWord].isSymbol)
                    currentIndexInWord++;
            }
            else
                currentIndexInWord++;

            if (currentIndexInWord == currentWord.wordText.Length)
            {
                string word = string.Empty;
                foreach (var item in finalKeys)
                {
                    word += item.value;
                }
                if (word.ToUpperInvariant() == currentWord.wordText.ToUpperInvariant())
                    SolveWord(true);
                else
                {
                    finalWordBar.GetComponent<Animator>().SetBool("expanded", true);
                    if (Settings.audioEnabled)
                        asNo.Play();
                }
            }
            else
            {
                HighlightKey(currentIndexInWord);
            }
        }
    }

    private void HighlightKey(int index)
    {
        finalKeys[index].GetComponent<RectTransform>().sizeDelta = keyZoomSize;
        finalKeys[index].transform.SetAsLastSibling();
    }

    private void Change(Key pressedKey)
    {
        currentFinalKey = finalKeys[currentIndexInWord];
        currentFinalKey.fromKey = pressedKey;

        currentFinalKey.value = pressedKey.value;
        currentFinalKey.GetComponentInChildren<Text>().text = pressedKey.value;

        currentFinalKey.GetComponent<Button>().interactable = true;
        pressedKey.GetComponent<Button>().interactable = false;

        currentFinalKey.GetComponent<RectTransform>().sizeDelta = keySize;
    }

    public void ChangeLetterInWord(Key keyToChange)
    {
        if (Settings.audioEnabled)
            finalWordBar.GetComponent<AudioSource>().Play();

        finalWordBar.GetComponent<Animator>().SetBool("expanded", false);

        if (currentIndexInWord > keyToChange.index)
        {
            currentIndexInWord = keyToChange.index;
            currentFinalKey = finalKeys[currentIndexInWord];
        }

        keyToChange.fromKey.GetComponent<Button>().interactable = true;
        keyToChange.value = string.Empty;
        keyToChange.GetComponentInChildren<Text>().text = string.Empty;
        keyToChange.GetComponent<Button>().interactable = false;

        foreach (var item in finalKeys)
        {
            item.GetComponent<RectTransform>().sizeDelta = keySize;
        }
        HighlightKey(currentIndexInWord);

        PlayerPrefs.SetInt("deletedLetters", ++Values.deletedLetters);
    }

    public void ClearFinalKeys()
    {
        finalWordBar.GetComponent<Animator>().SetBool("expanded", false);

        foreach (var key in finalKeys)
        {
            if (key.fromKey != null)
                key.fromKey.GetComponent<Button>().interactable = true;
            key.value = string.Empty;
            key.GetComponentInChildren<Text>().text = string.Empty;
            key.GetComponent<Button>().interactable = false;
        }

        currentIndexInWord = 0;
        HighlightKey(currentIndexInWord);
    }

    #region Help
    public void UseHelp(int cost)
    {
        AddToPoints(-cost);

        PlayerPrefs.SetInt("hintsUsed", ++Values.helpUsed);
    }

    public void ShowHint()
    {
        isHintShown = true;
        hintButton.interactable = false;
        hintText.text = currentWord.hint;

        HideAllPanels();
    }

    public void Reveal()
    {
        isLettersRevealed = true;
        revealButton.interactable = false;
        bool[] posRevealed = new bool[currentWord.wordText.Length];

        ClearFinalKeys();
        int i = Mathf.RoundToInt((float)currentWord.wordText.Length / 3f);
        foreach (var key in keys)
        {
            if (i > 0)
            {
                if (currentWord.wordText.ToUpperInvariant().Contains(key.value.ToUpperInvariant()))
                {
                    currentIndexInWord = currentWord.wordText.ToUpperInvariant().IndexOf(key.value.ToUpperInvariant());
                    if (!posRevealed[currentIndexInWord])
                    {
                        posRevealed[currentIndexInWord] = true;
                        Change(key);
                        i--;
                    }
                }
            }
        }
        currentIndexInWord = 0;
        while (finalKeys[currentIndexInWord].value != string.Empty)
            currentIndexInWord++;

        HideAllPanels();
    }
    #endregion

    public void GetFreePoints()
    {
        getPointsAd.Show();
        getPointsAd.OnUserEarnedReward += HandleUserEarnedReward;
        getPointsAd.OnAdClosed += HandleRewardedAdClosed;
    }

    #region Ads events
    void InitializeRewardedAd()
    {
        getPointsAd = new RewardedAd(AdsManager.rewarded_getPoints_id);
        getPointsAd.LoadAd(new AdRequest.Builder().Build());
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        finishWordAd.Destroy();
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        AddToPoints(25);
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        InitializeRewardedAd();
    }
    #endregion
}

