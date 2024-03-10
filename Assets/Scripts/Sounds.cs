using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds Instance;
    public AudioClip correct;
    public AudioClip wrong;
    public AudioClip keyPress;
    public AudioClip noBuyCategory;

    void Awake()
    {
        Instance = this;
    }
}
