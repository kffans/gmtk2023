using System.Collections;
using UnityEngine;

public class Archer : Enemy
{
	
	// Start is called before the first frame update
    void Start()
    {
        speed = 300f;
		targetObject = GameplayController.PlayerObject[0];
        thisRigidbody = this.GetComponent<Rigidbody2D>();
		
		Event.Move(this.gameObject, 300f, 60, Vector2.up);
		StartCoroutine(WaitForFollow(60));

    }

    void FixedUpdate()
    {
        
		if (targetObject != null && canFollow)
        {
            Follow();
        }
		
    }
}
