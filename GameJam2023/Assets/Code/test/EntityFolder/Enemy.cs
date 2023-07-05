using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject TargetObject; 
    public Rigidbody2D thisRigidBody;
   
    void Start()
    {
        Debug.Log("Dupa");
        thisRigidBody = this.GetComponent<Rigidbody2D>();
		Event.Fade(this.gameObject, 60, 1);
    }

    void FixedUpdate()
    {
        if (TargetObject != null)
        {
            Follow(TargetObject);
        }
    }

    void Follow(GameObject myObject)
    {
        Vector2 Direction = myObject.transform.position - transform.position;
        Vector2 NormalizedDirection = Direction.normalized;
       //transform.position = NewPosition;
        thisRigidBody.MovePosition(thisRigidBody.position + NormalizedDirection * Speed * Time.fixedDeltaTime);// * Speed * Time.deltaTime);
    }
}