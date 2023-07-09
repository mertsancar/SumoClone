using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button pauseButton;

    private void Start()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(OnClickPause);
    }

    private void OnClickPause()
    {
        ScreenManager.instance.OpenScreen(ScreenNames.PauseScreen);
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
    }


}