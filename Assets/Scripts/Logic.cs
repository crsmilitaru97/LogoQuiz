using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LogosManager;

public class Logic : MonoBehaviour
{
    public static Logic Instance;
    public GameObject finalKeyPrefab;

    public GameObject[] panels;
    public Image[] icons, specialButtons;
    public Image finalWordBar, lettersBar;
    public Image image, imageFinal;
    public Image flag;

    public Text wordFinal, yearsFinal;
    public Text hintText;

    public Transform finalWordParent;
    public GameObject nextPanel;
    public GameObject quitPanel;
    public GameObject helpPanel;
    public GameObject rewardConfirmMessage;

    public Text perfectText;

    public GameObject freePointsMessage;
    public GameObject categoryFinalPanel;

    public FZButton rightIndicator, leftIndicator;

    [Header("Help")]
    public Button helpButton;
    public Button hintButton;
    public Button revealButton;
    public Button solveButton;

    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZȘȚÂĂÎ";
    private int currentIndexInWord;

    private bool isHintShown;
    private bool isLettersRevealed;

    public GameObject groupWrite;

    [HideInInspector]
    public List<Key> Keys = new List<Key>();
    [HideInInspector]
    public List<Key> FinalKeys = new List<Key>();

    public static Key currentFinalKey;

    #region BasicEvents
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        AdsManager.Instance.LoadAd();

        #region Colors
        finalWordBar.color = currentCategory.color;
        lettersBar.color = currentCategory.color;
        foreach (var icon in icons)
        {
            icon.color = currentCategory.color;
        }
        foreach (var icon in specialButtons)
        {
            icon.color = currentCategory.color;
        }
        Color.RGBToHSV(currentCategory.color, out float h, out float s, out float v);
        s /= 3;


        #endregion

        for (int i = 0; i < lettersBar.transform.childCount; i++)
        {
            Keys.Add(lettersBar.transform.GetChild(i).GetComponent<Key>());
        }

        //for (int i = 0; i < finalWordParent.transform.childCount; i++)
        //{
        //    finalKeys.Add(finalWordParent.transform.GetChild(i).GetComponent<Key>());
        //    //var newColor = finalWordParent.transform.GetChild(i).GetComponent<Button>().colors;
        //    //newColor.disabledColor = Color.HSVToRGB(h, s, v);
        //    //finalWordParent.transform.GetChild(i).GetComponent<Button>().colors = newColor;

        //    FZColors.ChangeButtonColors(finalWordParent.transform.GetChild(i).GetComponent<Button>(), Color.white, currentCategory.color);
        //}


