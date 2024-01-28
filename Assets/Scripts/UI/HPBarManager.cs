using UnityEngine;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour
{
    public Image fillHP;
	public HealthManager playerHealth;

	private void Start()
	{
		GlobalEventManager.OnHpChanged += HPChenged;
	}

	private void OnDestroy()
	{
		GlobalEventManager.OnHpChanged -= HPChenged;
	}

	void HPChenged()
    {
 
        fillHP.fillAmount = (float)playerHealth.GetHealth() / playerHealth.maxHealth;
    }
}
