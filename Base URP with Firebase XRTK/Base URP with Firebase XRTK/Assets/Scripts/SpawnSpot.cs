using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpot : MonoBehaviour
{
    // Reference Customer Spawner GameObject
    private GameObject customerSpawner;
    // Reference Customer Spawner Script
    private CustomerSpawner customerSpawnerScript;

    // Reference OrderSlipManager GameObject
    private GameObject orderSlipManager;
    // Reference OrderSlipManager Script
    private OrderSlipManager orderSlipManagerScript;

    private void Awake()
    {
        // Find OrderSlipManager GameObject
        orderSlipManager = GameObject.Find("OrderSlipManager");
        orderSlipManagerScript = orderSlipManager.GetComponent<OrderSlipManager>();

        customerSpawner = GameObject.Find("CustomerSpawner");
        customerSpawnerScript = customerSpawner.GetComponent<CustomerSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "AICustomer")
        {
            if (this.gameObject.tag == "spawnSpot0")
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
            }
        }
    }
}
