using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
	public GameObject bulletPoint;
	public float attackSpeed = 0.5f;
    public float projectileSpeed = 20f;
    private float lastFireTime = 0f;
    public AudioSource shootSound;

    void Update()
    {
        if (Input.GetMouseButton(0) && (Time.time - lastFireTime) > 1f / attackSpeed)
        {
            Shoot();
            lastFireTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, bulletPoint.transform.position, transform.rotation);
        ProjectileScript projectileScript = projectile.AddComponent<ProjectileScript>();
        projectileScript.SetProperties(projectileSpeed);
		shootSound.Play();
	}
}

