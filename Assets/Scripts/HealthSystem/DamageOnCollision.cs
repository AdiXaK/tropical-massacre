using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public int damageAmount = 10;
    public string Target;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Target)) 
        {
            HealthManager playerHealthManager = other.GetComponent<HealthManager>(); 
            if (playerHealthManager != null)
            {
                playerHealthManager.TakeDamage(damageAmount);
            }
        }
    }
}
