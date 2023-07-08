using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Event.Move(this.gameObject, 400f, 120, Vector2.left);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
