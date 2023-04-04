using System;
using System.Collections.Generic;
using UnityEngine;

public class LogosManager : MonoBehaviour
{
    public enum Countries { France, Japan, Romania, USA, Germany, Switzerland, Spain, Poland, Sweden, Russia, Netherlands, Belgium, Greece, UnitedKingdom, Estonia, China, Italy };
    public Category[] Categories;
    public static LogosManager Manager;
    public static Category currentCategory;
    public static Logo currentLogo;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        Manager = this;

        foreach (var category in Categories)
        {
            category.locked = FZSave.Bool.Get($"{category.name}Unlocked", false);

            foreach (var logo in category.Logos)
            {
                logo.fullImage = Resources.Load<Sprite>("Logos/" + logo.name);
                logo.partImage = Resources.Load<Sprite>("Logos/" + logo.name + "_");
            }
        }

        Categories[0].locked = false;
    }


    [Serializable]
    public class Logo
    {
        public string name;
        [HideInInspector]
        public Sprite fullImage;
        [HideInInspector]
        public Sprite partImage;
        public string hint = string.Empty;
        [Header("Details")]
        public Countries country;
        [Multiline]
        public string about = string.Empty;
        public int startYear;
        public int endYear;
        [HideInInspector]
        public bool isDone = false;

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
