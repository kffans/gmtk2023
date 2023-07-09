using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public bool StartWave=false;
	
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
		
		
		CanDestroyFurniture=true;
		DisplayText.ChangeDisplayText("NOOO!!!", 40, new Color32(252, 161, 3, 255));
		

		
		for(int i=0; i<10*60; i++){ //czas az beda uderzac furniture
			EnemyGlobalTarget = ArtObjects;
			do{ yield return null; }while(Event.CheckPause());
		}
		
		
		EnemyGlobalTarget = PlayerObject;
		DisplayText.ChangeDisplayText("Ugh come on! Snatch its crown! Quick!", 120, new Color32(255, 255, 255, 255));
		
		//Event.Blackout();
		yield return new WaitForSeconds(3f);
		DisplayText.ChangeDisplayText("Want only my crown? Should have said so from the beginning...", 180, new Color32(252, 161, 3, 255));
		
		yield return new WaitForSeconds(5f);
		DisplayText.ChangeDisplayText("...thank you... WE'RE RICH!!! BALLADS WILL TELL OF THIS COURAGEOUS TALE! Let's go home lads.", 270, new Color32(255, 255, 255, 255));
    }
}