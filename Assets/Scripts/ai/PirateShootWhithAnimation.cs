using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShootWhithAnimation : PirateAi
{
	

	void Shoot()
    {
		GameObject projectile = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
		Vector3 shootDirection = (player.position - firePoint.position).normalized;
		projectile.transform.rotation = Quaternion.LookRotation(shootDirection);
		shootSound.Play();

		ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();
		if (projectileScript != null)
		{
			projectileScript.SetProperties(7f);
		}
	}
}
