using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoUI : MonoBehaviour
{
    public LogosManager.Logo logo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLogo()
    {
        LogosManager.currentLogo = logo;
    }
}
