using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryUI : MonoBehaviour
{
    public FZText title;
    public FZText doneText;
    public Image doneFill;
    public GameObject lockedGroup;
    public FZText priceText;

    private Color textColor = new Color(0.2f, 0.2f, 0.2f, 1);
    private Color textColor2 = new Color(0.2f, 0.2f, 0.2f, 0.6f);

    private Color disabledTextColor = new Color(0.2f, 0.2f, 0.2f, 0.6f);
    private Color disabledTextColor2 = new Color(0.2f, 0.2f, 0.2f, 0.3f);

    public int index;
    private int priceToUnlock;

    private bool fly;
    private List<GameObject> ticketsToFly = new List<GameObject>();
    public LogosManager.Category currentCategory;

    public void Refresh()
    {
        GetComponent<Image>().color = currentCategory.color;

        //disabledColor = thisCategory.normalColor;
        //disabledColor.a = 0.5f;
        //disabledColorDark = thisCategory.darkColor;
        //disabledColorDark.a = 0.5f;

        Lock(currentCategory.locked);

        // VisualyChange(thisCategory.completed);
        priceText.text = currentCategory.priceToUnlock.ToString();
        title.text = currentCategory.name;
        doneText.text = $"{currentCategory.wordsDoneCount}/{currentCategory.Logos.Length}";
        doneFill.fillAmount = currentCategory.completed ? (float)currentCategory.wordsDoneCount / currentCategory.Logos.Length : 0;
    }

    private void VisualyChange(bool enabled)
    {
        if (enabled)
        {
            title.color = disabledTextColor;
            doneText.color = disabledTextColor2;

            //thisCategory.normalColor = disabledColor;
            //thisCategory.darkColor = disabledColorDark;

            //GetComponent<Image>().color = disabledColor;
            //doneFill.color = disabledColorDark;
        }
        else
        {
            title.color = textColor;
            doneText.color = textColor2;

            //GetComponent<Image>().color = thisCategory.normalColor;
            //doneFill.color = thisCategory.darkColor;
        }
    }

    public void Play()
    {
        Menu.categoryScrollIndex = index;
        Values.currentCategoryIndex = index;
        FZCanvas.Instance.FadeLoadScene(1, Color.black);
        LogosManager.currentCategory = currentCategory;
    }

    public void BuyUnlock()
    {
        if (fly) return;

        if (Values.tickets >= priceToUnlock)
        {
            Values.tickets -= priceToUnlock;
            FZSave.Bool.Set($"{currentCategory.name}Unlocked", true);

            Menu.instance.categoriesTicketsText.transform.GetChild(0).GetComponent<FZText>().SlowlyUpdateNumberText(Values.tickets);
            PlayerPrefs.SetInt("tickets", Values.tickets);


            for (int i = 0; i < priceToUnlock; i++)
            {
                //GameObject tfly = Instantiate(ticketToFly);
                //tfly.transform.SetParent(this.transform);
                //tfly.transform.localScale = new Vector3(1, 1, 1);
                //tfly.transform.position = Menu.instance.categoriesTicketsText.transform.position;
                //ticketsToFly.Add(tfly);
            }
            fly = true;
        }
        else
        {
            if (Settings.audioEnabled)
                transform.parent.GetComponent<AudioSource>().Play();
            GetComponent<Animation>().Play("category_no");
        }
    }

    public void OpenBuyCategory()
    {

    }

    private void Lock(bool lockedStatus)
    {
        if (lockedStatus)
        {
            lockedGroup.SetActive(true);
            GetComponent<Button>().interactable = false;
            doneText.gameObject.SetActive(false);

            priceToUnlock = 0;
            for (int i = 0; i < index; i++)
            {
                priceToUnlock += (int)(WordsDB.categoriesRO[i].words.Length / 2f) - WordsDB.categoriesRO[i].priceToUnlock;
            }
            currentCategory.priceToUnlock = priceToUnlock;
            //priceToUnlockText.text = priceToUnlock.ToString();
        }
        else
        {
            lockedGroup.SetActive(false);
            GetComponent<Button>().interactable = true;
            doneText.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (fly)
        {
            bool done = false;
            foreach (var item in ticketsToFly)
            {
                //if (item.transform.position != ticketsToUnlockImage.transform.position)
                // {
                //     done = false;
                //   item.transform.position = Vector2.MoveTowards(item.transform.position, ticketsToUnlockImage.transform.position, Time.deltaTime * Random.Range(1500, 2000));
                // }
                //else
                //    done = true;
            }
            if (done)
            {
                foreach (var item in ticketsToFly)
                {
                    Destroy(item);
                }
                ticketsToFly.Clear();

                fly = false;
                Lock(false);
            }
        }
    }
}
