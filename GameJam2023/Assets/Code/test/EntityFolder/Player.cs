using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ScoreText;
    Rigidbody2D ThisRigidbody;
    public int Score = 0;

    void Start()
    {
        ThisRigidbody = GetComponent<Rigidbody2D>();
        Speed = 400f;
        Health = 100;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        ThisRigidbody.MovePosition(ThisRigidbody.position + movement * Speed * Time.fixedDeltaTime);

        CheckHealth(HealthText, Health);
    }

    void LateUpdate() 
    {
        Score += 1;
        AddScore(ScoreText, Score);
    }

    void CheckHealth(TextMeshProUGUI healthText, int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    void AddScore(TextMeshProUGUI scoreText, int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void RemoveHealth(int health)
    {
        Health -=1;
    }

    // called when the cube hits the floor
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.name.Contains("Enemy"))
        {
            RemoveHealth(1);
        }
    }

}