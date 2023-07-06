using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Event : MonoBehaviour
{
    public static Event ThisEvent;
	
	private static Canvas Canvas;
	private static int CamCount = 1;
	public static Camera[] Cam = new Camera[CamCount];
	//Cam[0] - Main Camera
	
	private static int FrameRate = 60;
	
	public static int CanvasHeight = 1080;
	public static int CanvasWidth = 1920;
	public static Vector3 CanvasVectorHalved;
	
	public void Start(){
		ThisEvent = this;
		Application.targetFrameRate = FrameRate;
		EventInit();
		SetCameras();
	}

    public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		//someHeldObject.position = Input.mousePosition - CanvasVectorHalved; //
    }
	
	private static void EventInit(){
		CanvasVectorHalved = new Vector3(Event.CanvasWidth/2, Event.CanvasHeight/2, 0);
		Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		
		Cam[0] = GameObject.Find("MainCamera").GetComponent<Camera>();

		//somethingPrefab = Resources.Load("Prefabs/something") as GameObject;
	}
	
	public static void SetCameras(){ //sets the camera to the main one
		Cam[0].gameObject.SetActive(true);
		Cam[0].enabled = true;
		for(int i=1; i<CamCount; i++){
			Cam[i].gameObject.SetActive(false);
			Cam[i].enabled = false;
		}
		Canvas.worldCamera = Cam[0];
	}
	
	public static void ChangeCameras(int CamID){ //changes between specified camera with certain id, to main camera; back and forth
		Cam[0].gameObject.SetActive(!Cam[0].enabled);
		Cam[0].enabled = !Cam[0].enabled;
		
		Cam[CamID].gameObject.SetActive(!Cam[CamID].enabled);
		Cam[CamID].enabled = !Cam[CamID].enabled;

		if(Cam[0].enabled) Canvas.worldCamera = Cam[0];
		else Canvas.worldCamera = Cam[CamID];
	}
	
	
	
	public static void Fade(GameObject objectImage, int durationInFrames, int fadeDirection) //example: Fade(this.gameObject, 60, -1); -object becomes transparent after 60 frames (1 second)
	{ 																						//fadeDirection is either -1 or 1
		if(objectImage.GetComponent<Image>() != null || objectImage.GetComponent<RawImage>() != null)
			ThisEvent.StartCoroutine(Event.FadeCoroutine(objectImage, durationInFrames, fadeDirection));
	}
	
	private static IEnumerator FadeCoroutine(GameObject objectImage, int time, int direction){
		Color colorDiff = new Color(0f,0f,0f,1f/time);
		
		if(objectImage.GetComponent<Image>() != null){
			Image fadeImage = objectImage.GetComponent<Image>();
			for(int i=0; i<=time; i++){
				fadeImage.color += direction * colorDiff;
				if(direction == -1 && fadeImage.color.a==0) break;
				if(direction == 1  && fadeImage.color.a==255) break;
				yield return null;
			}
		}
		else if(objectImage.GetComponent<RawImage>() != null){
			RawImage fadeImage = objectImage.GetComponent<RawImage>();
			for(int i=0; i<=time; i++){
				fadeImage.color += direction * colorDiff;
				if(direction == -1 && fadeImage.color.a==0) break;
				if(direction == 1  && fadeImage.color.a==255) break;
				yield return null;
			}
		}
		yield return null;
	}
}