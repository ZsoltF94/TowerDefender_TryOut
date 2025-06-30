using TMPro;
using UnityEngine;

public class ClicksPerSecondText : MonoBehaviour
{
    // Referenzen extern
    ClicksPerSecond clicksPerSecond;

    // Referenzen intern
    TextMeshProUGUI clicksPerSecondText;

    void Awake()
    {
        clicksPerSecond = FindAnyObjectByType<ClicksPerSecond>();
        clicksPerSecondText = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        clicksPerSecondText.text = "Damage per Second: " + clicksPerSecond.cps;
    }
}
