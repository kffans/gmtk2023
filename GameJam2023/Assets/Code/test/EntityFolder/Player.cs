using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Rigidbody2D thisRigidBody;
	void Start()
    {
        thisRigidBody = this.GetComponent<Rigidbody2D>();
		Speed = 400f;        
    }
    

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(moveHorizontal, moveVertical);
        //transform.Translate(movement * Speed * Time.deltaTime);
        thisRigidBody.MovePosition(thisRigidBody.position + movement * Speed * Time.fixedDeltaTime);// * Speed * Time.deltaTime);
    }
}
