using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SimplePlayerStatsManager : MonoBehaviour
{

    public TextMeshProUGUI playerHighScore;
    public TextMeshProUGUI playerTotalMoneyEarned;
    public TextMeshProUGUI playerTotalTimeSpent;
    public TextMeshProUGUI playerTotalCustomersServed;
    public TextMeshProUGUI playerTotalCustomersLeft;
    public TextMeshProUGUI playerName;

    public SimpleFirebaseManager fbMgr;
    public SimpleAuthManager auth;

    public GameObject mainMenuBtn;

    // Start is called before the first frame update
    void Start()
    {
        //retrieve current logged in user uuid
        //upadte UI
        UpdatePlayerStats(auth.GetCurrentUser().UserId);
    }

    public async void UpdatePlayerStats(string uuid)
    {
        SimplePlayerStats playerStats = await fbMgr.GetPlayerStats(uuid);

        Debug.Log("player Stats...:  " + playerStats.SimplePlayerStatsToJson());

        playerHighScore.text = playerStats.highScore.ToString();
        playerTotalMoneyEarned.text = "$ " + playerStats.totalMoneyEarned;
        playerTotalTimeSpent.text = playerStats.totalTimeSpent + " s";
        playerTotalCustomersServed.text = playerStats.totalCustomersServed.ToString();
        playerTotalCustomersLeft.text = playerStats.totalCustomersLeft.ToString();

        playerName.text = auth.GetCurrentUserDisplayName();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(2);
    }
}
