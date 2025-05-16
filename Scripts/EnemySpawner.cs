using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 8;
    public float spawnInterval = 3f;
    public Vector2 spawnAreaSize = new Vector2(10f, 5f); // Размер зоны

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies) return;
        // Случайная позиция внутри зоны
        Vector2 spawnPos = (Vector2)transform.position + 
                          new Vector2(
                              Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                              Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
                          );

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Визуализация зоны в редакторе (только для отладки)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position, spawnAreaSize);
    }
}