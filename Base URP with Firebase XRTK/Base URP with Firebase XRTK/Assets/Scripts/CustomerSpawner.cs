using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    // Spawn spots array
    public GameObject[] spawnSpots;
    // Customers array
    public GameObject[] customerArray;
    // List stores currently used spots
    public List<string> usedSpots = new List<string>();
    public bool gameIsActive;

    // Start is called before the first frame update
    void Start()
    {
        // Get the random index of the spot we will spawn the customer at
        int randomSpot = Random.Range(0, spawnSpots.Length);
        Debug.Log(randomSpot);

        // Get the customer we will spawn
        int randomCustomer = Random.Range(0, customerArray.Length);

        // Convert the index to string
        string spotToAdd = randomSpot.ToString();
        // Add the used spawn spot from the usedSpots list
        usedSpots.Add(spotToAdd);

        // Instantiate the customer at the spawn spot and orient to face the right direction
        Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);

        StartCoroutine("SpawnCustomer");
    }

    IEnumerator SpawnCustomer()
    {
        while (gameIsActive && usedSpots.Count != 5)
        {
            yield return new WaitForSeconds(5f);
            // Randomise spot to spawn at
            int randomSpot = Random.Range(0, spawnSpots.Length);
            string spotToAdd = randomSpot.ToString();

            if (!usedSpots.Contains("0") && spotToAdd == "0")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);
                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
            }

            else if (!usedSpots.Contains("1") && spotToAdd == "1")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);
                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
            }

            else if (!usedSpots.Contains("2") && spotToAdd == "2")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);
                // Add the used spot to the usedSpots list
                usedSpots.Add(spotToAdd);
                // Instantiate the customer at the spot
                Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
            }

            else if (!usedSpots.Contains("3") && spotToAdd == "3")
            {
                // Randomise customer to spawn
                int randomCustomer = Random.Range(0, customerArray.Length);
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
            Debug.Log(spotToAdd);
        }
        yield return null;
    }
}
