using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private float speed;
    private float distanceTraveled; // ����� ���������� ��� ������������ ����������� ����������
    public float maxDistance = 20f; // ������������ ����������, ����� �������� ������ �����������

    public void SetProperties(float projectileSpeed)
    {
        speed = projectileSpeed;
    }

    void Update()
    {
        float distance = speed * Time.deltaTime; // ����������, ���������� �� ����
        distanceTraveled += distance; // ����������� ����� ���������� ����������
        transform.position += transform.forward * speed * Time.deltaTime;

        if (distanceTraveled >= maxDistance) // ���������, ������ �� ������ ������������� ����������
        {
            Destroy(gameObject); // ���� ��, ���������� ������
        }
    }
}
