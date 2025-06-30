using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // References
    Slider slider;

    // Variables
    public float healthAmount;


    void Start()
    {
        slider = GetComponentInChildren<Slider>();

        slider.maxValue = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = healthAmount;
    }
}
