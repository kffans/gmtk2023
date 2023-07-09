using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : Minion
{
    void Start()
    {
        speed=100f;
		SearchForTarget(GameplayController.EnemyObjects);
    }

    void FixedUpdate()
    {
        SearchForTarget(GameplayController.EnemyObjects);

		Follow();
    }
}
