using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public string value = string.Empty;
    public bool isSymbol = false;
    public Key fromKey;
    public int index;

    public void RenderValue()
    {
        if (isSymbol)
        {
            GetComponent<Image>().enabled = false;
        }

        transform.GetChild(0).GetComponent<Text>().text = value;
    }
}
