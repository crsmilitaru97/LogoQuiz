using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LogosManager;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public Button[] dailyRewardButtons;
    public Button dailyRewardButton;
    public Text dailyRewardDayText;

    [Header("Design")]
    public Color iconsColor;
    public Image[] icons;
    public Image[] tops;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject catPanel;
    public GameObject statsPanel;
    public GameObject settingsPanel;
    public GameObject dailyRewardPanel;

    [Header("Categories")]
    public Text categoriesTicketsText;
    public ScrollRect categoryScroll;
    public RectTransform categoryContent;

    [Header("Settings")]
    public Text versionText;

    [Header("Stats")]
    public Text wordsDoneText;
    public Text categoriesCompletedText;
    public Text pressedKeysText;
    public Text deletedLettersText;
    public Text hintsUsedText;
    public Image fillWordsDone, fillCategoriesDone;
    public Text procentWordsDone, procentCategoriesDone;
    public Transform statsGroup;

    private int rewardDayIndex;
    private List<GameObject> allPanels;

    public static bool showCategories = false;
    public static Transform lastClickedLevel;
    public static int categoryScrollIndex;

    public GameObject categoryPrefab;
    readonly int[] rewardValues = { 15, 25, 3, 50, 75 };

    #region BasicEvents
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        Application.targetFrameRate = 60;

        allPanels = new List<GameObject> { mainPanel, catPanel, statsPanel, settingsPanel };

        foreach (var category in LogosManager.Manager.Categories)
        {
            var catobj = Instantiate(categoryPrefab, categoryContent).GetComponent<CategoryUI>();
            catobj.currentCategory = category;
            catobj.Refresh();
        }

        #region Set Colors
        foreach (var icon in icons)
            icon.color = iconsColor;

        versionText.color = iconsColor;

        foreach (var icon in tops)
            icon.color = iconsColor;

        foreach (var dailyReward in dailyRewardButtons)
        {
            dailyReward.GetComponent<Image>().color = iconsColor;
        }
        #endregion

        #region Save Scroll
        //int lastScrollIndex = PlayerPrefs.GetInt("categoryScrollIndex", 0);
        int lastScrollIndex = categoryScrollIndex;
        if (lastScrollIndex > 0)
            lastScrollIndex--;
        lastClickedLevel = categoryContent.GetChild(lastScrollIndex);



        //categoryScroll.verticalNormalizedPosition= PlayerPrefs.GetFloat("CategoryScrollIndex");

        Canvas.ForceUpdateCanvases();

        categoryContent.anchoredPosition =
            (Vector2)categoryScroll.transform.InverseTransformPoint(categoryContent.position)
            - (Vector2)categoryScroll.transform.InverseTransformPoint(lastClickedLevel.position);

        categoryContent.anchoredPosition = new Vector2(0, categoryContent.anchoredPosition.y);

        if (lastScrollIndex < 1)
        {
            categoryContent.anchoredPosition = new Vector2(0, 0);
        }
        #endregion

        #region Daily Reward Check
        dailyRewardButton.interactable = false;

        DateTime rewardDate = FZSave.TimeDate.Get("nextRewardDate");
        if (rewardDate.Date == DateTime.Now.Date)
        {
            dailyRewardButton.interactable = true;
            if (!showCategories)
                ShowDailyReward();
        }
        else if (rewardDate.Date != DateTime.Now.Date.AddDays(1))
        {
            PlayerPrefs.SetInt("todayRewardIndex", 0);
            FZSave.TimeDate.Set("nextRewardDate", DateTime.Now.Date);

            dailyRewardButton.interactable = true;
            if (!showCategories)
                ShowDailyReward();
        }
        #endregion

        Values.UpdateTextWithValue(categoriesTicketsText, Values.tickets);

        if (showCategories)
            ShowPanel(catPanel);

        #region Stats and saves
        // Words done & categories completed
        int wordsDone = 0, wordsTotal = 0, completedCategories = 0;
        foreach (Category category in LogosManager.Manager.Categories)
        {
            wordsTotal += category.Logos.Length;
            int thisCategoryWordsDone = 0;
            foreach (Logo logo in category.Logos)
            {
                if (FZSave.Bool.Get($"{category.name}_{logo.name}_done", false))
                {
                    logo.isDone = true;
                    thisCategoryWordsDone++;
                }
                else
                    logo.isDone = false;
            }
            if (thisCategoryWordsDone == category.Logos.Length)
            {
                category.completed = true;
                completedCategories++;
            }

            wordsDone += thisCategoryWordsDone;
            category.wordsDoneCount = thisCategoryWordsDone;
        }
        wordsDoneText.text = wordsDone.ToString() + "/" + wordsTotal.ToString();
        categoriesCompletedText.text = completedCategories.ToString() + "/" + LogosManager.Manager.Categories.Length.ToString();
        fillWordsDone.fillAmount = (float)wordsDone / wordsTotal;
        procentWordsDone.text = (Mathf.Round((float)wordsDone / wordsTotal * 100)).ToString() + "%";
        fillCategoriesDone.fillAmount = (float)completedCategories / LogosManager.Manager.Categories.Length;
        procentCategoriesDone.text = (Mathf.Round((float)completedCategories / LogosManager.Manager.Categories.Length * 100)).ToString() + "%";

        // More
        pressedKeysText.text = Values.pressedKeys.ToString();
        deletedLettersText.text = Values.deletedLetters.ToString();
        hintsUsedText.text = Values.helpUsed.ToString();
        #endregion
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mainPanel.activeSelf)
                ShowPanel(mainPanel);
        }
    }
    #endregion

    public void ShowDailyReward()
    {
        rewardDayIndex = PlayerPrefs.GetInt("todayRewardIndex", 0);
        dailyRewardDayText.text = (rewardDayIndex + 1).ToString();
        dailyRewardButtons[rewardDayIndex].interactable = true;
        dailyRewardButtons[rewardDayIndex].transform.GetChild(1).GetComponent<Image>().color = Color.white;

        dailyRewardPanel.SetActive(true);
    }

    public void GetDailyReward()
    {
        FZSave.TimeDate.Set("nextRewardDate", DateTime.Now.Date.AddDays(1));
        dailyRewardButton.interactable = false;

        if (rewardDayIndex != 2)
            Values.Instance.AddToPoints(rewardValues[rewardDayIndex]);
        else
            Values.Instance.AddToTickets(rewardValues[rewardDayIndex]);

        if (rewardDayIndex < 4)
            rewardDayIndex += 1;
        else
            rewardDayIndex = 0;

        PlayerPrefs.SetInt("todayRewardIndex", rewardDayIndex);

        dailyRewardPanel.SetActive(false);
    }

    public void ShowPanel(GameObject newPanel)
    {
        foreach (var oldPanel in allPanels)
        {
            oldPanel.SetActive(false);
        }
        newPanel.SetActive(true);

        if (newPanel == catPanel)
            StartCoroutine(WaitTillNextCategory());

        if (newPanel == statsPanel)
            StartCoroutine(WaitTillNextStat());

    }

    #region IEnumerators
    private IEnumerator WaitTillNextCategory()
    {
        for (int i = 0; i < categoryContent.childCount; i++)
        {
            categoryContent.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < categoryContent.childCount; i++)
        {
            categoryContent.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.025f);
        }
    }

    private IEnumerator WaitTillNextStat()
    {
        for (int i = 0; i < statsGroup.childCount; i++)
        {
            statsGroup.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < statsGroup.childCount; i++)
        {
            statsGroup.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.025f);
        }
    }
    #endregion
}