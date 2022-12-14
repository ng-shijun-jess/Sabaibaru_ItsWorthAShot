using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpawner : MonoBehaviour
{
    public GameObject milkBottle;
    // Spawn spots array
    public GameObject[] spawnSpots;
    // List stores currently used spots
    public List<string> usedSpots = new List<string>();
    public bool gameIsActive;
    public bool spotsFull;

    // Start is called before the first frame update
    void Start()
    {
        // Get the random index of the spot we will spawn the milk at
        int randomSpot = Random.Range(0, spawnSpots.Length);
        Debug.Log(randomSpot);

        // Convert the index to string
        string spotToAdd = randomSpot.ToString();

        // Add the used spawn spot from the usedSpots list
        usedSpots.Add(spotToAdd);

        // Instantiate the Milk at the spawn spot and orient to face the right direction
        Instantiate(milkBottle, spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

        StartCoroutine("SpawnMilk");
    }

    IEnumerator SpawnMilk()
    {
        while (gameIsActive && !spotsFull)
        {
            yield return new WaitForSeconds(5f);
            // Randomise spot to spawn at
            int randomSpot = Random.Range(0, spawnSpots.Length);
            string spotToAdd = randomSpot.ToString();
            
            for (int i = 0; i <= spawnSpots.Length; i++)
            {
                string j = i.ToString();
                if (!usedSpots.Contains(j) && spotToAdd == j)
                {
                    // Add the used spot to the usedSpots list
                    usedSpots.Add(spotToAdd);
                    // Instantiate the milk at the spot
                    Instantiate(milkBottle, spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
                }
            }

            /*if (!usedSpots.Contains("0") && spotToAdd == "0")
            {
                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                Instantiate(milkBottle, spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
            }

            else if (!usedSpots.Contains("1") && spotToAdd == "1")
            {
                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                Instantiate(milkBottle, spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
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
                Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
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
                Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
            }

            else if (!usedSpots.Contains("4") && spotToAdd == "4")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);

                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
            }
            Debug.Log(spotToAdd);*/
        }
        yield return null;
    }

    private void Update()
    {
        if (usedSpots.Count == spawnSpots.Length)
        {
            spotsFull = true;
        }

        if (usedSpots.Count < spawnSpots.Length)
        {
            spotsFull = false;
        }
    }
}
