using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;

    void Update()
    {
        slider.value = (float)playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
