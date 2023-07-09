using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public GameObject DisplayTextObject;
	public static GameObject[] ArtObjects;
	public static GameObject[] EnemyObjects;
	public static GameObject[] MinionObjects;
	public static GameObject[] PlayerObject = new GameObject[1];
	public static GameObject[] EnemyGlobalTarget;
	public static string EnemyGlobalTargetName;
	public static bool CanDestroyFurniture=false;
	public static bool StartWave=false;
	
	public void Awake()
	{
		UpdateArtObjects();
		PlayerObject[0] = GameObject.Find("Player");
		EnemyGlobalTarget = PlayerObject;
	}

    public void Start()
    {
        StartCoroutine(GameplayEvents());
    }
	
	public static void UpdateArtObjects()
	{
		ArtObjects = GameObject.FindGameObjectsWithTag("ART");
	}
	public static void UpdateEnemies()
	{
		EnemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	public void StartWaveFunc()
	{
		StartWave = true;
		GameObject.Find("StartWave").gameObject.SetActive(false);
		Event.Fade(GameObject.Find("LHand"), 15, 1);
		Event.Fade(GameObject.Find("skull1"), 15, 1);
		Event.Fade(GameObject.Find("skull2"), 15, 1);
		Event.Fade(GameObject.Find("skull3"), 15, 1);
		Event.Fade(GameObject.Find("RHand"), 15, 1);
		Event.Move(GameObject.Find("Score"), 200f, 15, Vector2.down);
	}

    public IEnumerator GameplayEvents()
    {
		yield return new WaitForSeconds(1f);
		DisplayText.ChangeDisplayText("Ahh, a truly fine day to get a cuppa...!", 180, new Color32(252, 161, 3, 255));
		//wait for button
		while(!StartWave)
			do{ yield return null; }while(Event.CheckPause());
		
		//Music.PlayMusic(2);
		DisplayText.ChangeDisplayText("Get that foul beast!", 180, new Color32(255, 255, 255, 255));
		
		
		
		
		for(int i=0; i<5*60; i++){ //czas az beda uderzac furniture
			
			do{ yield return null; }while(Event.CheckPause());
		}
		

		//Enemy.ChangeTarget();
		DisplayText.ChangeDisplayText("Gah! It's invulnerable!!!", 80, new Color32(255, 255, 255, 255));
		yield return new WaitForSeconds(2f);
		DisplayText.ChangeDisplayText("Attack its furniture to weaken the monster... emotionally!", 120, new Color32(255, 255, 255, 255)); //at the end the say, "yeah that's a good idea"
		yield return new WaitForSeconds(3f);
		DisplayText.ChangeDisplayText("NOOO!!! THAT'S ALL I HAVE!", 120, new Color32(252, 161, 3, 255));
		

		CanDestroyFurniture=true;
		for(int i=0; i<10*60; i++){ //czas az beda uderzac furniture
			EnemyGlobalTarget = ArtObjects;
			do{ yield return null; }while(Event.CheckPause());
		}
		
		
		EnemyGlobalTarget = PlayerObject;
		DisplayText.ChangeDisplayText("Ugh come on! Snatch its crown! Quick!", 120, new Color32(255, 255, 255, 255));
		
		Event.Fade(Event.BlackoutImage, 30, 1);
		yield return new WaitForSeconds(3f);
		Music.SetVolume(0);
		DisplayText.ChangeDisplayText("You want only my crown? Should have said so from the beginning...", 180, new Color32(252, 161, 3, 255));
		
		yield return new WaitForSeconds(5f);
		DisplayText.ChangeDisplayText("WE'RE RICH!!! BALLADS WILL TELL OF THIS COURAGEOUS TALE! Let's go home lads.", 270, new Color32(255, 255, 255, 255));
		yield return new WaitForSeconds(5f);
		Destroy(GameObject.Find("MusicController"));
		
		SceneManager.LoadScene(2);
    }
}