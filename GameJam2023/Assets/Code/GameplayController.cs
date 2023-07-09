using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject DisplayTextObject;
	public static GameObject[] ArtObjects;
	
	public void Awake()
	{
		UpdateArtObjects();
	}

    public void Start()
    {
        StartCoroutine(HiddenTimer());
    }
	
	public static void UpdateArtObjects()
	{
		ArtObjects = GameObject.FindGameObjectsWithTag("ART");
	}

    public IEnumerator HiddenTimer()
    {
		yield return new WaitForSeconds(1f);
		DisplayText.ChangeDisplayText("Ahh, a truly fine day to get a cuppa...! *slurp*", 180, new Color32(252, 161, 3, 255));
		yield return new WaitForSeconds(5f);
		DisplayText.ChangeDisplayText("Get that bastard!", 180, new Color32(255, 255, 255, 255));
		
		yield return new WaitForSeconds(20f);
		//Enemy.ChangeTarget();
		DisplayText.ChangeDisplayText("Gah! It's invulnerable!!!", 80, new Color32(255, 255, 255, 255));
		yield return new WaitForSeconds(2f);
		DisplayText.ChangeDisplayText("Attack its furniture to weaken the monster... emotionally!", 120, new Color32(255, 255, 255, 255)); //at the end the say, "yeah that's a good idea"
		yield return new WaitForSeconds(2f);
		DisplayText.ChangeDisplayText("NOOO!!!", 40, new Color32(252, 161, 3, 255));
		
		yield return new WaitForSeconds(5f);
		DisplayText.ChangeDisplayText("Come on, snatch its crown! Quick!", 120, new Color32(255, 255, 255, 255));
		
		//Event.Blackout();
		yield return new WaitForSeconds(1f);
		DisplayText.ChangeDisplayText("Want only my crown? Should have said so from the beginning...", 180, new Color32(252, 161, 3, 255));
		
		yield return new WaitForSeconds(5f);
		DisplayText.ChangeDisplayText("...thank you... WE'RE RICH!!! BALLADS WILL TELL OF THIS COURAGEOUS TALE! Let's go home lads.", 270, new Color32(255, 255, 255, 255));
    }
}