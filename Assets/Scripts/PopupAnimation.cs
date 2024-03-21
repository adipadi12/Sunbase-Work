using UnityEngine;
using DG.Tweening;

public class PopupAnimation : MonoBehaviour
{
    public CanvasGroup popupCanvasGroup;
    public float fadeInDuration = 0.5f;
    public float fadeOutDuration = 0.5f;

    private void Start()
    {
        // Initialize the popup window with zero alpha (fully transparent)
        popupCanvasGroup.alpha = 0f;
    }

    public void FadeInPopup()
    {
        // Fade in the popup window
        popupCanvasGroup.DOFade(1f, fadeInDuration);
    }

    public void FadeOutPopup()
    {
        // Fade out the popup window
        popupCanvasGroup.DOFade(0f, fadeOutDuration);
    }
}
