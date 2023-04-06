using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreGame : MonoBehaviour
{
    public Image top;
    public FZText doneText;
    public FZText titleText;
    public GameObject logoUIPrefab;
    public RectTransform logosGroup;

    private void Start()
    {
        top.color = Menu.instance.iconsColor;

        titleText.text = LogosManager.currentCategory.name;
        doneText.text = $"{LogosManager.currentCategory.wordsDoneCount}/{LogosManager.currentCategory.Logos.Length}";

        foreach (var logo in LogosManager.currentCategory.Logos)
        {
            var logoObj = Instantiate(logoUIPrefab, logosGroup);

            logoObj.GetComponent<LogoUI>().logo = logo;

            if (logo.isDone)
                logoObj.GetComponent<FZButton>().buttonImage.sprite = logo.fullImage;
            else
                logoObj.GetComponent<FZButton>().buttonImage.sprite = logo.partImage;

            logoObj.GetComponent<FZButton>().interactable = !logo.isDone;

            FZColors.ChangeButtonColors(logoObj.GetComponent<FZButton>(), logoObj.GetComponent<FZButton>().colors.normalColor, LogosManager.currentCategory.color);
        }

        StartCoroutine(LoadingLogosAnimation());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu(true);
    }

    public void BackToMenu(bool showCategories)
    {
        Menu.showCategories = showCategories;
        SceneManager.LoadScene(0);
    }

    private IEnumerator LoadingLogosAnimation()
    {
        for (int i = 0; i < LogosManager.currentCategory.Logos.Length; i++)
        {
            logosGroup.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.025f);
        }
    }
}
