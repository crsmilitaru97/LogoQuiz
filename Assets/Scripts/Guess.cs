using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Guess : MonoBehaviour
{
    public string value;

    public void RenderValue()
    {
        transform.GetChild(0).GetComponent<Text>().text = value;
    }

    public void ChooseThis()
    {
        Button button = GetComponent<Button>();
        GuessManager guessManager = GetComponentInParent<GuessManager>();

        if (value.ToUpperInvariant() == LogosManager.currentLogo.name.ToUpperInvariant())
        {
            FZColors.ChangeButtonColors(button, button.colors.normalColor, guessManager.trueColor);
            StartCoroutine(WaitToFinish(true));
            return;
        }

        FZColors.ChangeButtonColors(button, button.colors.normalColor, guessManager.falseColor);
        StartCoroutine(WaitToFinish(false));
    }

    private IEnumerator WaitToFinish(bool solved)
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSecondsRealtime(0.4f);

        Logic.Instance.SolveWord(solved);
    }
}
