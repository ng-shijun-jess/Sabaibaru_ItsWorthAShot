using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorbaSpawnSpot : MonoBehaviour
{
    // Reference Corba Spawner GameObject
    private GameObject corbaSpawner;
    // Reference Corba Spawner Script
    private CorbaSpawner corbaSpawnerScript;

    private void Awake()
    {
        corbaSpawner = GameObject.Find("CorbaSpawner");
        corbaSpawnerScript = corbaSpawner.GetComponent<CorbaSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            Debug.Log("Corba");
            for (int i = 0; i < corbaSpawnerScript.spawnSpots.Length; i++)
            {
                string j = i.ToString();
                Debug.Log(j);
                if (this.gameObject == corbaSpawnerScript.spawnSpots[i])
                {
                    corbaSpawnerScript.usedSpots.Remove(j);
                }
            }
        }
    }
}
