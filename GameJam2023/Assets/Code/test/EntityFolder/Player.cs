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
		Event.Fade(this.gameObject, 60, -1);
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
                yield return null;
            }
            score += 1;
            scoreText.text = "Score: " + score.ToString();
        }
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