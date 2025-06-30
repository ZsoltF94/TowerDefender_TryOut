using UnityEngine;
using UnityEngine.SceneManagement;


public class YouLose : MonoBehaviour
{
    public GameObject youLoseMenuPanel;

    void Start()
    {
        youLoseMenuPanel.SetActive(false);
    }

    public void LevelLost()
    {
        youLoseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.gameIsPaused = true;
    }


    // Buttons

    public void TryAgain()     // Button
    {
        Debug.Log("Kommt noch");
    }

    public void QuitGame()      // Button
    {
        Application.Quit();
        Debug.Log("Spiel beendet.");
    }
}
