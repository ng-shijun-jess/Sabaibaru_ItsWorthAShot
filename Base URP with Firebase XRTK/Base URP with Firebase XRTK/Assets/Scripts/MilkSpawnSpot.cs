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
            /*if (this.gameObject.tag == "spawnSpot0")
            {
                customerSpawnerScript.usedSpots.Remove("0");
                orderSlipManagerScript.OrderSlipDisable(0);
            }
            if (this.gameObject.tag == "spawnSpot1")
            {
                customerSpawnerScript.usedSpots.Remove("1");
                orderSlipManagerScript.OrderSlipDisable(1);
            }
            if (this.gameObject.tag == "spawnSpot2")
            {
                customerSpawnerScript.usedSpots.Remove("2");
                orderSlipManagerScript.OrderSlipDisable(2);
            }
            if (this.gameObject.tag == "spawnSpot3")
            {
                customerSpawnerScript.usedSpots.Remove("3");
                orderSlipManagerScript.OrderSlipDisable(3);
            }
            if (this.gameObject.tag == "spawnSpot4")
            {
                customerSpawnerScript.usedSpots.Remove("4");
                orderSlipManagerScript.OrderSlipDisable(4);
            }*/
        }
    }
}
