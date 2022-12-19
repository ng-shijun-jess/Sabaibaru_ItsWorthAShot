using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Auth;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class GameManager : MonoBehaviour
{
    public SimpleAuthManager auth;

    ///public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalMoneyEarnedText;

    public TextMeshProUGUI goTotalMoneyEarnedText;
    public TextMeshProUGUI goTotalCustomersServedText;

    public bool isGameActive;


    //all the data needed for the update player stats
    public int customersHit;
    public int customersLost;
    public int customersChasedAway;
    public int totalMoneyEarned;
    public int totalTimeWorked;
    public int customersServed;

    public float time;

    public Button restartButton;

    public SimpleFirebaseManager firebaseMgr;
    public bool isPlayerStatUpdated;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public float startTime;

    // Defining Lives Int
    public int playerLives = 3;
    // Changing Lives Counter
    public TextMeshProUGUI livesCounter;

    // Updating time worked
    public TextMeshProUGUI timeTracker;

    // Updating Customers served on board
    public TextMeshProUGUI customersServedBoard;

    // Updating Money Earned on Board
    public TextMeshProUGUI moneyEarnedBoard;

    private void Start()
    { 
        isGameActive = true;
        isPlayerStatUpdated = false;
        UpdateCustomersHit(0);
        UpdateCustomersLost(0);
        UpdateCustomersChasedAway(0);
        UpdateTotalMoneyEarned(0);
        UpdateTotalCustomersServed(0);
        startTime = Time.time;
    }

    private void Update()
    {
        if (isGameActive)
        {
            Time.timeScale = 1;
            time += 1 * Time.deltaTime;

            if (playerLives != 0)
            {
                livesCounter.text = "Lives Left: " + playerLives.ToString();
                timeTracker.text = "Time Worked: " + time.ToString("0");
                customersServedBoard.text = "Customers Served: " + customersServed.ToString();
                moneyEarnedBoard.text = "Money Earned: " + totalMoneyEarned.ToString();
            }

            //When player live hits to 0, it is game over
            if (playerLives == 0)
            {
                Debug.Log("CustomersHit" + customersHit);
                Debug.Log("CustomersLost" + customersLost);
                Debug.Log("CustomersChasedAway" + customersChasedAway);
                Debug.Log("totalMoneyEarned" + totalMoneyEarned);
                Debug.Log("totalTimeWorked" + totalTimeWorked);
                Debug.Log("customersServed" + customersServed);

                GameOver();
                isGameActive = false;
            }
        }
    }

    //refreshes the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //update when customer got hit
    public void UpdateCustomersHit(int customersHitToAdd)
    {
        customersHit += customersHitToAdd;
    }
    //update when customer is lost
    public void UpdateCustomersLost(int customersLostToAdd)
    {
        customersLost += customersLostToAdd;
    }

    //update when customers are being chased away
    public void UpdateCustomersChasedAway(int customersChasedAwayToAdd)
    {
        customersChasedAway += customersChasedAwayToAdd;
    }

    //update when the money is being earned
    public void UpdateTotalMoneyEarned(int moneyToAdd)
    {
        totalMoneyEarned += moneyToAdd;
        totalMoneyEarnedText.text = "Total Money Earned: " + totalMoneyEarned;
    }

    //update when customers are served
    public void UpdateTotalCustomersServed(int totalCustomersServedToAdd)
    {
        customersServed += totalCustomersServedToAdd;
    }


    //When the game is over
    public void GameOver()
    {
        totalTimeWorked = (int)Math.Round(time);
        
        Time.timeScale = 0;
        //if not updated, the player stats will be updated
        if(!isPlayerStatUpdated)
        {
            UpdatePlayerStat(this.customersHit, this.customersLost, this.customersChasedAway, this.totalMoneyEarned, this.totalTimeWorked, this.customersServed); //need to update this
            Debug.Log("playerStats is being updated");
        }
        isPlayerStatUpdated = true;
        gameOverMenu.SetActive(true);

        //updating the text in the Game Over Menu
        goTotalMoneyEarnedText.text = "Money Earned: $" + totalMoneyEarned;
        goTotalCustomersServedText.text = "Total Customer served: " + customersServed;



}
    //update player stats 
    public void UpdatePlayerStat(int customersHit, int customersLost, int customersChasedAway, int totalMoneyEarned, int totalTimeWorked, int customersServed)
    {
        firebaseMgr.UpdatePlayerStats(auth.GetCurrentUser().UserId, customersHit, customersLost, customersChasedAway, totalMoneyEarned, totalTimeWorked, customersServed, auth.GetCurrentUserDisplayName()); ///need to link this
    }

    //Goes to Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(1);

    }
    //Stops time
    public void Pause()
    {
        if (isGameActive)
        {
            Time.timeScale = 0;
            isGameActive = false;
            pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        if (!isGameActive)
        {
            Time.timeScale = 1;
            isGameActive = true;
            pauseMenu.SetActive(false);
        }
    }
}
