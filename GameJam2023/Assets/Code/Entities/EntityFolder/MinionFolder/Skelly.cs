using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : Minion
{
    // Start is called before the first frame update
    void Start()
    {
        SearchForTarget(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
