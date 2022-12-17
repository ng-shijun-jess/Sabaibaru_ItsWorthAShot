using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerSpawnSpot : MonoBehaviour
{
    // Reference Customer Spawner GameObject
    private GameObject beerSpawner;
    // Reference Customer Spawner Script
    private BeerSpawner beerSpawnerScript;

    private void Awake()
    {
        beerSpawner = GameObject.Find("BeerSpawner");
        beerSpawnerScript = beerSpawner.GetComponent<BeerSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            Debug.Log("Beer");
            for (int i = 0; i < beerSpawnerScript.spawnSpots.Length; i++)
            {
                string j = i.ToString();
                Debug.Log(j);
                if (this.gameObject == beerSpawnerScript.spawnSpots[i])
                {
                    beerSpawnerScript.usedSpots.Remove(j);
                }
            }
        }
    }
}
