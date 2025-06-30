using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteMenuPanel;

    void Start()
    {
        levelCompleteMenuPanel.SetActive(false);
    }

    public void OnLevelComplete()
    {
        levelCompleteMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.gameIsPaused = true;
    }

    public void NextLevel()     // Button
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame()      // Button
    {
        Application.Quit();
        Debug.Log("Spiel beendet.");
    }

    
}
