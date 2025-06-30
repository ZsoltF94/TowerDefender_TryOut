using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        // Continue Button zu Beginn deaktivieren
        continueButton.interactable = false;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1"); // Starte bei Level 1
        PlayerPrefs.DeleteAll(); // Reset aller gespeicherten Daten
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Spiel wurde beendet.");
    }
}
