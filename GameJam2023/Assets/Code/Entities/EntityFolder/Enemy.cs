using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
	public int health;
	public bool canFollow = true;
	public GameObject[] objectsToFollow;
	private bool isFlipped = false;
	public float pushResistance;
   

    public void Follow()
	{
        Vector2 direction = targetObject.transform.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
		
        
		thisRigidbody.MovePosition(thisRigidbody.position + normalizedDirection * speed * Time.fixedDeltaTime * Event.IsometricVector);
		
		if (direction.x < 0f && !isFlipped)
    	{
			Event.FlipY(this.GetComponent<Transform>());
			isFlipped = true;
    	}
    	else if (direction.x > 0f && isFlipped)
    	{
			Event.FlipY(this.GetComponent<Transform>());
			isFlipped = false;
    	}
	}
	
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
		Vector2 direction = transform.position - GameObject.Find("Player").transform.position;
		Event.Move(this.gameObject, pushResistance, 20, direction);
		StartCoroutine(WaitForFollow(60));
	}
}