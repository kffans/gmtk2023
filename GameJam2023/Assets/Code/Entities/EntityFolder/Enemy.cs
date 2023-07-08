using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    public GameObject targetObject;
	public int health;
	public bool canFollow=true;
   

    public void Follow()
	{
        Vector2 direction = targetObject.transform.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
		
        thisRigidbody.MovePosition(thisRigidbody.position + normalizedDirection * speed * Time.fixedDeltaTime * Event.IsometricVector);// * Speed * Time.deltaTime);
	}
	
	public void ChangeTarget()
	{
		
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
}