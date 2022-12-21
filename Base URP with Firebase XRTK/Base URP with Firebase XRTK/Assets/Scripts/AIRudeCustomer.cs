using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class AIRudeCustomer : MonoBehaviour
{
    public GameObject rudeCustomerRemarks;

    //Check if RudeCustomer got hit
    bool gotHit;

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

    private GameObject sfxManager;
    private SFXManager sfxManagerScript;

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

        sfxManager = GameObject.Find("SFXManager");
        sfxManagerScript = sfxManager.GetComponent<SFXManager>();
        sfxManagerScript.RudeCustomerSFXOn();
    }

    void Start()
    {
        rudeCustomerRemarks.SetActive(true);
        
        // Find the AI's destination with object tag.
        aiDestination = GameObject.FindGameObjectWithTag("AIDestination");        
    }

    // Update is called once per frame
    void Update()
    {

        if (gotHit)
        {
            rudeCustomerRemarks.SetActive(false);
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
            }
        }
    }

    //When Rude customer collides with the drink
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Drink")
        {
            gameManagerScript.UpdateCustomersHit(1);/// Add Customers hit here                      DATABASE
            gameManagerScript.UpdateCustomersChasedAway(1);//update customer chased

            //Turn off the audio for rude customer
            sfxManager = GameObject.Find("SFXManager");
            sfxManager.GetComponent<SFXManager>();
            sfxManagerScript.RudeCustomerSFXOff();
            gotHit = true;
            
        }
    }
}
