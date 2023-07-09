using UnityEngine;

public class Knight : Enemy
{
	private GameObject[] newGlobalTarget = new GameObject[0];
	// Start is called before the first frame update
    void Start()
    {
        GameplayController.UpdateEnemies();
		speed = 200f;
		pushResistance = 350f;
		SearchForTarget(GameplayController.EnemyGlobalTarget);
        thisRigidbody = this.GetComponent<Rigidbody2D>();
		
		//Event.Move(this.gameObject, 300f, 60, Vector2.up);
		//StartCoroutine(WaitForFollow(60));
    }

    void FixedUpdate()
    {
        if(newGlobalTarget!=GameplayController.EnemyGlobalTarget)
		{
			newGlobalTarget = GameplayController.EnemyGlobalTarget;
			Debug.Log("AAA");
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
