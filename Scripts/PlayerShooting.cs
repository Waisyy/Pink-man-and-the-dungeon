using UnityEngine;

public class PlayerShooting : MonoBehaviour 
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float cooldownTime = 2f;
    
    private float nextFireTime = 0f;

    void Update() 
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) 
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0; // Обнуляем Z, чтобы не было проблем с 2D
            
            Vector2 direction = (mouseWorldPos - transform.position).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = direction * bulletSpeed;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            nextFireTime = Time.time + cooldownTime;
        }
    }
}