using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // References
    Credits credits;
    Tower tower;
    Rigidbody2D rb;
    Collider2D myCollider;
    TowerHealth towerHealth;




    // Variables
    //public int damagePerHit;
    public EnemyHealth enemyHealth;
    [SerializeField] float damage = 1f;

    // For Moving
    
    public bool hasReachedTower = false;


    void Awake()
    {
        credits = FindAnyObjectByType<Credits>();
        tower = FindAnyObjectByType<Tower>();
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        towerHealth = FindAnyObjectByType<TowerHealth>();
        //damagePerHit = 1;
    }

    void Update()
    {
        if (enemyHealth.healthAmount <= 0)
        {
            Destroy();
        }
    }


    // Damage to the enemy
    public void DamageEnemy()
    {
        GameManager.Instance.credits += GameManager.Instance.damagePerHit;
        enemyHealth.healthAmount -= GameManager.Instance.damagePerHit;
        credits.UpdateCreditsText();
    }

    /*
    // Bei Klick
    void OnMouseDown()
    {
        if (GameManager.Instance.gameIsPaused) return;
        else DamageEnemy();
    }
    */

    // Move to tower

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            hasReachedTower = true;
            StartCoroutine(DealDamage());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            hasReachedTower = false;

        }
    }


    // Deal Damage
    IEnumerator DealDamage()
    {
        while (hasReachedTower)
        {
            yield return new WaitForSeconds(1f);
            towerHealth.healthAmount -= damage;
        }
    }


    // Destroy
    void Destroy()
    {
        Destroy(gameObject);
    }
}
