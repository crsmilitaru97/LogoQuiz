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
        FZSave.Bool.Set($"{Categories[0].name}Locked", false);
    }


    [Serializable]
    public class Logo
    {
        public string name;

        public string hint = string.Empty;
        [Header("Details")]
        public int startYear;
        public int endYear;
        public string country;
        [Multiline]
        public string about = string.Empty;

        [HideInInspector]
        public bool isDone = false;
        [HideInInspector]
        public int ID;
        [HideInInspector]
        public Sprite fullImage;
        [HideInInspector]
        public Sprite partImage;
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

        public int priceToUnlock = 0;
        public int wordsDoneCount = 0;
        [HideInInspector]
        public bool randomized = false;
        [HideInInspector]
        public bool completed = false;
        [HideInInspector]
        public bool locked = true;
    }
}
