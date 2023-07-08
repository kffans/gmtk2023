using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject minionContainer;
    public GameObject minion;
    public int playerShots = 5;


    void Start()
    {
        minionContainer = GameObject.Find("Minions");
        minion = GameObject.Find("MinionPlaceHolder");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("naciśnięte Q");
            SpawnClick();
        }
    }

    public void SpawnClick()
    {
        playerShots -= 1;
        if (playerShots <= 0)
        {
            Debug.Log("Pusto dupa");
        }
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0f;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            GameObject newMinion = Instantiate(minion, worldPosition, Quaternion.identity);
            newMinion.transform.SetParent(minionContainer.transform);
           // Image newImage = newImageObject.GetComponent<Image>();
        }
    }
}
