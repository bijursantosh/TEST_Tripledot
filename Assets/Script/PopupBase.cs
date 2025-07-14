using UnityEngine;
using DG.Tweening;

public class PopupBase : MonoBehaviour
{
    public RectTransform panel;

    void Awake()
    {
        if (panel != null)
            panel.localScale = Vector3.zero;
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        if (panel != null)
            panel.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    public virtual void Close()
    {
        if (panel != null)
        {
            panel.DOScale(0, 0.25f).SetEase(Ease.InBack).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
