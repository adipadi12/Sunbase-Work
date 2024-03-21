using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PopupAnimation popupAnimation;

    public void ShowPopup()
    {
        popupAnimation.FadeInPopup();
    }

    public void ClosePopup()
    {
        popupAnimation.FadeOutPopup();
    }
}
