using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Button audioButton, vibrationButton, swipeButton;
    public Text versionText;

    public static bool audioEnabled = true;
    public static bool vibrationEnabled = true;
    public static bool isSwipeEnabled = true;

    private void Start()
    {
        audioEnabled = FZSave.Bool.Get("audioEnabled", true);
        vibrationEnabled = FZSave.Bool.Get("vibrationEnabled", true);
        isSwipeEnabled = FZSave.Bool.Get("swipeEnabled", true);

        VisualyChange(audioButton.GetComponent<Image>(), audioEnabled);
        VisualyChange(vibrationButton.GetComponent<Image>(), vibrationEnabled);
        VisualyChange(swipeButton.GetComponent<Image>(), isSwipeEnabled);

        versionText.text = "V" + Application.version;
    }

    public void SwitchAudio()
    {
        audioEnabled = !audioEnabled;
        VisualyChange(audioButton.GetComponent<Image>(), audioEnabled);
        FZSave.Bool.Set("audioEnabled", audioEnabled);
    }

    public void SwitchVibration()
    {
        vibrationEnabled = !vibrationEnabled;
        VisualyChange(vibrationButton.GetComponent<Image>(), vibrationEnabled);
        FZSave.Bool.Set("vibrationEnabled", vibrationEnabled);
    }

    public void SwitchSwipe()
    {
        isSwipeEnabled = !isSwipeEnabled;
        VisualyChange(swipeButton.GetComponent<Image>(), isSwipeEnabled);
        FZSave.Bool.Set("swipeEnabled", isSwipeEnabled);
    }

    private void VisualyChange(Image button, bool enabled)
    {
        Color color;
        if (enabled)
        {
            color = Color.white;
            color.a = 1;
        }
        else
        {
            color = Color.white;
            color.a = 0.2f;
        }
        button.color = color;
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();

        foreach (var category in WordsDB.categoriesRO)
        {
            category.randomized = false;
        }

        SceneManager.LoadScene(0);
    }
}
