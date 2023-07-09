using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Entity : MonoBehaviour
{
    public Rigidbody2D thisRigidbody;
	public float speed;
	public GameObject targetObject;
	public int health;
	public bool isFlipped = false;
	
	public void SearchForTarget(GameObject[] objectsToFollow)
	{
    	GameObject closestObject = null;
    	float closestDistance = Mathf.Infinity;
    	Vector2 currentPosition = transform.position;
		if(objectsToFollow!=null){
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
				//Debug.Log("Najbliższy obiekt: " + closestObject.name);
				targetObject = closestObject;
			}
			else
			{
				// Brak obiektów o tagu "ART"
				//Debug.Log("Brak obiektów o tagu 'ART'");
			}
		}
	}
	
	public void Follow()
	{
        if(targetObject!=null){
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
	}
}
