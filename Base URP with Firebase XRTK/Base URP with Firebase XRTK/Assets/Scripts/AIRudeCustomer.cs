using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class AIRudeCustomer : MonoBehaviour
{
    public GameObject rudeCustomerRemarks;

    bool gotHit;

    // Check if Customer is given correct drink
    public bool drinkGiven;

    // Destination of customer when leaving
    private GameObject aiDestination;

    private NavMeshAgent rudeAI;
    private Animator rudeAnimator;

    // Reference Customer Spawner gameObject
    private GameObject customerSpawner;
    // Reference Customer Spawner script
    private CustomerSpawner customerSpawnerScript;

    // Reference GameManager GameObject
    private GameObject gameManager;
    // Reference GameManager Script
    private GameManager gameManagerScript;

    private void Awake()
    {
        // Look for Customer Spawner gameObject
        customerSpawner = GameObject.Find("CustomerSpawner");
        // Look for Customer Spawner script on customer spawner gameObject
        customerSpawnerScript = customerSpawner.GetComponent<CustomerSpawner>();
        // Find NavMeshAgent Component
        rudeAI = GetComponent<NavMeshAgent>();
        // Find Animator component
        rudeAnimator = GetComponent<Animator>();
        // Look for GameManager GameObject
        gameManager = GameObject.Find("GameManager");
        // Find GameManager Script on GameManager GameObject
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    void Start()
    {
        // Find the AI's destination with object tag.
        aiDestination = GameObject.FindGameObjectWithTag("AIDestination");
    }

    // Update is called once per frame
    void Update()
    {
        rudeCustomerRemarks.SetActive(true);



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Drink")
        {
            /// Add Customers hit here                      DATABASE
            gotHit = true;
            rudeAnimator.SetBool("StartWalk", true);
            // Set customerAI's destination to the leaving destination
            rudeAI.destination = aiDestination.transform.position;
            // If CustomerAI reaches its destination
            if (rudeAI.transform.position == rudeAI.destination)
            {
                Debug.Log("reached");
                // Set its destination to itself to stop it from moving
                rudeAI.SetDestination(transform.position);
                Destroy(this.gameObject);
                gotHit = false;
            }
        }
    }
}
