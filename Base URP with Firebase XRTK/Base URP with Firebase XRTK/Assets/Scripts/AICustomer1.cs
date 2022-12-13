using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AICustomer1 : MonoBehaviour
{
    public GameObject aiCanvas;
    public TextMeshProUGUI timerText;
    public Image timerBar;

    float waitTime;
    float currentTime;
    float lerpSpeed; 

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

        lerpSpeed = 3f * Time.deltaTime;

        if (currentTime <= 0)
        {
            aiCanvas.SetActive(false);
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
