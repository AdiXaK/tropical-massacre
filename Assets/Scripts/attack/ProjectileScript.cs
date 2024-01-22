using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private float speed;

    public void SetProperties(float projectileSpeed)
    {
        speed = projectileSpeed;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}