using UnityEngine;
using DG.Tweening;  // Requires DOTween

public class PopupAnimator : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform popupTransform;
    [SerializeField] private float animationDuration = 0.3f;

    void Awake()
    {
        // Optional: Start hidden
        canvasGroup.alpha = 0;
        popupTransform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 1;
        popupTransform.localScale = Vector3.zero;

        popupTransform.DOScale(Vector3.one, animationDuration)
                      .SetEase(Ease.OutBack);
    }

    public void HidePopup()
    {
        popupTransform.DOScale(Vector3.zero, animationDuration)
                      .SetEase(Ease.InBack)
                      .OnComplete(() =>
                      {
                          canvasGroup.alpha = 0;
                          gameObject.SetActive(false);
                      });
    }
}
