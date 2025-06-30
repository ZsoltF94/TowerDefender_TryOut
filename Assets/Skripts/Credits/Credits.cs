using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    // Referenzen intern
    TextMeshProUGUI creditsText;
    public EnemyHealth enemyHealth;

    // Variablen
    public int currentCredits = 0;
    

    void Awake()
    {
        creditsText = GetComponentInChildren<TextMeshProUGUI>();
        creditsText.text = "Credits = " + GameManager.Instance.credits;

    }

    void Update()
    {
        

    }

    public void UpdateCreditsText()
    {
        creditsText.text = "Credits = " + GameManager.Instance.credits;
    }
}
