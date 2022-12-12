using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] spawnSpots;
    public GameObject[] customerArray;
    public List<string> availableSpots = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        int randomSpot = Random.Range(0, spawnSpots.Length);
        Debug.Log(randomSpot);
        int randomCustomer = Random.Range(0, customerArray.Length);
        Instantiate(customerArray[randomCustomer], spawnSpots[randomSpot].transform.position, spawnSpots[randomSpot].transform.rotation);
    }

    IEnumerator SpawnCustomer()
    {
        yield return new WaitForSeconds(5f);

    }
}
