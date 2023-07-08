using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : Entity
{
    private GameObject targetObject;
	private int health;
   
    void Start()
    {
		targetObject = GameObject.Find("Player");
        //thisRigidBody = this.GetComponent<Rigidbody2D>();

        Event.Move(this.gameObject, 400f, 120, Vector2.left);
    }

    void FixedUpdate()
    {
        if (targetObject != null)
        {
            //Follow(targetObject);
        }
    }

    void Follow(GameObject myObject)
    {
        //Vector2 direction = myObject.transform.position - transform.position;
        //Vector2 normalizedDirection = direction.normalized;
		
        //thisRigidBody.MovePosition(thisRigidBody.position + normalizedDirection * speed * Time.fixedDeltaTime);// * Speed * Time.deltaTime);
    }
}