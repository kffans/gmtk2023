using UnityEngine;

public class FistAttack : MonoBehaviour
{
    void OnTriggerEnter(Collision2D collision)
    {
		Debug.Log(collision.gameObject.name);
		if (collision.gameObject.tag == "Enemy")
        {
			Debug.Log("aaa");
			collision.gameObject.GetComponent<Enemy>().PushedAway();
        }
    }

}
