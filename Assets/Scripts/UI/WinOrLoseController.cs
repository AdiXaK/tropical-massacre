using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLoseController : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
	[SerializeField] GameObject loseScreen;

	bool playerIsAlive;

	private void Start()
	{
		playerIsAlive = true;
		Time.timeScale = 1;
	}

	public void ShowWinScreen()
    {
        if (playerIsAlive)
		{
			winScreen.SetActive(true);
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None; 
			Cursor.visible = true;
		}
			
        else print("Player is dead you can't show win screen");
    }

	public void ShowLoseScreen()
	{
		playerIsAlive = false;
		loseScreen.SetActive(true);
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void ToMenu()
	{
		SceneManager.LoadScene(0);
	}
}
