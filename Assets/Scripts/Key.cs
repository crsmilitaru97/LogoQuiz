using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private static readonly Vector2 keySize = new Vector2(96, 96);
    private Vector2 keyZoomSize = new Vector2(keySize.x + 20, keySize.y + 20);
    public int ID;
    public string value;
    public string neededValue;

    public bool isSymbol = false;
    public Key fromKey;
    public int index;
    public bool isFinal = false;
    bool isCorrect = false;

    public void RefreshUI()
    {
        isSymbol = Values.Symbols.Contains(neededValue.ToString());
        var keyBtn = GetComponent<FZButton>();

        if (isSymbol)
        {
            GetComponent<Image>().enabled = false;
            value = neededValue;
            keyBtn.interactable = false;
            isCorrect = true;
        }

        keyBtn.buttonText.text = value;
    }

    public void SelectKey(Key selectedKey)
    {
        if (isFinal)
        {
            PlayerPrefs.SetInt("deletedLetters", ++Values.deletedLetters);

            Logic.currentFinalKey.Unhighlight();
            Logic.currentFinalKey = selectedKey;
            selectedKey.Highlight();
        }
        else
        {
            PlayerPrefs.SetInt("pressedKeys", ++Values.pressedKeys);

            FZAudio.Manager.PlaySound(Sounds.Instance.keyPress);
            if (!string.IsNullOrEmpty(Logic.currentFinalKey.value))
            {
                Logic.currentFinalKey.fromKey.Selected(false);
            }
            Logic.currentFinalKey.value = selectedKey.value;
            Logic.currentFinalKey.isCorrect = Logic.currentFinalKey.value == Logic.currentFinalKey.neededValue;
            Logic.currentFinalKey.fromKey = selectedKey;
            Logic.currentFinalKey.RefreshUI();

            selectedKey.Selected(true);

            var nextKey = GetNextFinalKey();
            if (nextKey == null)
                CheckWord();
            else
            {
                Logic.currentFinalKey.Unhighlight();
                Logic.currentFinalKey = nextKey;
                nextKey.Highlight();
            }
        }
    }

    public void Highlight()
    {
        GetComponent<RectTransform>().sizeDelta = keyZoomSize;
    }

    public void Unhighlight()
    {
        GetComponent<RectTransform>().sizeDelta = keySize;
    }

    public void Selected(bool value)
    {
        if (value)
            GetComponent<FZButton>().interactable = false;
        else
            GetComponent<FZButton>().interactable = true;

    }

    private Key GetNextFinalKey()
    {
        // x -> final
        for (int i = Logic.currentFinalKey.ID + 1; i < Logic.Instance.FinalKeys.Count; i++)
        {
            if (string.IsNullOrEmpty(Logic.Instance.FinalKeys[i].value))
            {
                return Logic.Instance.FinalKeys[i];
            }
        }

        // @ 0 -> x
        for (int i = 0; i < Logic.currentFinalKey.ID; i++)
        {
            if (string.IsNullOrEmpty(Logic.Instance.FinalKeys[i].value))
            {
                return Logic.Instance.FinalKeys[i];
            }
        }

        return null;
    }

    private void CheckWord()
    {
        bool correct = true;
        foreach (var key in Logic.Instance.FinalKeys)
        {
            if (string.IsNullOrEmpty(key.value))
                return;

            if (key.isCorrect == false)
                correct = false;
        }
        if (correct)
            Logic.Instance.SolveWord(true);
        else
            Logic.Instance.finalWordBar.GetComponent<Animator>().SetBool("expanded", true);
    }
}
