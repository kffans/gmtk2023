using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject DisplayTextObject;
	public static GameObject[] ObjectsToFollow;
	
	public void Awake()
	{
		UpdateObjectsToFollow();
	}

    public void Start()
    {
        StartCoroutine(ShowTextAfterDelay());
    }
	
	public static void UpdateObjectsToFollow()
	{
		ObjectsToFollow = GameObject.FindGameObjectsWithTag("ART");
	}

    public IEnumerator ShowTextAfterDelay()
    {
        yield return new WaitForSeconds(4f);
    }
}