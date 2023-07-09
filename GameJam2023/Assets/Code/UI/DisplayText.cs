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
	
	
	public static void ChangeDisplayText(string text, int length, Color color){
		Display.color = color;
		Display.text = text;

		ThisDisplay.StartCoroutine(DisplayText.TextFade(length));
	}
	private static IEnumerator TextFade(int length){
		Color change = new Color(0f,0f,0f,1f/20);
		
		for(int i=0; i<length; i++)
		{
			do{ yield return null; }while(Event.CheckPause());
		}
		for(int i=0; i<20; i++)
		{
			Display.color -= change;
			do{ yield return null; }while(Event.CheckPause());
		}
		
		Display.color = new Color(1f,1f,1f,0f);
	}
}
