using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;              // Assign MainMenu
    public GameObject settingScreen;         // Assign SettingScreen
    public GameObject levelCompleteScreen;   // ✅ Assign LevelCompletedScreen
    public GameObject darkOverlay;           // Assign DarkOverlay

    public Animator settingAnimator;         // Animator on Setting Panel
    public Animator levelCompleteAnimator;   // ✅ Animator on LevelComplete Panel

    // ---------- SETTINGS ----------
    public void OpenSettings()
    {
        darkOverlay.SetActive(true);
        mainMenu.SetActive(true);
        settingScreen.SetActive(true);
        settingAnimator.SetTrigger("Open");
    }

    public void CloseSettings()
    {
        settingAnimator.SetTrigger("Close");
        Invoke("HideSettings", 0.5f); // Match animation time
    }

    void HideSettings()
    {
        settingScreen.SetActive(false);
        darkOverlay.SetActive(false);
        mainMenu.SetActive(true);
    }

    // ---------- LEVEL COMPLETE ----------
    public void ShowLevelComplete()
    {
        darkOverlay.SetActive(true);
        mainMenu.SetActive(false);
        levelCompleteScreen.SetActive(true);
        levelCompleteAnimator.SetTrigger("Open");
    }

    public void CloseLevelComplete()
    {
        levelCompleteAnimator.SetTrigger("Close");
        Invoke("HideLevelComplete", 0.4f);
    }

    void HideLevelComplete()
    {
        levelCompleteScreen.SetActive(false);
        darkOverlay.SetActive(false);
        mainMenu.SetActive(true);
    }
}
