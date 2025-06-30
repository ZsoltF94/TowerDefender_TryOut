using TMPro;
using UnityEngine;

public class DamagePerHitText : MonoBehaviour
{
    public TextMeshProUGUI damagePerHitText;

    void Awake()
    {
        damagePerHitText = GetComponentInChildren<TextMeshProUGUI>();
    }

    
    void Update()
    {
        damagePerHitText.text = "Damage Per Hit: " + GameManager.Instance.damagePerHit;
    }
}
