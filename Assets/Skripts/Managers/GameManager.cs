using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // References
    public YouLose youLoseManager;

    // Game Paused
    public bool gameIsPaused = false;

    // UI Text Info
    public int credits = 0;
    

    // Bullet stats
    [Header("Bullet Stats")]
    public float bulletSpeed = 10f;
    public float bulletlifetime = 5f;
    public bool homing = false;
    public float bulletSize = 1f;

    // Fire Stats
    [Header("Fire Stats")]
    public int damagePerHit = 0;
    public float fireRate = 1;
    public bool holdToFire = true;
    public float lerpTime = 0.5f;
    public float invokeHoming = 1f;

    // Enemies
    [Header("Enemies")]
    public float enemySpawnRate = 1f;
    public float bigAssEnemySpawnRate = 1f;
    public float enemyMoveSpeed = 5f;
    


    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LevelLost()
    {
        youLoseManager.LevelLost();
    }
}
