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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalMoneyEarnedText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    private int score;
    private int totalMoneyEarned;
    private int totalCustomersLeft;
    private int totalCustomersServed;
    public Button restartButton;

    public SimpleFirebaseManager firebaseMgr;
    public bool isPlayerStatUpdated;
    public int xpPerGame = 5;
    public int timePerGame = 300;



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score;
    }
    public void UpdateTotalMoneyEarned(int moneyToAdd)
    {
        totalMoneyEarned += moneyToAdd;
        totalMoneyEarnedText.text = totalMoneyEarned;
    }

    public void GameOver()
    {
        isGameActive = false;
        if(!isPlayerStatUpdated)
        {
            UpdatePlayerStat(this.score, xpPerGame, this.timePerGame, this.totalMoneyEarned, this.totalCustomersLeft, this.totalCustomersServed);
        }
        isPlayerStatUpdated = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void UpdatePlayerStat(int score, int xp, int totalTimeSpent, int totalMoneyEarned, int totalCustomersLeft, int totalCustomersServed)
    {
        firebaseMgr.UpdatePlayerStats(auth.GetCurrentUser().UserId, score, xp, totalTimeSpent, totalMoneyEarned, totalCustomersLeft, totalCustomersServed, auth.GetCurrentUserDisplayName());
    }
    private void Start()
    {
        isGameActive = true;
        isPlayerStatUpdated = false;
        score = 0;
        totalMoneyEarned = 0;
        UpdateScore(0);

    }
}
