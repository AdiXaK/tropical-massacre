using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public HealthManager healthManager;
    public DamageOnCollision damageOnCollision;
    public PlayerShooting playerShooting;

    public int killsCount = 0;
    public int upgradeCount = 0;
    public int maxKillsForUpgrade = 10;


    public void IncreaseKillsCount()
    {
        killsCount++;

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

        //�������������� ��
        healthManager.currentHealth = healthManager.maxHealth;

        // ��������� �����
        damageOnCollision.damageAmount += 5;
    }

    public void UpgradeMaxHealth()
    {
        // ��������� ������������� �������� � �������� ��������
        healthManager.maxHealth += 10;
        healthManager.currentHealth = healthManager.maxHealth;
    }

    public void UpgradeDamage()
    {
        // ������� ��� ������� ������� � ��������� ������
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("crocodile");
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("gorilla")).ToArray();
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("papuas")).ToArray();
        enemies = enemies.Concat(GameObject.FindGameObjectsWithTag("pirate")).ToArray();

        // ��������� ���� � ����������� DamageOnCollision �� ���� ��������� ��������
        foreach (GameObject enemy in enemies)
        {
            DamageOnCollision damageComponent = enemy.GetComponent<DamageOnCollision>();
            if (damageComponent != null)
            {
                damageComponent.damageAmount += 5;
            }
        }
    }
    public void UpgradeAttackSpeed()
    {
        // ��������� ����������������
        playerShooting.attackSpeed += 2;
    }
}