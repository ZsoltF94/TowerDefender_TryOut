using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    // References
    Slider slider;

    // Variables
    public float healthAmount = 1000f;
    
    
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthAmount;
        if (healthAmount <= 0)
        {
            GameManager.Instance.LevelLost();
        }
    }
}
