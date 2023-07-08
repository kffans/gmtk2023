using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    public GameObject targetObject;
	public int health;
	public bool canFollow= true;
	public GameObject[] objectsToFollow;

   

    public void Follow()
	{
        Vector2 direction = targetObject.transform.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
		
        thisRigidbody.MovePosition(thisRigidbody.position + normalizedDirection * speed * Time.fixedDeltaTime * Event.IsometricVector);// * Speed * Time.deltaTime);
	}
	
	public void SearchForTarget(GameObject[] objectsToFollow)
	{
    	GameObject closestObject = null;
    	float closestDistance = Mathf.Infinity;
    	Vector2 currentPosition = transform.position;
		foreach (GameObject obj in objectsToFollow)
		{
			float distance = Vector3.Distance(obj.transform.position, currentPosition); 
			if (distance < closestDistance)
			{
				closestObject = obj;
				closestDistance = distance;
			}
		}
		if (closestObject != null)
		{
			Debug.Log("Najbliższy obiekt: " + closestObject.name);
			targetObject = closestObject;
		}
		else
		{
			// Brak obiektów o tagu "ART"
			Debug.Log("Brak obiektów o tagu 'ART'");
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
}