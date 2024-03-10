using UnityEngine;

public class LogoUI : MonoBehaviour
{
    public LogosManager.Logo logo;

    public void SelectLogo()
    {
        LogosManager.currentLogo = logo;
        FZCanvas.Instance.FadeLoadScene(2, Values.Instance.accentColor);
    }
}
