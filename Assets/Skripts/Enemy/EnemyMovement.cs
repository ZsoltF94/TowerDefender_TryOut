
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // State mashine
    enum EnemyState
    {
        MoveToTower,
        ChasePlayer
    }
    EnemyState currentState;



    // References
    Rigidbody2D rb;
    Tower tower;
    PlayerMovement player;
    Animator animator;
    Vector2 moveDirection;
    Enemy enemy;

    // Variables
    bool hasReachedTower = false;
    bool hasReachedPlayer = false;
    [SerializeField] bool preferTower = true;
    [SerializeField] float playerChaseRange = 10f;

    // For State Decision
    float switchCoolDown = 0.5f;
    float nextSwitchTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tower = FindAnyObjectByType<Tower>();
        animator = GetComponent<Animator>();
        enemy = FindAnyObjectByType<Enemy>();
        player = FindAnyObjectByType<PlayerMovement>();
    }


    void Update()
    {
        
        // Evaluate State
        if (Time.time >= nextSwitchTime)
        {
            EvaluateState();
            nextSwitchTime = Time.time + switchCoolDown;
        }
      
        


        // Movement
        if (!hasReachedTower && !hasReachedPlayer)   // if not reached anything
        {
            MoveAccordingToState();

        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        // Update Animations
        Update_MovementAnimations();

    }







    // State herausfinden
    void EvaluateState()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distToTower = Vector2.Distance(transform.position, tower.transform.position);

        bool playerInRange = distToPlayer <= playerChaseRange;

        if (playerInRange)  // Wenn der Spieler in Reichweite ist
        {
            if (preferTower && distToTower <= distToPlayer)     // Wenn der Enemy nur den Tower jagen soll
            {
                currentState = EnemyState.MoveToTower;
            }
            else        // Jage Spieler
            {
                currentState = EnemyState.ChasePlayer;
            }
        }
        else currentState = EnemyState.MoveToTower;     // Sonst jage Tower
    }


    // Move according to State
    void MoveAccordingToState()
    {
        Vector2 moveDir;

        if (currentState == EnemyState.ChasePlayer)
        {
            moveDir = (player.transform.position - transform.position).normalized;
        }
        else if (currentState == EnemyState.MoveToTower)
        {
            moveDir = (tower.transform.position - transform.position).normalized;
        }
        else moveDir = Vector2.zero;

        rb.linearVelocity = moveDir * GameManager.Instance.enemyMoveSpeed;
        
    }






    // Collision with Tower
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            hasReachedTower = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            hasReachedPlayer = true;
        }
    }
    // Collision Exit with Tower
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            hasReachedTower = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            hasReachedPlayer = false;
        }
    }


    // Animations
    void Update_MovementAnimations()
    {
        if (rb.linearVelocity != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            Update_WalkAnimation_Direction();
        }
        else
        {
            animator.SetBool("isMoving", false);
            Update_IdleAnimation_Direction();
        }
    }


    // Walking Animation
    void Update_WalkAnimation_Direction()
    {
        // keep the last MoveX value if not moving
        if (rb.linearVelocity == Vector2.zero) return;

        // Update MoveX value
        if (moveDirection.x <= 0)
        {
            animator.SetFloat("MoveX", 0);
        }
        else animator.SetFloat("MoveX", 1);
    }


    // Idle Animation
    void Update_IdleAnimation_Direction()
    {

        if (moveDirection.x <= 0)
        {
            animator.SetFloat("MoveX", 0);
        }
        else animator.SetFloat("MoveX", 1);
    }


    



    
    

}
