using UnityEngine;

public class NavBarController : MonoBehaviour
{
    public NavBarButton[] buttons;

    private int currentSelectedIndex = -1;

    public void OnButtonPressed(int index)
    {
        if (index < 0 || index >= buttons.Length) return;

        // If clicking the same button again → deselect
        if (currentSelectedIndex == index)
        {
            buttons[index].SetSelected(false);
            currentSelectedIndex = -1;
            return;
        }

        // Deselect previously selected button
        if (currentSelectedIndex != -1)
        {
            buttons[currentSelectedIndex].SetSelected(false);
        }

        // Select new button
        buttons[index].SetSelected(true);
        currentSelectedIndex = index;
    }

    // Optional helper if you want to programmatically deselect all buttons
    public void DeselectAll()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetSelected(false);
        }
        currentSelectedIndex = -1;
    }
}
