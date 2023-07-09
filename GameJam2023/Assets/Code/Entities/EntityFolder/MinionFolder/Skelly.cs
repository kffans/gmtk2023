using System.Collections;
using UnityEngine;

public class Skelly : Minion
{
    void Start()
    {
        GameplayController.UpdateArtObjects();
		speed=30f;
		health=300;
		thisRigidbody = this.GetComponent<Rigidbody2D>();
		SearchForTarget(GameplayController.EnemyObjects);
    }

	void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
	

    void FixedUpdate()
    {
        if (health<= 0)
        {
            Death();
        }
		SearchForTarget(GameplayController.EnemyObjects);

		Follow();
    }
	
	public void Death()
	{
		StartCoroutine(DeathCoroutine());
	}
	
	public IEnumerator DeathCoroutine()
	{
		for(int i=0; i<9; i++){
			this.transform.rotation = Quaternion.Euler(10f*i, 0f, 0f);
			do{ yield return null; } while(Event.CheckPause());
		}
		Destroy(this.gameObject);
	}
	
	void OnDestroy()
	{
		GameplayController.UpdateArtObjects();
	}
}
