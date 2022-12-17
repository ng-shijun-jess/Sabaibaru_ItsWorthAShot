using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimplePlayerStats
{

    /*
        Key:uuid
    userName
    highScore
    xp
    totalTimeSpent
    totalDrinkServed
    totalMoneyEarned
    totalCustomersLeft
    totalCustomersServed
    updatedOn
    createdOn
     */
    // Start is called before the first frame update

    public string userName;
    public int customersHit;
    public int customersLost;
    public int customersChasedAway;
    public int highestMoneyEarned;
    public int totalMoneyEarned;
    public int mostTimeWorked;
    public int totalTimeWorked;
    public int customersServed;
    public long updatedOn;
    public long createdOn;

    //simple constructor

    public SimplePlayerStats(string userName, int customersHit = 0, int customersLost = 0, int customersChasedAway = 0, int highestMoneyEarned = 0, int totalMoneyEarned = 0, int mostTimeWorked = 0, int totalTimeWorked = 0, int customersServed = 0)
    {
        this.userName = userName;
        this.customersHit = customersHit;
        this.customersLost = customersLost;
        this.customersChasedAway = customersChasedAway;
        this.highestMoneyEarned = highestMoneyEarned;
        this.totalMoneyEarned = totalMoneyEarned;
        this.mostTimeWorked = mostTimeWorked;
        this.totalTimeWorked = totalTimeWorked;
        this.customersServed = customersServed;

        var timestamp = this.GetTimeUnix();
        this.createdOn = timestamp;
        this.updatedOn = timestamp;
    }

    public long GetTimeUnix()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
    
    public string SimplePlayerStatsToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
