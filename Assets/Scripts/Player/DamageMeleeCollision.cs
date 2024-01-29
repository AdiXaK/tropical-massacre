using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMeleeCollision : MonoBehaviour
{

	public int meleeDamageAmount = 10;
	public string meleeTarget;
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(meleeTarget))
		{
			HealthManager HealthManager = GetComponent<HealthManager>();
			HealthManager.TakeDamage(meleeDamageAmount);
		}
	}
}
