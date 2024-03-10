using UnityEngine;
using UnityEngine.UI;

public class CategoryUI : MonoBehaviour
{
    public FZText title;
    public FZText doneText;
    public FZText doneMaxText;

    public Image doneFill;

    public GameObject lockedGroup;
    public FZText priceText;

    public int index;

    public LogosManager.Category category;

    public void Refresh()
    {
        GetComponent<Image>().color = category.color;

        title.text = category.name; 
        category.wordsDoneCount=0;
        foreach (var logo in category.Logos)
        {
            if (FZSave.Bool.Get($"{category.name}_{logo.name}_done", false))
            {
                logo.isDone = true;
                category.wordsDoneCount++;
            }
        }
        doneText.text = category.wordsDoneCount.ToString();
        doneMaxText.text = $"/{category.Logos.Length}";
        doneFill.fillAmount = category.completed ? (float)category.wordsDoneCount / category.Logos.Length : 0;
        category.locked = FZSave.Bool.Get($"{category.name}Locked", true);
        Lock(category.locked);
    }

    public void TryBuyCategory()
    {
        Menu.selectedCategoryUI = this;

        Menu.Instance.buyCategoryButton.interactable = Values.tickets >= category.priceToUnlock;
        Menu.Instance.buyCategoryButton.GetComponent<Image>().color = category.color;
        Menu.Instance.buyCategoryTitle.text = category.name;
        Menu.Instance.buyCategoryPriceText.text = category.priceToUnlock.ToString();

        Menu.Instance.buyCategoryGroup.SetActive(true);
        Menu.Instance.buyCategoryGroup.GetComponent<Animator>().SetBool("shown", true);
    }

    public void Play()
    {
        Menu.categoryScrollIndex = index;
        LogosManager.currentCategory = category;
        FZCanvas.Instance.FadeLoadScene(1, Values.Instance.accentColor);
    }

    public void Lock(bool locked)
    {
        doneText.gameObject.SetActive(!locked);
        doneMaxText.gameObject.SetActive(!locked);
        lockedGroup.SetActive(locked);

        if (locked)
        {
            GetComponent<Button>().interactable = false;
            doneText.gameObject.SetActive(false);

            //priceToUnlock = 0;
            //for (int i = 0; i < index; i++)
            //{
            //    priceToUnlock += (int)(WordsDB.categoriesRO[i].words.Length / 2f) - WordsDB.categoriesRO[i].priceToUnlock;
            //}
            //currentCategory.priceToUnlock = priceToUnlock;
            priceText.text = category.priceToUnlock.ToString();
        }
        else
        {
            GetComponent<Button>().interactable = true;
            doneText.gameObject.SetActive(true);
        }
    }
}
