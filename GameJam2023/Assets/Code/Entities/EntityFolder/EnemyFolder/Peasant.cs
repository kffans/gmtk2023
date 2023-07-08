using System.Collections;
using UnityEngine;

public class Peasant : Enemy
{
	
	// Start is called before the first frame update
    void Start()
    {
        objectsToFollow = GameObject.FindGameObjectsWithTag("ART");
        speed = 400f;
        thisRigidbody = this.GetComponent<Rigidbody2D>();
		
		//Event.Move(this.gameObject, 300f, 60, Vector2.up);
		//StartCoroutine(WaitForFollow(60));
        
    }

    void FixedUpdate()
    {
        SearchForTarget(objectsToFollow);
		if (targetObject != null && canFollow)
        {
            Follow();
        }
		
    }
}
