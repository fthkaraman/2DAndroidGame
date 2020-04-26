using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;

    public Transform attackTrigger;  
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;   
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
              
        if (Input.GetButtonDown("FireJ"))
        {           
            Attack1();
           
        }    
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("isDeath");
            GetComponent<Rigidbody2D>().simulated = false;

            FindObjectOfType<GameManager>().EndGame();

        }
    }

    public void Attack1()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackTrigger.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackTrigger == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackTrigger.position, attackRange);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            animator.SetTrigger("Hurt");
            TakeDamage(10);
        }
    }
}
