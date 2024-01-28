using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public HealthManager healthManager;
    public DamageOnCollision damageOnCollision;
    public PlayerShooting playerShooting;
    public Image expFill;
	public GameObject powerUp;

	public int killsCount = 0;
    public int upgradeCount = 0;
    public int maxKillsForUpgrade = 10;

	private void Start()
	{
        GlobalEventManager.OnEnemyDie += IncreaseKillsCount;
	}

	private void OnDestroy()
	{
		GlobalEventManager.OnEnemyDie -= IncreaseKillsCount;
	}

	public void IncreaseKillsCount()
    {
        killsCount++;

        expFill.fillAmount = (float)killsCount / maxKillsForUpgrade;

        if (killsCount >= maxKillsForUpgrade)
        {
            ResetKillsCount();
            UpgradePlayer();
        }
    }

    public void ResetKillsCount()
    {
        killsCount = 0;
    }

    private void UpgradePlayer()
    {
        upgradeCount++;
        maxKillsForUpgrade = (int)((float)maxKillsForUpgrade * 1.5f);

        //âîññòàíîâëåíèå õï
        healthManager.currentHealth = healthManager.maxHealth;

        // Óëó÷øåíèå óðîíà
        //damageOnCollision.damageAmount += 5; //Нас начинают быстрее убивать, так нужно? Если да раскоментируй

        powerUp.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UpgradeMaxHealth()
    {
        // Óëó÷øåíèå ìàêñèìàëüíîãî çäîðîâüÿ è òåêóùåãî çäîðîâüÿ
        healthManager.maxHealth += 10;
        healthManager.currentHealth = healthManager.maxHealth;
		powerUp.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}

    public void UpgradeDamage()
    {
        // Íàõîäèì âñå èãðîâûå îáúåêòû ñ çàäàííûìè òåãàìè
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("crocodile");
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("gorilla")).ToArray();
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("papuas")).ToArray();
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("pirate")).ToArray();

        // Îáíîâëÿåì óðîí â êîìïîíåíòàõ DamageOnCollision íà âñåõ íàéäåííûõ îáúåêòàõ
        foreach (GameObject enemy in enemies)
        {
            DamageOnCollision damageComponent = enemy.GetComponent<DamageOnCollision>();
            if (damageComponent != null)
            {
                damageComponent.damageAmount += 5;
            }
        }

		powerUp.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}
    public void UpgradeAttackSpeed()
    {
        // Óëó÷øåíèå ñêîðîñòðåëüíîñòè
        playerShooting.attackSpeed += 2;

		powerUp.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}
}