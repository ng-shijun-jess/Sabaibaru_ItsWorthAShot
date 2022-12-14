using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class AICustomer1 : MonoBehaviour
{
    public GameObject aiCanvas;
    public TextMeshProUGUI timerText;
    public Image timerBar;

    // Total Time before customer leaves
    float waitTime;
    // Current time left
    float currentTime;
    float lerpSpeed;

    // Destination of customer when leaving
    private GameObject aiDestination;

    private NavMeshAgent customerAI;
    private Animator customerAnimator;

    // Reference Customer Spawner gameObject
    private GameObject customerSpawner;
    // Reference Customer Spawner script
    private CustomerSpawner customerSpawnerScript;

    private void Awake()
    {
        // Look for Customer Spawner gameObject
        customerSpawner = GameObject.Find("CustomerSpawner");
        // Look for Customer Spawner script on customer spawner gameObject
        customerSpawnerScript = customerSpawner.GetComponent<CustomerSpawner>();
        // Find NavMeshAgent Component
        customerAI = GetComponent<NavMeshAgent>();
        // Find Animator component
        customerAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        
        // Find the AI's destination with object tag.
        aiDestination = GameObject.FindGameObjectWithTag("AIDestination");
        // Randomise total waiting time
        waitTime = Random.Range(10, 20);
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Make current time decrease by 1 each second
        currentTime -= 1 * Time.deltaTime;
        // Update timer text
        timerText.text = currentTime.ToString("0") + "s";

        lerpSpeed = 3f * Time.deltaTime;

        // If Current waiting time left is 0
        if (currentTime <= 0)
        {
            aiCanvas.SetActive(false);
            // Play walking animation
            customerAnimator.SetBool("StartWalk", true);
            // Set customerAI's destination to the leaving destination
            customerAI.destination = aiDestination.transform.position;
            // If CustomerAI reaches its destination
            if (customerAI.transform.position == customerAI.destination)
            {
                Debug.Log("reached");
                // Set its destination to itself to stop it from moving
                customerAI.SetDestination(transform.position);
                Destroy(this.gameObject);
            }
        }

        TimerBarFiller();
        ColorChanger();
    }

    void TimerBarFiller()
    {
        // Change timer bar fill amount according to waiting time left
        timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, currentTime/waitTime, lerpSpeed);   
    }

    void ColorChanger()
    {
        Color timeColor = Color.Lerp(Color.red, Color.green, (currentTime / waitTime));

        timerBar.color = timeColor;
    }
}
