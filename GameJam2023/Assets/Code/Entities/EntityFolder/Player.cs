using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    private Animator anim;

    private bool isFlipped = false;


    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        speed = 400f;
        anim = GetComponent<Animator>();
        
		//Event.Move(GameObject.Find("MainCamera"), 100f, 60, new Vector2(2,-1).normalized);
		
		//Event.Rotate(this.gameObject, 180f, 60, Vector2.zero); 
		//Event.RotateTo(this.GetComponent<Transform>(), 0f, new Vector3(2f,-1f)); 
    }

    void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        thisRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            thisRigidbody.velocity = new Vector2(0,100);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        thisRigidbody.MovePosition(thisRigidbody.position + movement * speed * Time.fixedDeltaTime * Event.IsometricVector);

        if (dirY >0f)
        {
            anim.SetBool("running",true);
            
        }
        else if(dirY <0f)
        {
            anim.SetBool("running", true);
        }

        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            if (!isFlipped)
            {
                Event.FlipY(this.GetComponent<Transform>());
                isFlipped = true;
            }
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            if (isFlipped)
            {
                Event.FlipY(this.GetComponent<Transform>());
                isFlipped = false;
            }
        }
        
        if(dirX == 0f && dirY == 0f)
        {
            anim.SetBool("running", false);
        }
        
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