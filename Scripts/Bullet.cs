using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float lifetime = 10f;
    public int damage = 1; // Количество урона
    

    void Start() 
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy")) 
        {
            int totalDamage = damage + ShopSystem.Instance.currentDamageLevel - 1;
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(totalDamage);
            }
        }
        
    }
}