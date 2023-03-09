using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    public static int tickets;
    public static int points;
    public static int currentCategoryIndex;
    public static int currentWordIndex;

    public static int pressedKeys;
    public static int deletedLetters;
    public static int helpUsed;

    private void Awake()
    {
        #region Saves
        tickets = PlayerPrefs.GetInt("tickets", 0);
        points = PlayerPrefs.GetInt("points", 10);

        //Stats
        pressedKeys = PlayerPrefs.GetInt("pressedKeys", 0);
        deletedLetters = PlayerPrefs.GetInt("deletedLetters", 0);
        helpUsed = PlayerPrefs.GetInt("hintsUsed", 0);
        #endregion
    }

    public static void UpdateTextWithValue(Text text, int value)
    {
        text.text = value.ToString();
    }
}