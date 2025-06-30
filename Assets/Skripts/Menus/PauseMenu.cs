using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    

    void Start()
    {
        pauseMenuUI.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.gameIsPaused)
            {
                Resume();   // Wenn das Spiel pausiert ist und man ESC drückt - weiter
            }
            else
            {
                Pause();    // Wenn das Spiel nicht pausiert ist und man ESC drückt - pausieren
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Zeit läift normal weiter
        GameManager.Instance.gameIsPaused = false;

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.gameIsPaused = true;
        
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1"); // Starte bei Level 1
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Spiel wurde beendet.");
    }
}
