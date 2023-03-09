using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    public CategoryDetails[] categoryDetails;

    [Serializable]
    public class CategoryDetails
    {
        public Color normalColor;
        public Color darkColor;
    }

    private void Start()
    {
        foreach (var category in WordsDB.categoriesRO)
        {
            if (!category.randomized)
            {
                int[] randOrderArray;
                randOrderArray = FZSave.Int.GetArray("RandomOrder" + category.categoryName);
               
                if (randOrderArray.Length == 0)
                {
                    randOrderArray = new int[category.words.Length];

                    randOrderArray = Enumerable.Range(0, category.words.Length).ToArray();

                    for (int i = 0; i < randOrderArray.Length; i++)
                    {
                        System.Random rnd = new System.Random();
                        randOrderArray = randOrderArray.OrderBy(x => rnd.Next()).ToArray();
                    }

                    FZSave.Int.SetArray("RandomOrder" + category.categoryName, randOrderArray);
                }

                Array.Sort(randOrderArray, category.words);

                category.randomized = true;
            }

            category.normalColor = categoryDetails[category.detailIndex].normalColor;
            category.darkColor = categoryDetails[category.detailIndex].darkColor;
        }
    }
}

public static class Countries
{
    public static string France = "France";
    public static string Romania = "Romania";
    public static string USA = "USA";
    public static string Germany = "Germany";
    public static string Switzerland = "Switzerland";
    public static string Spain = "Spain";
    public static string Poland = "Poland";
    public static string Sweden = "Sweden";
    public static string Russia = "Russia";

    public static string Netherlands = "Netherlands";
    public static string Belgium = "Belgium";
    public static string Greece = "Greece";
    public static string UK = "United Kingdom";
    public static string Estonia = "Estonia";
    public static string China = "China";
    public static string Italy = "Italy";
};

public class Word
{
    public string wordText;
    public string hint = string.Empty;
    public string country = Countries.Romania;
    public int startYear;
    public int endYear;
    public string about = string.Empty;
    public bool isDone = false;
    public bool isGuess = false;
    public bool guessed = false;
    public List<string> variants;
}

public class Category
{
    public string categoryName;
    public int detailIndex;
    public int priceToUnlock;
    public int wordsDoneCount = 0;
    public bool completed = false;
    public Word[] words;
    public Word[] bonusWords;
    public Color normalColor;
    public Color darkColor;
    public bool randomized = false;
}