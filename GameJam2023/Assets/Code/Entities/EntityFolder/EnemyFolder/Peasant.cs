using UnityEngine;

public class Peasant : Enemy
{
	private GameObject[] newGlobalTarget = new GameObject[0];
	// Start is called before the first frame update
    void Start()
    {
        GameplayController.UpdateEnemies();
		health=1;
		speed = 250f;
		pushResistance = 450f;
		thisRigidbody = this.GetComponent<Rigidbody2D>();
		SearchForTarget(GameplayController.EnemyGlobalTarget);
		
		//Event.Move(this.gameObject, 300f, 60, Vector2.up);
		//StartCoroutine(WaitForFollow(60));
    }

    void FixedUpdate()
    {
		if(health==0)
			Death();
		
		if(newGlobalTarget!=GameplayController.EnemyGlobalTarget)
		{
			newGlobalTarget = GameplayController.EnemyGlobalTarget;
			SearchForTarget(newGlobalTarget);
		}
		
		if (canFollow)
        {
            Follow();
        }	
    }
	
	void OnDestroy()
	{
		GameplayController.UpdateEnemies();
	}
}
