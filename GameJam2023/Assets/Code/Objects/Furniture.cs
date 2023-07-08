using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Furniture : MonoBehaviour
{
    public int scoreValue;
    public TextMeshProUGUI  scoreBoard;
    public float damageDelay = 2f;
    private bool canDealDamage = true;


    void Start()
    {
        scoreBoard = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        UpdateScoreText(CalculateTotalScore());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText(CalculateTotalScore());
        if (scoreValue<= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DealDamageWithDelay());
        }
    }

    IEnumerator DealDamageWithDelay()
    {
        canDealDamage = false; 

        scoreValue -= 1;

        yield return new WaitForSeconds(damageDelay);

        canDealDamage = true;
    }



    int CalculateTotalScore()
    {
        Furniture[] furnitureObjects = GameObject.FindObjectsOfType<Furniture>();
        int totalScore = 0;

        foreach (Furniture furniture in furnitureObjects)
        {
            totalScore += furniture.scoreValue;
        }

        return totalScore;
    }

    void UpdateScoreText(int score)
    {
        scoreBoard.text = "Score: " + score.ToString();
    }
}
