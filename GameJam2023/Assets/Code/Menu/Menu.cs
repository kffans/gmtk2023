using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
	private static Canvas Canvas;
	private static int CamCount = 3;
	private static Camera[] Cam = new Camera[CamCount];
	//Cam[0] - Main Camera,     Cam[1] - Settings Camera,     Cam[2] - Authors Camera
	
	private static int FrameRate = 60;
	
	public void Start(){
		//Music.PlayMusic(0);
		Application.targetFrameRate = FrameRate;
		
		
		Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		
		Cam[0] = GameObject.Find("MainCamera").GetComponent<Camera>();
		Cam[1] = GameObject.Find("OptionsCamera").GetComponent<Camera>();
		Cam[2] = GameObject.Find("AuthorsCamera").GetComponent<Camera>();
		
		Cam[0].gameObject.SetActive(true);
		Cam[0].enabled = true;
		for(int i=1; i<CamCount; i++){
			Cam[i].gameObject.SetActive(false);
			Cam[i].enabled = false;
		}
		Canvas.worldCamera = Cam[0];
	}
	
	public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	
	public void StartButton(){
		SceneManager.LoadScene(1);
		//Music.PlayMusic(1);
	}
	
	public void LeaveButton(){
		Application.Quit();
	}
	
	public void ChangeCamera(int camID){ //used by both LeaveButton and AuthorsButton
		Cam[0].gameObject.SetActive(!Cam[0].enabled);
		Cam[camID].gameObject.SetActive(!Cam[camID].enabled);
		Cam[0].enabled = !Cam[0].enabled;
		Cam[camID].enabled = !Cam[camID].enabled;

		if(Cam[0].enabled) Canvas.worldCamera = Cam[0];
		else Canvas.worldCamera = Cam[camID];
	}
}