using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    public FZText pointsTotalText, ticketsTotalText;

    public static int tickets;
    public static int points;

    public static int pressedKeys;
    public static int deletedLetters;
    public static int helpUsed;

    public static Values Instance;

    public static List<string> Symbols = new List<string> { "!", "'", "-", ".", " ", "&" };

    private void Awake()
    {
        Instance = this;

        #region Saves
        tickets = PlayerPrefs.GetInt("tickets", 0);
        points = PlayerPrefs.GetInt("points", 10);

        //Stats
        pressedKeys = PlayerPrefs.GetInt("pressedKeys", 0);
        deletedLetters = PlayerPrefs.GetInt("deletedLetters", 0);
        helpUsed = PlayerPrefs.GetInt("hintsUsed", 0);
        #endregion

        pointsTotalText.text = points.ToString();
        if (ticketsTotalText != null)
            ticketsTotalText.text = tickets.ToString();
    }

    public static void UpdateTextWithValue(Text text, int value)
    {
        text.text = value.ToString();
    }

    public void AddToPoints(int value)
    {
        points += value;
        pointsTotalText.SlowlyUpdateNumberText(points);
        PlayerPrefs.SetInt("points", points);
    }

    public void AddToTickets(int value)
    {
        tickets += value;
        ticketsTotalText.SlowlyUpdateNumberText(tickets);
        PlayerPrefs.SetInt("tickets", tickets);
    }
}