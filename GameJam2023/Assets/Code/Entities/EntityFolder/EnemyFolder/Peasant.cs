using UnityEngine;

public class Peasant : Enemy
{
	
	// Start is called before the first frame update
    void Start()
    {
        GameplayController.UpdateEnemies();
		health=1;
		speed = 250f;
		pushResistance = 450f;
		SearchForTarget(GameplayController.EnemyGlobalTarget);
        thisRigidbody = this.GetComponent<Rigidbody2D>();
		
		//Event.Move(this.gameObject, 300f, 60, Vector2.up);
		//StartCoroutine(WaitForFollow(60));
    }

    void FixedUpdate()
    {
		if(Enemy.HasGlobalTargetChanged)
		{
			SearchForTarget(GameplayController.EnemyGlobalTarget);
		}
		
		if (canFollow)
        {
            Follow();
        }
		
    }
}
