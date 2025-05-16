using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Text healthText;
    public float deathDelay = 1.5f; // Задержка перед переходом в меню

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return; // Уже мертв

        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0) 
        {
            StartCoroutine(DieCoroutine());
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Здоровье: " + currentHealth;
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene("MainMenu");
        
        Time.timeScale = 1f;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}