using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    // Reference OrderSlipManager script
    public OrderSlipManager orderSlipManager;

    // Reference GameManager script
    public GameManager gM; 
    // Spawn spots array
    public GameObject[] spawnSpots;
    // Customers array
    public GameObject[] customerArray;
    // List stores currently used spots
    public List<string> usedSpots = new List<string>();
    //public bool gameIsActive;
    public bool spotsFull;

    // Reference CoasterSocket0 Script
    public CoasterSocket0 coasterSocket0;

    public GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        /*// Get the random index of the spot we will spawn the customer at
        int randomSpot = Random.Range(0, spawnSpots.Length);
        Debug.Log(randomSpot);

        // Get the customer we will spawn
        int randomCustomer = Random.Range(0, customerArray.Length);

        // Convert the index to string
        string spotToAdd = randomSpot.ToString();

        // Call OrderSlipChange function from orderSlipManager Script
        orderSlipManager.OrderSlipEnable(randomSpot, randomCustomer);

        // Add the used spawn spot from the usedSpots list
        usedSpots.Add(spotToAdd);

        // Instantiate the customer at the spawn spot and orient to face the right direction
        customer = Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

        if (randomSpot == 0)
        {
            orderSlipManager.SetSocket0Customer();
        }

        if (randomSpot == 1)
        {
            orderSlipManager.SetSocket1Customer();
        }

        if (randomSpot == 2)
        {
            orderSlipManager.SetSocket2Customer();
        }

        if (randomSpot == 3)
        {
            orderSlipManager.SetSocket3Customer();
        }

        if (randomSpot == 4)
        {
            orderSlipManager.SetSocket4Customer();
        }*/

        StartCoroutine("SpawnCustomer");
    }

    IEnumerator SpawnCustomer()
    {
        while (gM.isGameActive && !spotsFull)
        {
            yield return new WaitForSeconds(5f);
            // Randomise spot to spawn at
            int randomSpot = Random.Range(0, spawnSpots.Length);
            string spotToAdd = randomSpot.ToString();

            if (!usedSpots.Contains("0") && spotToAdd == "0")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);

                // Call OrderSlipChange function from orderSlipManager Script
                orderSlipManager.OrderSlipEnable(randomSpot, randomCustomer);

                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                customer = Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

                orderSlipManager.SetSocket0Customer();
            }

            else if (!usedSpots.Contains("1") && spotToAdd == "1")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);

                // Call OrderSlipChange function from orderSlipManager Script
                orderSlipManager.OrderSlipEnable(randomSpot, randomCustomer);

                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                customer = Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

                orderSlipManager.SetSocket1Customer();
            }

            else if (!usedSpots.Contains("2") && spotToAdd == "2")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);

                // Call OrderSlipChange function from orderSlipManager Script
                orderSlipManager.OrderSlipEnable(randomSpot, randomCustomer);

                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                customer = Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

                orderSlipManager.SetSocket2Customer();
            }

            else if (!usedSpots.Contains("3") && spotToAdd == "3")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);

                // Call OrderSlipChange function from orderSlipManager Script
                orderSlipManager.OrderSlipEnable(randomSpot, randomCustomer);

                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                customer = Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

                orderSlipManager.SetSocket3Customer();
            }

            else if (!usedSpots.Contains("4") && spotToAdd == "4")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);

                // Call OrderSlipChange function from orderSlipManager Script
                orderSlipManager.OrderSlipEnable(randomSpot, randomCustomer);

                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                customer = Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

                orderSlipManager.SetSocket4Customer();
            }
            Debug.Log(spotToAdd);
        }
        yield return null;
    }

    private void Update()
    {
        if (usedSpots.Count == 5)
        {
            spotsFull = true;
        }

        if (usedSpots.Count < 5)
        {
            spotsFull = false;
        }
    }
}
