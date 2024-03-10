using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LogosManager;

public class Logic : MonoBehaviour
{
    public static Logic Instance;

    public Image[] icons;
    public GameObject finalKeyPrefab;
    public Image finalWordBar, lettersBar;
    public Image image, imageFinal;
    public Image flag;

    public Text wordFinal, yearsFinal;
    public Text hintText;

    public Transform finalWordParent;

    public Text perfectText;

    public GameObject freePointsMessage;
    public GameObject categoryFinalPanel;

    public FZButton rightIndicator, leftIndicator;

    [Header("Panels")]
    public GameObject nextPanel;
    public GameObject quitPanel;
    public GameObject helpPanel;
    public GameObject rewardPanel;

    [Header("Help")]
    public Button helpButton;
    public Button hintButton;
    public Button revealButton;
    public Button solveButton;

    private readonly string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private readonly string[] ro_chars = { "Ș", "Ț", "Â", "Ă", "Î" };

    private bool isHintShown;
    private bool isLettersRevealed;

    public GameObject groupWrite;

    [HideInInspector]
    public List<Key> Keys = new List<Key>();
    [HideInInspector]
    public List<Key> FinalKeys = new List<Key>();

    public static Key currentFinalKey;
    private List<GameObject> allPanels;

    #region BasicEvents
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        allPanels = new List<GameObject> { nextPanel, quitPanel, helpPanel, rewardPanel };
    }

    private void Start()
    {
        AdsManager.Instance.LoadAd();
        AdsManager.Instance.LoadBannerAd();

        #region Colors
        FZCanvas.Instance.fadeColor = currentCategory.color;
        finalWordBar.color = currentCategory.color;
        foreach (var icon in icons)
        {
            icon.color = currentCategory.color;
        }
        #endregion

        for (int i = 0; i < lettersBar.transform.childCount; i++)
        {
            Keys.Add(lettersBar.transform.GetChild(i).GetComponent<Key>());
        }

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
            key.isCorrect = false;
            key.GetComponent<Button>().interactable = true;
            key.GetComponentInChildren<Text>().text = string.Empty;
            key.gameObject.SetActive(true);
        }
        finalWordBar.GetComponent<Animator>().SetBool("expanded", false);

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
    }

    private void SetWriteGroup()
    {
        helpButton.gameObject.SetActive(true);
        groupWrite.SetActive(true);

        List<string> letters = new List<string>();

        foreach (var letter in currentLogo.name)
        {
            if (!Values.Symbols.Contains(letter.ToString()))
                letters.Add(letter.ToString().ToUpper());
        }

        while (letters.Count < Keys.Count)
        {
            letters.Add(chars.RandomItem());
        }

        letters.Shuffle();

        for (int i = 0; i < Keys.Count; i++)
        {
            Keys[i].value = letters[i];
            Keys[i].RefreshUI();
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
        foreach (var item in allPanels)
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

            Values.Instance.AddToPoints(5);

            perfectText.gameObject.SetActive(true);

            perfectText.text = FZTranslations.GetDynamicText(UnityEngine.Random.Range(0, 2));
        }

        FZSave.Bool.Set($"{currentCategory.name}_{currentLogo.name}_done", true);

        currentLogo.isDone = true;

        wordFinal.text = currentLogo.name;
        imageFinal.sprite = currentLogo.fullImage;

        yearsFinal.text = string.Empty;
        if (currentLogo.startYear > 0)
            yearsFinal.text = currentLogo.startYear.ToString();
        if (currentLogo.endYear > 0)
            yearsFinal.text += "-" + currentLogo.endYear.ToString();


        ShowPanel(nextPanel);

        Values.Instance.AddToTickets(1, true);

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
        AdsManager.Instance.ShowRewardedAd();
    }

    public void ClaimReward()
    {
        HideAllPanels();
        Values.Instance.AddToPoints(25);
    }

    public void SkipBack()
    {
        GetNewLogo_Backward();

        SetLogo();
        ShowPanel(null);
    }

    public void Quit(bool showCategories)
    {
        AdsManager.Instance.DestroyBannerAd();
        Menu.showCategories = showCategories;
        FZCanvas.Instance.FadeLoadScene(0, Values.Instance.accentColor);
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
        foreach (var key in FinalKeys)
        {
            key.value = string.Empty;
            key.RefreshUI();
        }
        Key.SelectKey(FinalKeys[0]);

        foreach (var key in Keys)
        {
            key.GetComponent<FZButton>().interactable = true;
        }

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

        ClearFinalKeys();

        for (int i = 0; i < FinalKeys.Count / 2; i++)
        {
            var fkey = FinalKeys.RandomItem();
            while (fkey.isCorrect)
            {
                fkey = FinalKeys.RandomItem();
            }
            foreach (var key in Keys)
            {
                if (key.value == fkey.neededValue)
                {
                    currentFinalKey = fkey;
                    Key.SelectKey(key);
                }
            }
        }
        HideAllPanels();

        Key.GetNextFinalKey(true);
    }
    #endregion
}

