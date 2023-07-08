using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Event : MonoBehaviour
{
    public static Event ThisEvent;
	
	private static Canvas ThisCanvas;
	private static int CamCount = 1;
	public static Camera[] Cam = new Camera[CamCount];
	//Cam[0] - Main Camera
	
	public static bool isPaused = false;
	public static bool isPausable = true;
	public GameObject pauseObject;
	private Quaternion rotate;
	
	private static float[] coeffs = new float[] { 4f, 0f, 1f, -1f }; //Move: coefficients of f(x)
	private static float endPoint = 2f; //Move: a point where we want the animation to end (e.g. f(x) intersects the x-axis)
	
	private static int FrameRate = 60;
	
	public static int CanvasHeight = 1080;
	public static int CanvasWidth = 1920;
	public static Vector3 CanvasVectorHalved;
	public static Vector2 IsometricVector;
	
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		ThisEvent = this;
		Application.targetFrameRate = FrameRate;
		EventInit();
		SetCameras();
		//someHeldObject.position = Input.mousePosition - CanvasVectorHalved; //in update, when holding an object with mouse
	}
	
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
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}
			pauseObject.SetActive(isPaused);
		}
	}
	
	private static void EventInit()
	{
		CanvasVectorHalved = new Vector3(Event.CanvasWidth/2, Event.CanvasHeight/2, 0);
		IsometricVector = new Vector2(1f, 0.5f);
		ThisCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		
		Cam[0] = GameObject.Find("MainCamera").GetComponent<Camera>();

		//somethingPrefab = Resources.Load("Prefabs/something") as GameObject;
	}
	
	public static bool CheckPause(){
		if(isPausable)
			return isPaused;
		else
			return false;
	}
	
	
///////////////////////////////
	public static void SetCameras() //sets the camera to the main one
	{
		Cam[0].gameObject.SetActive(true);
		Cam[0].enabled = true;
		for(int i=1; i<CamCount; i++){
			Cam[i].gameObject.SetActive(false);
			Cam[i].enabled = false;
		}
		ThisCanvas.worldCamera = Cam[0];
	}
	public static void ChangeCameras(int CamID) //changes between specified camera with certain id, to main camera; back and forth
	{
		Cam[0].gameObject.SetActive(!Cam[0].enabled);
		Cam[0].enabled = !Cam[0].enabled;
		
		Cam[CamID].gameObject.SetActive(!Cam[CamID].enabled);
		Cam[CamID].enabled = !Cam[CamID].enabled;

		if(Cam[0].enabled) ThisCanvas.worldCamera = Cam[0];
		else ThisCanvas.worldCamera = Cam[CamID];
	}
///////////////////////////////
	
	
	
///////////////////////////////
	public static void Fade(GameObject objectImage, int durationInFrames, int fadeDirection) //example: Event.Fade(this.gameObject, 60, -1); -object becomes transparent after 60 frames (1 second)
	{ 																						//fadeDirection is either -1 or 1
		if(objectImage.GetComponent<Image>() != null || objectImage.GetComponent<RawImage>() != null)
			ThisEvent.StartCoroutine(Event.FadeCoroutine(objectImage, durationInFrames, fadeDirection));
	}
	private static IEnumerator FadeCoroutine(GameObject objectImage, int time, int direction)
	{
		Color colorDiff = new Color(0f,0f,0f,1f/time);
		
		if(objectImage.GetComponent<Image>() != null)
		{
			Image fadeImage = objectImage.GetComponent<Image>();
			for(int i=0; i<=time; i++)
			{
				fadeImage.color += direction * colorDiff;
				if(direction == -1 && fadeImage.color.a==0) break;
				if(direction == 1  && fadeImage.color.a==255) break;
				
				do{ yield return null; }while(CheckPause());
			}
		}
		else if(objectImage.GetComponent<RawImage>() != null)
		{
			RawImage fadeImage = objectImage.GetComponent<RawImage>();
			for(int i=0; i<=time; i++)
			{
				fadeImage.color += direction * colorDiff;
				if(direction == -1 && fadeImage.color.a==0) break;
				if(direction == 1  && fadeImage.color.a==255) break;
				
				do{ yield return null; }while(CheckPause());
			}
		}
	}
///////////////////////////////
	
	
	
	
///////////////////////////////
	private static IEnumerator AnimCoroutine(Transform objectTransform, float val, int time, Vector3 vectorDir, Action<Transform, float, Vector3> function)
	{
		float n = endPoint/time;
		
		float integralFT = 0f;
		for(int i=0; i<coeffs.Length; i++)
			integralFT += coeffs[i]/(i+1) * Mathf.Pow(n*time, i+1);
		
		float m = val/integralFT;
		
		float integralDiff = 0f;
		for(int j = 0; j<time; j++)
		{
			for(int i=0; i<coeffs.Length; i++)
				integralDiff += coeffs[i]/(i+1) * (Mathf.Pow(n*(j+1), i+1) - Mathf.Pow(n*j, i+1));
			integralDiff *= m;
			
			function(objectTransform, integralDiff, vectorDir);
			
			integralDiff = 0f;
			do{ yield return null; }while(CheckPause());
		}
	}
	public static void AnimFunction(float[] newCoeffs, float newEndPoint) //example: Event.AnimFunction(new float[] { 0f, 0f, 4f, -1f }, 4f); -changes to a function:  0 + 0*x + 4*x^2 + (-1)*x^3
	{
		coeffs = newCoeffs;
		endPoint = newEndPoint;
	}
///////////////////////////////
	
	
///////////////////////////////
	public static void Move(GameObject objectTransform, float distance, int durationInFrames, Vector2 vectorDirection)
	{
		Vector3 vectorDir = vectorDirection;
		ThisEvent.StartCoroutine(Event.AnimCoroutine(objectTransform.GetComponent<Transform>(), distance, durationInFrames, vectorDir, Event.MoveBy));
	}
	public static void MoveBy(Transform objectTransform, float val, Vector3 vectorDir)
	{
		objectTransform.position += val * vectorDir;
	}
///////////////////////////////


///////////////////////////////
	public static void Rotate(GameObject objectTransform, float angle, int durationInFrames, Vector2 vectorDirection)
	{
		Vector3 vectorDir = vectorDirection;
		Debug.Log(vectorDir);
		ThisEvent.StartCoroutine(Event.AnimCoroutine(objectTransform.GetComponent<Transform>(), angle, durationInFrames, vectorDir, Event.RotateBy));
	}
	public static void RotateBy(Transform objectTransform, float val, Vector3 vectorDir)
	{
		objectTransform.Rotate(0f,0f,val);
	}
	public static void RotateTo(Transform objectTransform, float val, Vector2 vectorDirection)
	{
		if(vectorDirection != Vector2.zero)
		{
			Vector3 vectorDir = vectorDirection;
			objectTransform.rotation = Quaternion.LookRotation(vectorDir.normalized); 
		}
		else
			objectTransform.rotation = Quaternion.Euler(0f, 0f, val);
	}
///////////////////////////////

}