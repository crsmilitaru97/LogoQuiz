using System;
using UnityEngine;

public class ShareContent : MonoBehaviour
{
    public string text;
    public Sprite image;
    
    #region BasicEvents
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }
    #endregion

    public void Share()
    {
        string facebookshare = "https://www.facebook.com/sharer/sharer.php?u=" + Uri.EscapeUriString("Share");
        Application.OpenURL(facebookshare);

        //string twittershare = "http://twitter.com/home?status=" + Uri.EscapeUriString(appStoreLink);
        //Application.OpenURL(twittershare);
    }
}
