using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject authors;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowObject()
    {
        authors.SetActive(true);
    }

	public void HideObject()
	{
		authors.SetActive(false);
		
	}
}
