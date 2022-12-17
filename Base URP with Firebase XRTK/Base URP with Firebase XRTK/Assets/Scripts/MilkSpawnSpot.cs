using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpawnSpot : MonoBehaviour
{
    // Reference Customer Spawner GameObject
    private GameObject milkSpawner;
    // Reference Customer Spawner Script
    private MilkSpawner milkSpawnerScript;

    private void Awake()
    {
        milkSpawner = GameObject.Find("MilkSpawner");
        milkSpawnerScript = milkSpawner.GetComponent<MilkSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            Debug.Log("Milk");
            for (int i = 0; i < milkSpawnerScript.spawnSpots.Length; i++)
            {
                string j = i.ToString();
                Debug.Log(j);
                if (this.gameObject == milkSpawnerScript.spawnSpots[i])
                {
                    milkSpawnerScript.usedSpots.Remove(j);
                }
            }
        }
    }
}
