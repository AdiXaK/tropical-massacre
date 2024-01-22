using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public int damageAmount = 10;
    public string Target;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Target)) 
        {
            HealthManager HealthManager = GetComponent<HealthManager>(); 
            HealthManager.TakeDamage(damageAmount);
            Destroy(other.gameObject);
        }
   }

 
}
