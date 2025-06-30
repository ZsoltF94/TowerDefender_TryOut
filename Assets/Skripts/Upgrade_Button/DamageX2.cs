using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DamageX2 : MonoBehaviour
{
    // Referenzen extern
    Enemy enemy;
    Credits credits;

    // Referenzen intern
    TextMeshProUGUI upgradeText;


    [SerializeField] int cost = 10;


    void Awake()
    {
        enemy = FindAnyObjectByType<Enemy>();
        credits = FindAnyObjectByType<Credits>();
        upgradeText = GetComponentInChildren<TextMeshProUGUI>();
        upgradeText.text = "Damage per Hit x2\nCosts: " + cost;

    }

    void Update()
    {
        // Only interactable, if Credits >= Costs
        if (GameManager.Instance.credits >= cost)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }


    // Duplicate Damage
    public void DamagePerHitX2()
    {
        GameManager.Instance.damagePerHit *= 2;
        GameManager.Instance.credits -= cost;
        cost *= 4;

        // Update Texts
        credits.UpdateCreditsText();
        UpdateUpgradeText();

    }

    // Update Text
    public void UpdateUpgradeText()
    {
        upgradeText.text = "Damage per Hit x2\nCosts: " + cost;
    }
}
