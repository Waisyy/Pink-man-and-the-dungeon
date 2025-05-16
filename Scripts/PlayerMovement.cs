using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        float savedSpeed = PlayerPrefs.GetFloat("PlayerSpeed", 5f);
        moveSpeed = savedSpeed;
    
        int savedHealth = PlayerPrefs.GetInt("MaxHealth", 3);
        GetComponent<PlayerHealth>().maxHealth = savedHealth;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = movement * moveSpeed;
        
        // Управление анимацией
        animator.SetFloat("Speed", movement.magnitude);
        
        // Разворот спрайта
        if (moveX != 0)
        {
            if (moveX < 0) transform.localScale = new Vector3(Mathf.Sign(moveX)-2.7f, 4, 4);
            else transform.localScale = new Vector3(Mathf.Sign(moveX)+2.7f, 4, 4);
            
        }
    }
}
