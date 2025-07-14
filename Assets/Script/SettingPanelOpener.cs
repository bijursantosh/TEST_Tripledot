using UnityEngine;
using DG.Tweening;

public class SettingsPanelAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float duration = 0.3f;

    private void Awake()
    {
        // Start hidden
        panelTransform.localScale = Vector3.zero;
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        gameObject.SetActive(true);
        panelTransform.localScale = Vector3.zero;
        canvasGroup.alpha = 1f;

        panelTransform.DOScale(Vector3.one, duration)
                      .SetEase(Ease.OutBack);
    }

    public void CloseSettings()
    {
        panelTransform.DOScale(Vector3.zero, duration)
                      .SetEase(Ease.InBack)
                      .OnComplete(() =>
                      {
                          canvasGroup.alpha = 0f;
                          gameObject.SetActive(false);
                      });
    }
}
