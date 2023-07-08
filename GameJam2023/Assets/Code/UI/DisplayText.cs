using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    private static TMPro.TextMeshProUGUI Display;
	private static DisplayText ThisDisplay;
	
	public void Start(){
		Display = GameObject.Find(this.name).GetComponent<TMPro.TextMeshProUGUI>();
		ThisDisplay = this;
	}
	
	
	public static void ChangeDisplayText(string text){
		Display.color = new Color(1f,1f,1f,1f);
		Display.text = text;
		ThisDisplay.StartCoroutine(DisplayText.TextFade());
	}
	private static IEnumerator TextFade(){
		for(int i=0; i<240; i++)
		{
			do{ yield return null; }while(Event.CheckPause());
		}
		Display.color = new Color(1f,1f,1f,0f);
	}
}
