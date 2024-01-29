using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAi : MonoBehaviour
{
    public Transform player;
    public Transform enemy;

    public float distanceThreshold = 10f;
    public float movementSpeed = 5f;
    public float deadZone = 1f;
    public float fireRate = 2f;
    private float lastFireTime = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, enemy.position);
		transform.LookAt(player.position);
		if (distance > distanceThreshold)
        {
            Vector3 direction = (player.position - enemy.position).normalized;
            enemy.position += direction * movementSpeed * Time.deltaTime;
        }
        else if (distance < distanceThreshold - deadZone)
        {
            
            Vector3 direction = (enemy.position - player.position).normalized;
            enemy.position += direction * movementSpeed * Time.deltaTime;
            if (Time.time - lastFireTime >= fireRate)
            {
                FireBullet();
                lastFireTime = Time.time;
            }
        }
        else if (distance < distanceThreshold + deadZone)
        {
            enemy.position = enemy.position;
            if (Time.time - lastFireTime >= fireRate)
            {
                FireBullet();
                lastFireTime = Time.time;
            }
        }
    }
    void FireBullet()
    {
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 shootDirection = (player.position - firePoint.position ).normalized;
        projectile.transform.rotation = Quaternion.LookRotation(shootDirection);

        ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();
        if (projectileScript != null)
        {
            projectileScript.SetProperties(7f);
        }
    }
}
