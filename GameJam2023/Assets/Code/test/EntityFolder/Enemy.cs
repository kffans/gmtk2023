using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private GameObject targetObject;
    private Rigidbody2D thisRigidBody;
   
    void Start()
    {
        targetObject = GameObject.Find("Player");
        speed = 250;
        thisRigidBody = this.GetComponent<Rigidbody2D>();
        Event.Fade(this.gameObject, 60, 1);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (targetObject != null)
        {
            Follow(targetObject);
        }
    }

    void Follow(GameObject myObject)
    {
        Vector2 direction = myObject.transform.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
       //transform.position = NewPosition;
        thisRigidBody.MovePosition(thisRigidBody.position + normalizedDirection * speed * Time.fixedDeltaTime);// * Speed * Time.deltaTime);
    }
}