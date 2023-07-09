using UnityEngine;

public class Skelly : Minion
{
    void Start()
    {
        GameplayController.UpdateArtObjects();
		speed=30f;
		health=3;
		thisRigidbody = this.GetComponent<Rigidbody2D>();
		SearchForTarget(GameplayController.EnemyObjects);
    }

    void FixedUpdate()
    {
        SearchForTarget(GameplayController.EnemyObjects);

		Follow();
    }
}
