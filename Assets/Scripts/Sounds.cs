using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds Instance;
    public AudioClip correct;
    public AudioClip wrong;
    public AudioClip keyPress;

    void Awake()
    {
        Instance=this;
    }
}
