using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
	[SerializeField] AudioSource bgMusic;
    bool pause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			if (pause)
			{
				pause = !pause;
				bgMusic.Play();
				pauseMenu.SetActive(false);
				Time.timeScale = 1;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			else
			{
				pause = !pause;
				bgMusic.Pause();
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
        
    }
}
