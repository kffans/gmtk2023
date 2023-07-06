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
	
	private static float[] coeffs = new float[] { 4f, 0f, 1f, -1f }; //Move: coefficients of f(x)
	private static float endPoint = 2f; //Move: a point where we want the animation to end (e.g. f(x) intersects the x-axis)
	
	private static int FrameRate = 60;
	
	public static int CanvasHeight = 1080;
	public static int CanvasWidth = 1920;
	public static Vector3 CanvasVectorHalved;
	public GameObject optionsObject;
	GameObject canvasObject;
	public GameObject buttonObject;

	bool menuON = false;
	
	void Start()
	{
		ThisEvent = this;
		Application.targetFrameRate = FrameRate;
		EventInit();
		SetCameras();
		optionsObject = GameObject.Find("Options").gameObject;
		buttonObject = GameObject.Find("Back").gameObject;
		canvasObject = this.gameObject;

	}

    void Update()
	{
		//if(Input.GetKeyDown(KeyCode.Escape))
		//	Application.Quit();
		//someHeldObject.position = Input.mousePosition - CanvasVectorHalved; //
		if (Input.GetKeyDown(KeyCode.Escape) && !menuON)
		{
			menuON = true;
			StopGame();
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && menuON)
		{
			menuON = false;
			PlayGame();
		}
        buttonObject.GetComponent<Button>().onClick.AddListener(PlayGame);
        
    }
	
	void StopGame()
    {
        Time.timeScale = 0f; 
        Debug.Log("Gra została zatrzymana!");
		optionsObject.SetActive(true);
		canvasObject.SetActive(false);
    }

	void PlayGame()
	{
		Time.timeScale = 1;
		Debug.Log("Gra została uruchomiona!");
		optionsObject.SetActive(false);
		this.canvasObject.SetActive(true);
	}

	
	private static void EventInit()
	{
		CanvasVectorHalved = new Vector3(Event.CanvasWidth/2, Event.CanvasHeight/2, 0);
		Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		
		Cam[0] = GameObject.Find("MainCamera").GetComponent<Camera>();

		//somethingPrefab = Resources.Load("Prefabs/something") as GameObject;
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
		Canvas.worldCamera = Cam[0];
	}
	public static void ChangeCameras(int CamID) //changes between specified camera with certain id, to main camera; back and forth
	{
		Cam[0].gameObject.SetActive(!Cam[0].enabled);
		Cam[0].enabled = !Cam[0].enabled;
		
		Cam[CamID].gameObject.SetActive(!Cam[CamID].enabled);
		Cam[CamID].enabled = !Cam[CamID].enabled;

		if(Cam[0].enabled) Canvas.worldCamera = Cam[0];
		else Canvas.worldCamera = Cam[CamID];
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
				yield return null;
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
				yield return null;
			}
		}
		yield return null;
	}
///////////////////////////////
	
	
	
///////////////////////////////
	public static void Move(GameObject objectTransform, float distance, int durationInFrames, Vector2 vectorDirection)
	{
		Vector3 vectorDir = vectorDirection;
		ThisEvent.StartCoroutine(Event.MoveCoroutine(objectTransform.GetComponent<Transform>(), distance, durationInFrames, vectorDir));
	}
	public static void MoveFunction(float[] newCoeffs, float newEndPoint) //example: Event.MoveFunction(new float[] { 0f, 0f, 4f, -1f }, 4f); -changes to a function:  0 + 0*x + 4*x^2 + (-1)*x^3
	{
		coeffs = newCoeffs;
		endPoint = newEndPoint;
	}
	private static IEnumerator MoveCoroutine(Transform objectTransform, float d, int t, Vector3 vectorDir)
	{
		float n = endPoint/t;
		
		float integralFT = 0f;
		for(int i=0; i<coeffs.Length; i++)
			integralFT += coeffs[i]/(i+1) * Mathf.Pow(n*t, i+1);
		
		float m = d/integralFT;
		
		float integralDiff = 0f;
		for(int j = 0; j<t; j++)
		{
			for(int i=0; i<coeffs.Length; i++)
				integralDiff += coeffs[i]/(i+1) * (Mathf.Pow(n*(j+1), i+1) - Mathf.Pow(n*j, i+1));
			integralDiff *= m;
			
			objectTransform.position += vectorDir * integralDiff;
			integralDiff = 0f;
			yield return null;
		}
	}
///////////////////////////////

}