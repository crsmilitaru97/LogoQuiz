using System;
using System.Collections.Generic;
using UnityEngine;

public class LogosManager : MonoBehaviour
{
    public Category[] Categories;

    public static Category currentCategory;
    public static Logo currentLogo;

    public static LogosManager Manager;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        Manager = this;

        int i = 0;
        foreach (var category in Categories)
        {
            category.locked = FZSave.Bool.Get($"{category.name}Unlocked", false);

            foreach (var logo in category.Logos)
            {
                logo.fullImage = Resources.Load<Sprite>("Logos/" + category.name + "/" + logo.name);
                logo.partImage = Resources.Load<Sprite>("Logos/" + category.name + "/" + logo.name + "_");

                logo.ID = i;
                i++;

                if (logo.partImage == null)
                    logo.partImage = logo.fullImage;
            }
        }

        Categories[0].locked = false;
    }


    [Serializable]
    public class Logo
    {
        public string name;
        [HideInInspector]
        public int ID;
        [HideInInspector]
        public Sprite fullImage;
        [HideInInspector]
        public Sprite partImage;
        public string hint = string.Empty;
        [Header("Details")]
        public string country;
        public int startYear;
        public int endYear;
        [Multiline]
        public string about = string.Empty;

        [HideInInspector]
        public bool isDone = false;
        [HideInInspector]
        public bool isGuess = false;
        [HideInInspector]
        public bool guessed = false;
    }

    [Serializable]
    public class BonusLogo
    {
        public Logo logo;
        public List<string> variants;
    }

    [Serializable]
    public class Category
    {
        public string name;
        public Color color;
        public Logo[] Logos;
        //public BonusLogo[] bonusWords;


        [HideInInspector]
        public int priceToUnlock = 0;
        [HideInInspector]
        public int wordsDoneCount = 0;
        [HideInInspector]
        public bool randomized = false;
        [HideInInspector]
        public bool completed = false;
        [HideInInspector]
        public bool locked = true;
    }
}
