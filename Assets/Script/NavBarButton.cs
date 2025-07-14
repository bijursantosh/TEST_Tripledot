using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NavBarButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject bgHighlight;
    public GameObject selectorLine;
    public TMP_Text label;
    public Image iconImage;

    public Vector2 iconNormalPos;
    public Vector2 iconShiftedPos;
    public bool isLocked;

    private bool isSelected = false;
    private NavBarController controller;
    private int buttonIndex;

    public void Init(NavBarController navController, int index)
    {
        controller = navController;
        buttonIndex = index;
    }

    void Start()
    {
        iconNormalPos = iconImage.rectTransform.anchoredPosition;
        iconShiftedPos = iconNormalPos + new Vector2(0, 20);

        iconImage.transform.localScale = Vector3.one;
        bgHighlight.SetActive(false);
        selectorLine.SetActive(false);
        label.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isLocked) return;

        controller?.OnButtonPressed(buttonIndex);
    }

    public void SetSelected(bool selected)
    {
        if (isLocked) return;

        isSelected = selected;

        float totalScale = selected ? 1.2f : 1f;
        transform.DOScale(totalScale, 0.2f).SetEase(Ease.OutBack);

        iconImage.rectTransform.DOAnchorPos(
            selected ? iconShiftedPos : iconNormalPos, 0.2f).SetEase(Ease.OutQuad);

        Vector3 iconTargetScale = selected ? new Vector3(0.8f, 0.8f, 1f) : Vector3.one;
        iconImage.transform.DOScale(iconTargetScale, 0.2f).SetEase(Ease.OutBack);

        label.gameObject.SetActive(selected);
        selectorLine.SetActive(selected);
        bgHighlight.SetActive(selected);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isLocked) return;
        bgHighlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isLocked) return;
        if (!isSelected)
        {
            bgHighlight.SetActive(false);
        }
    }
}
