using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnContainer;

    public GameObject[] enemiesArray;

    public GameObject enemyContainer;
    // Start is called before the first frame update
    void Start()
    {
        spawnContainer = GameObject.FindGameObjectsWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("naciśnięte E");
            StartCoroutine(SpawnWave(UnityEngine.Random.Range(0, 10),UnityEngine.Random.Range(0, 3), 3));
        }
    }

    public IEnumerator SpawnWave(int enemyNumber, int spawnNumber, float spawnInterval)
    {
        List<GameObject> selectedEnemies = new List<GameObject>(enemyNumber);
        for (int i = 0; i < enemyNumber; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemiesArray.Length);
            selectedEnemies.Add(enemiesArray[randomIndex]);
        }
        for (int i = 0; i < spawnNumber; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spawnContainer.Length);
            GameObject spawnPoint = spawnContainer[randomIndex];

            for (int j = 0; j < enemyNumber; j++)
            {
                GameObject enemy = Instantiate(selectedEnemies[j], spawnPoint.transform.position, Quaternion.identity, enemyContainer.transform);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

}
