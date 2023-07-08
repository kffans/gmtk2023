using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        speed = 400f;
		Event.FlipY(this.GetComponent<Transform>());
		Event.Move(this.gameObject, 400f, 120, Vector2.left);
		//Event.Move(GameObject.Find("MainCamera"), 100f, 60, new Vector2(2,-1).normalized);
		
		//Event.Rotate(this.gameObject, 180f, 60, Vector2.zero); 
		//Event.RotateTo(this.GetComponent<Transform>(), 0f, new Vector3(2f,-1f)); 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
       /* thisRigidbody.MovePosition(thisRigidbody.position + movement * speed * Time.fixedDeltaTime * Event.IsometricVector);*/
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Music.PlaySound("heat");
    }

    // called when the cube hits the floor
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Enemy>() != null)
        {
            
          
        }
    }

}