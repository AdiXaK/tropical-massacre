using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float remaingTime;
    [SerializeField] WinOrLoseController winOrLoseController;

	// Update is called once per frame
	void Update()
    {
        if (remaingTime > 0)
        {
            remaingTime -= Time.deltaTime;
        }
        else if (remaingTime < 0)
        {
            remaingTime = 0;
            winOrLoseController.ShowWinScreen();
        }

        int minutes = Mathf.FloorToInt(remaingTime / 60);
        int seconds = Mathf.FloorToInt(remaingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
