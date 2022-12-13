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

    float waitTime;
    float currentTime;
    float lerpSpeed;
    private GameObject aiDestination;

    private NavMeshAgent customerAI;
    private Animator customerAnimator;

    private void Awake()
    {
        customerAI = GetComponent<NavMeshAgent>();
        customerAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        aiDestination = GameObject.FindGameObjectWithTag("AIDestination");
        waitTime = Random.Range(10, 20);
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0") + "s";

        lerpSpeed = 3f * Time.deltaTime;

        if (currentTime <= 0)
        {
            aiCanvas.SetActive(false);
            customerAnimator.SetBool("StartWalk", true);
            customerAI.destination = aiDestination.transform.position;
            if (customerAI.transform.position == customerAI.destination)
            {
                Debug.Log("reached");
                customerAI.SetDestination(transform.position);
                customerAnimator.SetBool("StartWalk", false);
                Destroy(this.gameObject);
            }
        }

        TimerBarFiller();
        ColorChanger();
    }

    void TimerBarFiller()
    {
        timerBar.fillAmount = Mathf.Lerp(timerBar.fillAmount, currentTime/waitTime, lerpSpeed);   
    }

    void ColorChanger()
    {
        Color timeColor = Color.Lerp(Color.red, Color.green, (currentTime / waitTime));

        timerBar.color = timeColor;
    }
}
