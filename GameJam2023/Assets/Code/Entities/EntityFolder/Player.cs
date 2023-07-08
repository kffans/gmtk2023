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

    private bool isFighting = false;
	private int attackCooldown;
	private static int AttackCooldownValue = 40;
	
	private RectTransform thisRect;
	private static Vector2 NormalDimensions = new Vector2(305, 330);//610x660
	private static Vector2 AttackDimensions = new Vector2(435, 403);//870x806


    void Start()
    {
        thisRect = this.GetComponent<RectTransform>();
		thisRect.sizeDelta = NormalDimensions;
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
		
		if(attackCooldown != 0)
			attackCooldown--;
		
		
		if(!isFighting)
		{
			if (dirX > 0f){
				if (!isFlipped)
				{
					Event.FlipY(this.GetComponent<Transform>());
					isFlipped = true;
				}
			}
			else if (dirX < 0f){
				if (isFlipped)
				{
					Event.FlipY(this.GetComponent<Transform>());
					isFlipped = false;
				}
			}
			
			thisRigidbody.velocity = new Vector2(dirX, dirY);
		
			if(Input.GetKey(KeyCode.LeftShift))
			{
				thisRigidbody.velocity = new Vector2(0,100);
			}

			Vector2 movement = new Vector2(dirX, dirY);
			thisRigidbody.MovePosition(thisRigidbody.position + movement * speed * Time.fixedDeltaTime * Event.IsometricVector);
		}
		
		if(Input.GetMouseButton(0) && !isFighting && attackCooldown==0)
        {
			StartCoroutine(AttackCoroutine());
        }
		else if(!Input.GetMouseButton(0)){
			anim.SetBool("running", true);

			if(dirX == 0f && dirY == 0f)
				anim.SetBool("running", false);
        }

    }
	
	private IEnumerator AttackCoroutine()
	{
		isFighting = true;
		anim.SetBool("running",false);
        anim.SetBool("fighting",true);
		
		attackCooldown=AttackCooldownValue;
		thisRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
		do{ yield return null; } while(Event.CheckPause());
		thisRect.sizeDelta = AttackDimensions;
		if(!isFlipped)
			thisRect.position -= new Vector3(65f, -22f, 0f);
		else
			thisRect.position += new Vector3(65f, 22f, 0f);
		
		for(int i=0; i<AttackCooldownValue; i++)
		{
			do{ yield return null; } while(Event.CheckPause());
		}
		
		thisRect.sizeDelta = NormalDimensions;
		if(!isFlipped)
			thisRect.position += new Vector3(65f, -22f, 0f);
		else
			thisRect.position -= new Vector3(65f, 22f, 0f);
		
		anim.SetBool("running",true);
		anim.SetBool("fighting",false);
		do{ yield return null; } while(Event.CheckPause());
		thisRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

		isFighting = false;
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