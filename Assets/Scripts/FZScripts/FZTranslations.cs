using System;
using System.Collections.Generic;
using UnityEngine;

//10.04.23

public class FZTranslations : MonoBehaviour
{
    public static List<FZText> AllTextsWithTranslations = new List<FZText>();
    public static int currentLanguageID;
    public DynamicText[] dynamicTexts;
    public FZButton[] languageButtons;

    public static FZTranslations Instance;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ChangeLanguage(FZSave.Int.Get("currentLanguageID", 0));
    }

    public void ChangeLanguage(int ID)
    {
        foreach (var btn in languageButtons)
        {
            btn.interactable = true;
        }
        languageButtons[ID].interactable = false;

        currentLanguageID = ID;
        FZSave.Int.Set("currentLanguageID", currentLanguageID);
        foreach (var text in AllTextsWithTranslations)
        {
            if (text != null)
            {
                text.ChangeTextLanguage();
            }
        }
    }

    public static string GetDynamicText(int ID)
    {
        return Instance.dynamicTexts[ID].variants[currentLanguageID];
    }

    [Serializable]
    public class DynamicText
    {
        public string[] variants;
    }
}
