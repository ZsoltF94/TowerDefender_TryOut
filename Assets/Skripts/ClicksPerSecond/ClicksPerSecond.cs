using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClicksPerSecond : MonoBehaviour
{
    // Referenzen extern
    Credits credits;

    // Referenzen intern
    TextMeshProUGUI buttonText;

    // Variablen
    public int cps = 0;
    bool increaseCreditsBool = true;
    int cost = 10;

    void Awake()
    {
        credits = FindAnyObjectByType<Credits>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "Upgrade 1 Damage per Second\nCosts: " + cost;
    }

    void Start()
    {
        StartCoroutine(IncreaseCredits());
    }

    IEnumerator IncreaseCredits()
    {
        while (increaseCreditsBool)
        {
            yield return new WaitForSeconds(1f);            
            credits.currentCredits += cps;
            credits.UpdateCreditsText();
        }
    }

    void Update()
    {
        if (credits.currentCredits >= cost)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void IncreaseCps()
    {
        if (cps == 0)
        {
            cps+=1;
            credits.currentCredits -= cost;
            cost *= 2;

            buttonText.text = "Upgrade Damage x2 per Second\nCosts: " + cost;
        }
        else
        {
            cps *= 2;
            credits.currentCredits -= cost;
            cost *= 2;

            buttonText.text = "Upgrade Damage x2 per Second\nCosts: " + cost;
        }
    }

    
    

}
