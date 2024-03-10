using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//10.04.23

public class FZText : Text
{
    public float timeInterval = 0.025f;
    public string[] translations;

    protected override void OnEnable()
    {
        base.OnEnable();

        FZTranslations.AllTextsWithTranslations.Add(this);

        ChangeTextLanguage();
    }

    public void ChangeTextLanguage()
    {
        if (FZTranslations.Instance == null)
            return;

        if (translations.Length > 0 && translations.Length > FZTranslations.currentLanguageID)
        {
            text = translations[FZTranslations.currentLanguageID];
        }
    }

    public void SlowlyUpdateNumberText(int newValue)
    {
        if (gameObject.activeSelf)
        {
            int oldValue = int.Parse(text);
            StartCoroutine(ChangeNumberText(oldValue, newValue - oldValue));
        }
    }

    private IEnumerator ChangeNumberText(int oldValue, int diff)
    {
        int value = oldValue;
        if (diff >= 0)
        {
            while (value < oldValue + diff)
            {
                yield return new WaitForSecondsRealtime(timeInterval);
                value++;
                this.text = value.ToString();
            }
        }
        else
        {
            while (value > oldValue - Mathf.Abs(diff))
            {
                yield return new WaitForSecondsRealtime(timeInterval);
                value--;
                this.text = value.ToString();
            }
        }
    }

    public void SlowlyWriteText(string text)
    {
        if (gameObject.activeSelf)
        {
            StopAllCoroutines();
            StartCoroutine(WriteText(text));
        }
    }

    int i = 0;
    private IEnumerator WriteText(string text, bool withSound = false)
    {
        this.text = string.Empty;
        foreach (var item in text)
        {
            i++;
            yield return new WaitForSeconds(timeInterval);
            this.text += item.ToString();

            if (i % 2 == 0)
            {
                if (FZAudio.Manager != null && withSound)
                {
                    FZAudio.Manager.PlaySound(FZAudio.Manager.textSound);
                }
            }
        }
    }
}
