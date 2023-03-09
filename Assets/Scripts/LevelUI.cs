using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text title;
    public Text done;
    public Image doneFill;
    public GameObject locked;
    public Logos logos;

    private Color textColor = new Color(0.2f, 0.2f, 0.2f, 1);
    private Color textColor2 = new Color(0.2f, 0.2f, 0.2f, 0.6f);

    private Color disabledTextColor = new Color(0.2f, 0.2f, 0.2f, 0.6f);
    private Color disabledTextColor2 = new Color(0.2f, 0.2f, 0.2f, 0.3f);

    public int index;
    private int priceToUnlock;

    private bool fly;
    private List<GameObject> ticketsToFly = new List<GameObject>();
    private Logos.Category currentCategory;


    private void Awake()
    {
        currentCategory = logos.categories[index];
    }

    private void Start()
    {
        GetComponent<Image>().color = currentCategory.color;

        //disabledColor = thisCategory.normalColor;
        //disabledColor.a = 0.5f;
        //disabledColorDark = thisCategory.darkColor;
        //disabledColorDark.a = 0.5f;


        Lock(!FZSave.Bool.Get($"{currentCategory.name}Unlocked", false));

        // VisualyChange(thisCategory.completed);

        title.text = currentCategory.name;
        done.text = $"{currentCategory.wordsDoneCount}/{currentCategory.words.Length}";
        doneFill.fillAmount = currentCategory.completed ? (float)currentCategory.wordsDoneCount / currentCategory.words.Length : 0;
    }

    private void VisualyChange(bool enabled)
    {
        if (enabled)
        {
            title.color = disabledTextColor;
            done.color = disabledTextColor2;

            //thisCategory.normalColor = disabledColor;
            //thisCategory.darkColor = disabledColorDark;

            //GetComponent<Image>().color = disabledColor;
            //doneFill.color = disabledColorDark;
        }
        else
        {
            title.color = textColor;
            done.color = textColor2;

            //GetComponent<Image>().color = thisCategory.normalColor;
            //doneFill.color = thisCategory.darkColor;
        }
    }

    public void Play()
    {
        Menu.categoryScrollIndex = index;
        Values.currentCategoryIndex = index;
        FZCanvas.Instance.FadeLoadSceneAsync(1);
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
            locked.SetActive(true);
            GetComponent<Button>().interactable = false;
            done.gameObject.SetActive(false);

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
            locked.SetActive(false);
            GetComponent<Button>().interactable = true;
            done.gameObject.SetActive(true);
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
