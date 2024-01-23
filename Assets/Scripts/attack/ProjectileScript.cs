using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private float speed;
    private float distanceTraveled; // новая переменная для отслеживания пройденного расстояния
    public float maxDistance = 20f; // максимальное расстояние, после которого снаряд уничтожится

    public void SetProperties(float projectileSpeed)
    {
        speed = projectileSpeed;
    }

    void Update()
    {
        float distance = speed * Time.deltaTime; // расстояние, пройденное за кадр
        distanceTraveled += distance; // увеличиваем общее пройденное расстояние
        transform.position += transform.forward * speed * Time.deltaTime;

        if (distanceTraveled >= maxDistance) // проверяем, достиг ли снаряд максимального расстояния
        {
            Destroy(gameObject); // если да, уничтожаем снаряд
        }
    }
}
