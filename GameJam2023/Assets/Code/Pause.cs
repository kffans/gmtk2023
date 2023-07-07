using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
	public static bool isPausable = true;
	
	public GameObject pauseObject;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
    }
	
	public void PauseGame()
	{
		if(isPausable){
			isPaused = !isPaused;
			if(isPaused)
			{
				Time.timeScale = 1f;
			}
			else
			{
				Time.timeScale = 0f;
			}
			pauseObject.SetActive(!isPaused);
		}
	}
}
