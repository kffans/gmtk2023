using UnityEngine;

public class Knight : Enemy
{
	private GameObject[] newGlobalTarget = new GameObject[0];
	// Start is called before the first frame update
    void Start()
    {
		GameplayController.UpdateEnemies();
		Event.Fade(this.gameObject, 30, 1);
		health=2;
		speed = 200f;
		pushResistance = 350f;
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
