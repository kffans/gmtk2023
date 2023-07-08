using UnityEngine;

public class FistAttack : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Enemy")
        {
			Debug.Log("aaa");
			collision.gameObject.GetComponent<Enemy>().PushedAway();
        }
    }

}