        SetLogo();
        CheckPoints();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPanel(quitPanel);
        }
    }
    #endregion

    private Logo GetNewLogo_Forward()
    {
        // x -> final
        for (int i = currentLogo.ID + 1; i < currentCategory.Logos.Length; i++)
        {
            if (currentCategory.Logos[i].isDone == false)
            {
                currentLogo = currentCategory.Logos[i];
                return currentLogo;
            }
        }

        // @ 0 -> x
        for (int i = 0; i < currentLogo.ID; i++)
        {
            if (currentCategory.Logos[i].isDone == false)
            {
                currentLogo = currentCategory.Logos[i];
                return currentLogo;
            }
        }

        return null;
    }

    private Logo GetNewLogo_Backward()
    {
        // x -> 0
        for (int i = currentLogo.ID - 1; i >= 0; i--)
        {
            if (currentCategory.Logos[i].isDone == false)
            {
                currentLogo = currentCategory.Logos[i];
                return currentLogo;
            }
        }

        return null;
    }

    private void CategoryFullyDone()
    {
        ShowPanel(categoryFinalPanel);
        imageFinal.gameObject.ReEnable();
    }

    private void CleanAfterLogo()
    {
        hintText.transform.parent.gameObject.SetActive(false);

        foreach (var key in Keys)
        {
            key.value = string.Empty;
            key.GetComponent<Button>().interactable = true;
            key.GetComponentInChildren<Text>().text = string.Empty;
            key.gameObject.SetActive(true);
        }

        foreach (var key in FinalKeys)
        {
            Destroy(key.gameObject);
        }
        FinalKeys.Clear();
    }

    private void SetLogo()
    {
        CleanAfterLogo();
        int ix = 0;
        foreach (var letter in currentLogo.name)
        {
            var key = Instantiate(finalKeyPrefab, finalWordParent).GetComponent<Key>();
            key.neededValue = letter.ToString().ToUpperInvariant();
            key.ID = ix;
            ix++;
            key.RefreshUI();

            FinalKeys.Add(key);
        }

        currentFinalKey = FinalKeys[0];
        currentFinalKey.Highlight();


        isHintShown = false;
        isLettersRevealed = false;
        CheckPoints();

        bool isFirstWord = true;
        for (int i = 0; i < currentLogo.ID; i++)
        {
            if (!currentCategory.Logos[i].isDone)
            {
                isFirstWord = false;
                break;
            }
        }
        leftIndicator.interactable = !isFirstWord;
        rightIndicator.interactable = true;

        perfectText.gameObject.SetActive(false);

        image.gameObject.SetActive(false);
        image.gameObject.SetActive(true);

        nextPanel.SetActive(false);

        image.sprite = currentLogo.partImage;

        SetWriteGroup();

        try
        {
            flag.gameObject.SetActive(true);
            flag.sprite = Resources.Load<Sprite>($"Flags/{currentLogo.country.ToString().ToLowerInvariant()}");
        }
        catch (Exception)
        {
            flag.gameObject.SetActive(false);
        }

        hintButton.gameObject.SetActive(!string.IsNullOrEmpty(currentLogo.hint));
        revealButton.gameObject.SetActive(!currentLogo.isGuess);
    }

    private void SetWriteGroup()
    {
        helpButton.gameObject.SetActive(true);
        groupWrite.SetActive(true);

        finalWordBar.gameObject.SetActive(false);
        finalWordBar.gameObject.SetActive(true);

        List<string> letters = new List<string>();
        foreach (var letter in currentLogo.name)
        {
            if (!Values.Symbols.Contains(letter.ToString()))
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

        //for (int i = 0; i < finalKeys.Count; i++)
        //{
        //    if (i < currentLogo.name.Length)
        //    {
        //        finalKeys[i].isSymbol = (symbols.Contains(currentLogo.name[i].ToString()));

        //        if (finalKeys[i].isSymbol)
        //            finalKeys[i].value = currentLogo.name[i].ToString();

        //        finalKeys[i].RenderValue();
        //    }
        //    else
        //        finalKeys[i].gameObject.SetActive(false);
        //}

        //HighlightKey(0);

        letters.Sort();

        for (int i = 0; i < Keys.Count; i++)
        {
            Keys[i].value = letters[i].ToString().ToUpper();
            Keys[i].GetComponentInChildren<Text>().text = Keys[i].value;
        }
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

    public void SolveWord(bool rewarded)
    {
        if (rewarded)
        {
            FZAudio.Manager.PlaySound(Sounds.Instance.correct);

            if (Settings.vibrationEnabled)
                Handheld.Vibrate();

            if (currentLogo.isGuess)
                Values.Instance.AddToPoints(10);
            else
                Values.Instance.AddToPoints(5);

            perfectText.gameObject.SetActive(true);
            perfectText.text = Texts.perfects.RandomItem();
        }

        FZSave.Bool.Set($"{currentCategory.name}_{currentLogo.name}_done", true);

        currentLogo.isDone = true;

        currentIndexInWord = 0;

        wordFinal.text = currentLogo.name;
        imageFinal.sprite = Resources.Load<Sprite>($"LogosFull/{currentCategory.name}/{currentLogo.name}");

        yearsFinal.text = string.Empty;
        if (currentLogo.startYear > 0)
            yearsFinal.text = currentLogo.startYear.ToString();
        if (currentLogo.endYear > 0)
            yearsFinal.text += "-" + currentLogo.endYear.ToString();


        ShowPanel(nextPanel);
        if (currentLogo.isGuess && currentLogo.guessed || !currentLogo.isGuess)
        {
            Values.Instance.AddToTickets(1);
        }
        AdsManager.Instance.ShowAd();
    }

    public void NextLogo()
    {
        AdsManager.Instance.LoadAdIfCase();

        ShowPanel(null);

        GetNewLogo_Forward();

        SetLogo();
    }

    public void Skip()
    {
        GetNewLogo_Forward();

        SetLogo();
        ShowPanel(null);
    }

    public void GetReward()
    {
    }

    public void ClaimReward(GameObject rewardPanel)
    {
    }

    public void SkipBack()
    {
        GetNewLogo_Backward();

        SetLogo();
        ShowPanel(null);
    }

    public void Quit(bool showCategories)
    {
        SceneManager.LoadScene(0);
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

    public void ClearFinalKeys()
    {
        finalWordBar.GetComponent<Animator>().SetBool("expanded", false);
    }

    #region Help
    public void UseHelp(int cost)
    {
        Values.Instance.AddToPoints(-cost);

        PlayerPrefs.SetInt("hintsUsed", ++Values.helpUsed);
    }

    public void ShowHint()
    {
        isHintShown = true;
        hintButton.interactable = false;
        hintText.transform.parent.gameObject.SetActive(true);
        hintText.text = currentLogo.hint;

        HideAllPanels();
    }

    public void Reveal()
    {
        isLettersRevealed = true;
        revealButton.interactable = false;
        bool[] posRevealed = new bool[currentLogo.name.Length];

        ClearFinalKeys();
        int i = Mathf.RoundToInt((float)currentLogo.name.Length / 3f);
        foreach (var key in Keys)
        {
            if (i > 0)
            {
                if (currentLogo.name.ToUpperInvariant().Contains(key.value.ToUpperInvariant()))
                {
                    currentIndexInWord = currentLogo.name.ToUpperInvariant().IndexOf(key.value.ToUpperInvariant());
                    if (!posRevealed[currentIndexInWord])
                    {
                        posRevealed[currentIndexInWord] = true;
                        //Change(key);
                        i--;
                    }
                }
            }
        }
        currentIndexInWord = 0;
        //while (finalKeys[currentIndexInWord].value != string.Empty)
        // currentIndexInWord++;

        HideAllPanels();
    }
    #endregion
}

