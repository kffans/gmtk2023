using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{
    public Rigidbody2D thisRigid;
	
	// Start is called before the first frame update
    void Start()
    {
        speed = 400f;
		targetObject = GameObject.Find("Player");
        //thisRigid = this.GetComponent<Rigidbody2D>();

		Event.Move(this.gameObject, 400f, 120, Vector2.left);
    }

    void Update()
    {
        if (targetObject != null)
        {
            //Follow(targetObject);
        }
    }
	/*public void Follow()
    {
        Vector2 direction = targetObject.transform.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
		
        //thisRigid.MovePosition(thisRigidBody.position + normalizedDirection * speed * Time.fixedDeltaTime);// * Speed * Time.deltaTime);
    }*/
}
