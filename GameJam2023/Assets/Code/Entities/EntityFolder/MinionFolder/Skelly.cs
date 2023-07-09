using UnityEngine;

public class Skelly : Minion
{
    void Start()
    {
        GameplayController.UpdateArtObjects();
		speed=100f;
		SearchForTarget(GameplayController.EnemyObjects);
    }

    void FixedUpdate()
    {
        SearchForTarget(GameplayController.EnemyObjects);

		Follow();
    }
}
