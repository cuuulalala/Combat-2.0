using UnityEngine;
 codex/implement-player-movement-and-shooting-mechanics-c0ewn5
using UnityEngine.InputSystem;
> main

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float damage = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;

    void Update()
    {
 codex/implement-player-movement-and-shooting-mechanics-c0ewn5
        if (Mouse.current != null && Mouse.current.leftButton.isPressed && Time.time >= nextFireTime)

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
main
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.damage = damage;
            bullet.speed = bulletSpeed;
        }
    }
}
