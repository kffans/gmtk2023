using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
	public int health;
	public bool canFollow = true;
	public GameObject[] objectsToFollow;
	public float pushResistance;
	
	public IEnumerator WaitForFollow(int time)
	{
		canFollow=false;
		for(int i=0; i<time; i++)
		{
			do{ yield return null; }while(Event.CheckPause());
		}
		canFollow=true;
	}
	
	public void ChangeTarget(string target, string typeOfEnemy)
	{
		if(target=="ART")
		{
			SearchForTarget(GameplayController.ArtObjects);
		}
		else if(target=="Player")
		{
			
		}
		else if(target=="Minion")
		{
			
		}
	}
	
	public void PushedAway(){
		Vector2 direction = transform.position - GameplayController.PlayerObject.transform.position;
		Event.Move(this.gameObject, pushResistance, 20, direction);
		StartCoroutine(WaitForFollow(60));
	}
	
	void OnDestroy()
	{
		GameplayController.UpdateEnemies();
	}
}