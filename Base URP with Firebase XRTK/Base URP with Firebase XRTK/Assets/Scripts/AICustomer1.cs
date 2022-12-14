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

    //money range for customer 1 to 3
    float firstMoneyRangeFloat;
    float secondMoneyRangeFloat;
    float thirdMoneyRangeFloat;

    // Current time left
    float currentTime;
    float lerpSpeed;

    // Check if Customer is given correct drink
    public bool drinkGiven;

    // Destination of customer when leaving
    private GameObject aiDestination;

    private NavMeshAgent customerAI;
    private Animator customerAnimator;

    // Reference Customer Spawner gameObject
    private GameObject customerSpawner;
    // Reference Customer Spawner script
    private CustomerSpawner customerSpawnerScript;

    // Check if lost customer has been added to database
    bool addLostCustomer;

    // Check if Served customer has been added to database
    bool addServedCustomer;

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
        customerAI = GetComponent<NavMeshAgent>();
        // Find Animator component
        customerAnimator = GetComponent<Animator>();
        // Look for GameManager GameObject
        gameManager = GameObject.Find("GameManager");
        // Find GameManager Script on GameManager GameObject
        gameManagerScript = gameManager.GetComponent<GameManager>();

        //customer 1 money range
        
    }

    void Start()
    {
        // Find the AI's destination with object tag.
        aiDestination = GameObject.FindGameObjectWithTag("AIDestination");
        // Randomise total waiting time
        waitTime = Random.Range(25, 35);
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

        if (drinkGiven)
        {
            if (!addServedCustomer)
            {
                addServedCustomer = true;
                gameManagerScript.UpdateTotalCustomersServed(1);/// Add Served customer here                                   DATABASE
                Debug.Log("customers has been served");
                if (this.gameObject.tag == "Customer1")
                {
                    Debug.Log("money Earned");
                    firstMoneyRangeFloat = Random.Range(30, 60);
                    int firstMoneyRangeInt = (int)firstMoneyRangeFloat;
                    gameManagerScript.UpdateTotalMoneyEarned(firstMoneyRangeInt);/// Add Money Earned Here                                   DATABASE
                    
                }

                if (this.gameObject.tag == "Customer2")
                {
                    secondMoneyRangeFloat = Random.Range(30, 60);
                    int secondMoneyRangeInt = (int)secondMoneyRangeFloat;
                    gameManagerScript.UpdateTotalMoneyEarned(secondMoneyRangeInt);/// Add Money Earned Here                                   DATABASE
                    Debug.Log("money Earned");
                }

                if (this.gameObject.tag == "Customer3")
                {
                    thirdMoneyRangeFloat = Random.Range(30, 60);
                    int thirdMoneyRangeInt = (int)thirdMoneyRangeFloat;
                    gameManagerScript.UpdateTotalMoneyEarned(thirdMoneyRangeInt);/// Add Money Earned Here                                   DATABASE
                    Debug.Log("money Earned");
                }
            }
            Debug.Log("drinkGiven");
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
                drinkGiven = false;
            }
        }

        // If Current waiting time left is 0
        if (currentTime <= 0)
        {
            if (!addLostCustomer)
            {
                // Deduct life from GameManager playerLives
                gameManagerScript.playerLives--;
                addLostCustomer = true;

                gameManagerScript.UpdateCustomersLost(1); /// Add lost customer here                                   DATABASE
            }
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

    // Change fillamount of timerbar over time
    void TimerBarFiller()
    {
        // Change timer bar fill amount according to waiting time left
        timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, currentTime/waitTime, lerpSpeed);   
    }

    // Change colour of timer bar over time
    void ColorChanger()
    {
        Color timeColor = Color.Lerp(Color.red, Color.green, (currentTime / waitTime));

        timerBar.color = timeColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Drink")
        {
            gameManagerScript.UpdateCustomersHit(1); /// Add Customers hit here                      DATABASE
        }
    }
}
