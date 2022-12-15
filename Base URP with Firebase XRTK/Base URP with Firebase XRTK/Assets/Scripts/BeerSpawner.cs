using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerSpawner : MonoBehaviour
{
    public GameObject beer;
    // Spawn spots array
    public GameObject[] spawnSpots;
    // List stores currently used spots
    public List<string> usedSpots = new List<string>();
    public bool gameIsActive;
    public bool spotsFull;

    public bool isCoroutineStarted;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnSpots.Length; i++)
        {
            // Instantiate the Beer at the spawn spot and orient to face the right direction
            Instantiate(beer, spawnSpots[i].transform.position, spawnSpots[i].transform.rotation);
            string j = i.ToString();
            usedSpots.Add(j);
        }

        StartCoroutine("SpawnBeer");
    }

    IEnumerator SpawnBeer()
    {
        isCoroutineStarted = true;
        while (gameIsActive && !spotsFull)
        {
            yield return new WaitForSeconds(4f);
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
                    // Instantiate the beer at the spot
                    Instantiate(beer, spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
                }
            }
        }
        isCoroutineStarted = false;
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
            if (!isCoroutineStarted)
            {
                StartCoroutine("SpawnBeer");
            }
        }
    }
}
