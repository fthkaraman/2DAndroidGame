using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;

    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    public int maxHealth = 100;
    int currentHealth;

    float dirX;
    public float attackRange = 2f;

   
    float moveSpeed = 3f;

    Rigidbody2D rb;

    bool facingRight = false;

    Vector3 localScale;

    
    void Start()
    {
        currentHealth = maxHealth;

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    
    void Update()
    {
        if (transform.position.x < -9f)
        {
            dirX = 1f;
            
        }           
        else if (transform.position.x > 9f)
        {
            dirX = -1f;
            
        }
            
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Character"))
        {
            animator.SetTrigger("EnemyAttack");         
        }
    }

    


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }         
    }

    void Die()
    {
        animator.SetBool("isDeath", true);
        
        GetComponent<Rigidbody2D>().simulated = false;

        this.enabled = false;

        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}
