using System;
using System.Collections.Generic;
using UnityEngine;

public class Logos : MonoBehaviour
{
    public enum Countries { France, Romania, USA, Germany, Switzerland, Spain, Poland, Sweden, Russia, Netherlands, Belgium, Greece, UnitedKingdom, Estonia, China, Italy };
    public Category[] categories;

    [Serializable]
    public class Logo
    {
        public string name;
        [Header("Details")]
        public Sprite fullImage;
        public Sprite partImage;
        public string hint = string.Empty;
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
        [Header("Details")]
        public Color color;
        public Logo[] words;
        public BonusLogo[] bonusWords;
        [HideInInspector]
        public int priceToUnlock = 0;
        [HideInInspector]
        public int wordsDoneCount = 0;
        [HideInInspector]
        public bool randomized = false;
        [HideInInspector]
        public bool completed = false;
    }
}
