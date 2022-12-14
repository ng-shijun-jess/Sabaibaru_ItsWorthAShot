using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SimplePlayerStatsManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI highestMoneyEarned;
    public TextMeshProUGUI mostTimeWorked;
    public TextMeshProUGUI customersHit;
    public TextMeshProUGUI customersLost;
    public TextMeshProUGUI customersChasedAway;
    public TextMeshProUGUI customersServed;


    public SimpleFirebaseManager fbMgr;
    public SimpleAuthManager auth;

    // Start is called before the first frame update
    void Start()
    {
        //retrieve current logged in user uuid
        //update UI
        UpdatePlayerStats(auth.GetCurrentUser().UserId); 
    }

    //Updates the player stats text in player stat menu
    public async void UpdatePlayerStats(string uuid)
    {
        SimplePlayerStats playerStats = await fbMgr.GetPlayerStats(uuid); 
        Debug.Log("player Stats...:  " + playerStats.SimplePlayerStatsToJson());

        customersHit.text = playerStats.customersHit.ToString();
        customersLost.text = playerStats.customersLost.ToString();
        customersChasedAway.text = playerStats.customersChasedAway.ToString();
        highestMoneyEarned.text = "$" + playerStats.highestMoneyEarned;
        customersServed.text = playerStats.customersServed.ToString();
        //totalMoneyEarned.text = "$" + playerStats.totalMoneyEarned;
        mostTimeWorked.text = playerStats.mostTimeWorked + "s";
        //totalTimeWorked.text = playerStats.totalTimeWorked + "s";

        playerName.text = auth.GetCurrentUserDisplayName();
    }

    public string UnixToDateTime(long timestamp)
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
        DateTime dateTime = dateTimeOffset.DateTime;

        return dateTime.ToString("dd MMM yyyy");
    }

}
