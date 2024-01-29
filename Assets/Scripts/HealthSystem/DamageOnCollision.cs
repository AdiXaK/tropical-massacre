using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public int damageAmount = 10;
	public string rangeTarget;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(rangeTarget)) 
        {
            HealthManager HealthManager = GetComponent<HealthManager>(); 
            HealthManager.TakeDamage(damageAmount);
            Destroy(other.gameObject);
        }
	}

 
}
