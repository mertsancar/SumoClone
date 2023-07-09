using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private bool isPaused = false;

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Set time scale to 1 to resume the game
        ScreenManager.instance.CloseScreens();
    }

    public void QuitGame()
    {
        // Implement your quit game functionality here
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}