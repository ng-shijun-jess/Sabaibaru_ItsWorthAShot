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
        // Check if object is a customer
        if (other.gameObject.tag == "Customer1" || other.gameObject.tag == "Customer2" || other.gameObject.tag == "Customer1" || other.gameObject.tag == "AICustomer")
        {
            if (this.gameObject.tag == "spawnSpot0")
            {
                // Remove Spot 0 from usedSpots list
                customerSpawnerScript.usedSpots.Remove("0");
                // Turn off OrderSlip0
                orderSlipManagerScript.OrderSlipDisable(0);
            }
            if (this.gameObject.tag == "spawnSpot1")
            {
                // Remove Spot 1 from usedSpots list
                customerSpawnerScript.usedSpots.Remove("1");
                // Turn off OrderSlip1
                orderSlipManagerScript.OrderSlipDisable(1);
            }
            if (this.gameObject.tag == "spawnSpot2")
            {
                // Remove Spot 2 from usedSpots list
                customerSpawnerScript.usedSpots.Remove("2");
                // Turn off OrderSlip2
                orderSlipManagerScript.OrderSlipDisable(2);
            }
            if (this.gameObject.tag == "spawnSpot3")
            {
                // Remove Spot 3 from usedSpots list
                customerSpawnerScript.usedSpots.Remove("3");
                // Turn off OrderSlip3
                orderSlipManagerScript.OrderSlipDisable(3);
            }
            if (this.gameObject.tag == "spawnSpot4")
            {
                // Remove Spot 4 from usedSpots list
                customerSpawnerScript.usedSpots.Remove("4");
                // Turn off OrderSlip4
                orderSlipManagerScript.OrderSlipDisable(4);
            }
        }
    }
}
