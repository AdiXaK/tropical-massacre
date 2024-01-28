using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
	[SerializeField] WinOrLoseController winOrLoseController;

	void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GlobalEventManager.SendHPChanged();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (this.CompareTag("Player"))
        {
            winOrLoseController.ShowLoseScreen();
        }
        else
        {
          GlobalEventManager.SendEnemyDie();
          this.gameObject.SetActive(false);
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
