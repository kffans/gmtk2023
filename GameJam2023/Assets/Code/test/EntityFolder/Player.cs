using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    void Start()
    {
        Speed = 400f;        
    }
    

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(moveHorizontal, moveVertical);
        transform.Translate(movement * Speed * Time.deltaTime);
    }
}
