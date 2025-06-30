using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public bool holdToFire;
    public float fireRate;
    float fireTimer = 0;


    void Start()
    {
        fireRate = 1f / GameManager.Instance.fireRate;
        holdToFire = GameManager.Instance.holdToFire;
    }
    void Update()
    {
        fireRate = 1f / GameManager.Instance.fireRate;
        fireTimer += Time.deltaTime;

        if(Input.GetMouseButton(0))    // Linksklick
        {
            if ((fireTimer >= fireRate) && holdToFire)
            {
                Shoot();
                fireTimer = 0f;
            }

        }
    }

    void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDir = (mouseWorldPos - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().shotStartDirection = shootDir;
    }
}
