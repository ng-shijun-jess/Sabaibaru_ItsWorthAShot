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
    public int score;
    private int customersHit;
    private int customersLost;
    private int customersChasedAway;
    private int highestMoneyEarned;
    private int totalMoneyEarned;
    private int mostTimeWorked;
    private int totalTimeWorked;
    private int customersServed;
    public Button restartButton;

    public SimpleFirebaseManager firebaseMgr;
    public bool isPlayerStatUpdated;
    public int xpPerGame = 5;
    public int timePerGame = 300;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    // Defining Lives Int
    public int playerLives = 3;

    private void Update()
    {
        if (isGameActive)
        {
            if (playerLives == 0)
            {
                GameOver(); ///need to link this
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        //scoreText.text = "Score: " + score;
    }
    public void UpdateTotalMoneyEarned(int moneyToAdd)
    {
        totalMoneyEarned += moneyToAdd;
        totalMoneyEarnedText.text = "Total Money Earned: " + totalMoneyEarned;
    }

    public void GameOver()
    {

        isGameActive = false;
        Time.timeScale = 0;
        if(!isPlayerStatUpdated)
        {
            UpdatePlayerStat(this.customersHit, this.customersLost, this.customersChasedAway, this.highestMoneyEarned, this.totalMoneyEarned, this.mostTimeWorked, this.totalTimeWorked, this.customersServed); //need to update this
            Debug.Log("playerStats is being updated");
        }
        isPlayerStatUpdated = true;
        gameOverMenu.SetActive(true);

        //updating the text in the Game Over Menu

        goTotalMoneyEarnedText.text = "Money Earned: $" + totalMoneyEarned;
        goTotalCustomersServedText.text = "Total Customer served: " + customersServed;



}
    //update player stats 
    public void UpdatePlayerStat(int customersHit, int customersLost, int customersChasedAway, int highestMoneyEarned, int totalMoneyEarned, int mostTimeWorked, int totalTimeWorked, int customersServed)
    {
        firebaseMgr.UpdatePlayerStats(auth.GetCurrentUser().UserId, customersHit, customersLost, customersChasedAway, highestMoneyEarned, totalMoneyEarned,  mostTimeWorked, totalTimeWorked, customersServed, auth.GetCurrentUserDisplayName()); ///need to link this
    }
    private void Start()
    {
        isGameActive = true;
        isPlayerStatUpdated = false;
        totalMoneyEarned = 0;
        UpdateTotalMoneyEarned(0);




    }

    public void MainMenu()
    {
        SceneManager.LoadScene(2);

    }

    public void Pause()
    {
        if (isGameActive)
        {
            Time.timeScale = 0;
            isGameActive = false;
            pauseMenu.SetActive(true);
        }
    }
}
