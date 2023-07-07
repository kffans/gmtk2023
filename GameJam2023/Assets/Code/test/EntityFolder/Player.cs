using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    Rigidbody2D thisRigidbody;
    public int score = 0;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        speed = 400f;
        health = 100;
        StartCoroutine(ScoreCoroutine(scoreText,score));
        CheckHealth(healthText, health);
		//Event.Move(GameObject.Find("MainCamera"), 100f, 60, new Vector2(2,-1).normalized);
		
		//Event.Rotate(this.gameObject, 180f, 60, Vector2.zero); 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        thisRigidbody.MovePosition(thisRigidbody.position + movement * speed * Time.fixedDeltaTime);
    }

    public void CheckHealth(TextMeshProUGUI healthText, int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    public IEnumerator ScoreCoroutine(TextMeshProUGUI scoreText, int score)
    {
        while(true)
        {
            for(int i=0; i<=240; i++)
            {
                do{ yield return null; }while(Event.CheckPause());
            }
			//Event.Move(this.gameObject, 300f, 160, Vector2.left); 
            score += 1;
            scoreText.text = "Score: " + score.ToString();
			//Event.RotateTo(this.GetComponent<Transform>(), 0f, new Vector3(2f,-1f)); 
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        MusicController.PlaySound("heat");
    }

    // called when the cube hits the floor
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Enemy>() != null)
        {
            health -= 1;
            CheckHealth(healthText, health);
          
        }
    }

}