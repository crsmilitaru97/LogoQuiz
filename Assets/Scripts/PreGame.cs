using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreGame : MonoBehaviour
{
    public Image top;
    public Image[] icons;
    public Text done;
    public Text title;
    public GameObject imagesGroup;

    public static Word[] currentWords;
    public static Category currentCategory;

    private void Start()
    {
        #region Set Colors
        top.color = Menu.instance.iconsColor;

        foreach (var icon in icons)
        {
            icon.color = Menu.instance.iconsColor;
        }
        #endregion

        currentCategory = WordsDB.categoriesRO[Values.currentCategoryIndex];
        currentWords = currentCategory.words;

        done.text = $"{currentCategory.wordsDoneCount}/{currentWords.Length}";
        title.text = currentCategory.categoryName;

        List<Transform> wordTransform = new List<Transform>();

        for (int i = 0; i < imagesGroup.transform.childCount; i++)
        {
            Transform word = imagesGroup.transform.GetChild(i).transform;
            word.gameObject.SetActive(false);

            FZColors.ChangeButtonColors(word.GetChild(0).GetComponent<Button>(), word.GetChild(0).GetComponent<Button>().colors.normalColor, currentCategory.normalColor);

            if (i < currentWords.Length)
            {
                word.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Logos/{currentCategory.categoryName}/{currentWords[i].wordText.ToLowerInvariant()}");

                word.GetChild(0).GetComponent<Button>().interactable = !currentWords[i].isDone;
            }
        }
        StartCoroutine(WaitTillNextWord());
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

    public void SelectWord()
    {
        Values.currentWordIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        FZCanvas.Instance.FadeLoadSceneAsync(2);
    }

    private IEnumerator WaitTillNextWord()
    {
        for (int i = 0; i < currentWords.Length; i++)
        {
            imagesGroup.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.025f);
        }
    }
}
