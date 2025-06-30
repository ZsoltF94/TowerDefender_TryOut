using UnityEngine;

public class Bullet : MonoBehaviour
{

    // References
    Rigidbody2D rb;

    // Variables
    float bulletSpeed;
    float bulletlifetime;
    public Vector2 shotStartDirection;
    public bool homingActivated;



    void Start()
    {
        bulletSpeed = GameManager.Instance.bulletSpeed;
        bulletlifetime = GameManager.Instance.bulletlifetime;
        gameObject.transform.localScale = new Vector3(GameManager.Instance.bulletSize, GameManager.Instance.bulletSize);

        Destroy(gameObject, bulletlifetime); // destroy this gameObject after x seconds

        rb = GetComponent<Rigidbody2D>();
        
        
    }

    void FixedUpdate()
    {
        // checking for homing
        if (GameManager.Instance.homing)
        {
            Invoke(nameof(ActivateHoming), GameManager.Instance.invokeHoming);
        }
        
        if (homingActivated)
        {
            Homing();
        }
        else
        {
            rb.linearVelocity = shotStartDirection.normalized * bulletSpeed;
        }

        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.DamageEnemy();
                Destroy(gameObject);
            }
        }
    }


    // homing shots:
    Transform FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);   // ein Array mit allen enemys wird erstellt
        Transform closest = null;
        float shortestDistance = Mathf.Infinity;


        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = enemy.transform;
            }
        }

        return closest;
    }

    void Homing()
    {
        Transform target = FindNearestEnemy();
        if (target == null)
        {
            rb.linearVelocity = shotStartDirection.normalized * bulletSpeed;
        }
        else
        {
            Vector2 currentDir = rb.linearVelocity.normalized;
            Vector2 targetDirection = (target.position - rb.transform.position).normalized;

            // Smooth homing from shot direction to target direction
            Vector2 newDirection = Vector2.Lerp(currentDir, targetDirection, GameManager.Instance.lerpTime * Time.fixedDeltaTime);
            rb.linearVelocity = newDirection.normalized * bulletSpeed;
            
        }
    }

    public void ActivateHoming()
    {
        if (GameManager.Instance.homing)
        {
            homingActivated = true;
        }
    }         
    
}
