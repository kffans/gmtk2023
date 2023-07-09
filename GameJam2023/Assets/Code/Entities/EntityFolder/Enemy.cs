using System.Collections;
using UnityEngine;

public abstract class Enemy : Entity
{
	public bool canFollow = true;
	public GameObject[] objectsToFollow;
	public float pushResistance;
	public static bool HasGlobalTargetChanged=true;
	
	public IEnumerator WaitForFollow(int time)
	{
		canFollow=false;
		for(int i=0; i<time; i++)
		{
			do{ yield return null; }while(Event.CheckPause());
		}
		canFollow=true;
	}
	
	public void PushedAway(){
		Vector2 direction = transform.position - GameplayController.PlayerObject[0].transform.position;
		Event.Move(this.gameObject, pushResistance, 20, direction);
		StartCoroutine(WaitForFollow(60));
	}
	
	public void Death()
	{
		canFollow = false;
		StartCoroutine(DeathCoroutine());
	}
	
	public IEnumerator DeathCoroutine()
	{
		for(int i=0; i<9; i++){
			this.transform.rotation = Quaternion.Euler(10f*i, 0f, 0f);
			do{ yield return null; } while(Event.CheckPause());
		}
		Destroy(this.gameObject);
	}
}