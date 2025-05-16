using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int coinReward = 1; // Количество монет за убийство

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
{
    if (CoinSystem.Instance != null)
    {
        CoinSystem.Instance.AddCoins(coinReward);
    }
    else
    {
        Debug.LogError("CoinSystem.Instance не найден!");
    }
    
    Destroy(gameObject);
}
}