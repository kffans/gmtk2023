using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemiesArray;

    public GameObject enemyContainer;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(SpawnWave());
    }

    
	//StartCoroutine(SpawnWave(UnityEngine.Random.Range(1, 10),UnityEngine.Random.Range(0, 3), 3));

    public IEnumerator SpawnWave()
    {
		while(true)
		{
			if(GameplayController.StartWave){
				Instantiate(enemiesArray[0], this.transform);
				yield return new WaitForSeconds(UnityEngine.Random.Range(3, 6));
			}
			else{
				do{ yield return null; } while(Event.CheckPause());
			}
		}
    }

}
