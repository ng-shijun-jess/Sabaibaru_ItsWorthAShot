using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AICustomer1 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Image timerBar;

    float waitTime;
    float currentTime;

    void Start()
    {
        waitTime = Random.Range(10, 20);
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0") + "s";
        TimerBarFiller();
    }

    void TimerBarFiller()
    {
        timerBar.fillAmount = currentTime / waitTime;   
    }
}
