using UnityEngine;
using DG.Tweening;

public class SettingsCloseHandler : MonoBehaviour
{
    public GameObject homePanel;
    public RectTransform settingsPanel;  // RectTransform for animation

    public void CloseSettings()
    {
        // Animate scale down
        settingsPanel.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            // After animation completes:
            settingsPanel.gameObject.SetActive(false); // hide settings
            homePanel.SetActive(true);                 // show home
            settingsPanel.localScale = Vector3.one;    // reset scale for next time
        });
    }
}
