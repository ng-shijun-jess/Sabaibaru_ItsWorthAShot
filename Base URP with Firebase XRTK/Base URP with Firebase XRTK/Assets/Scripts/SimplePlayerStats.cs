using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimplePlayerStats : MonoBehaviour
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
    public int highScore;
    public int xp;
    public int totalTimeSpent;
    public int totalMoneyEarned;
    public int totalCustomersLeft;
    public int totalCustomersServed;
    public long updatedOn;
    public long createdOn;

    //simple constructor

    public SimplePlayerStats(string userName, int highScore, int xp = 0, int totalTimeSpent = 0, int totalMoneyEarned = 0, int totalCustomersLeft = 0, int totalCustomersServed = 0)
    {
        this.userName = userName;
        this.highScore = highScore;
        this.xp = xp;
        this.totalTimeSpent = totalTimeSpent;
        this.totalMoneyEarned = totalMoneyEarned;
        this.totalCustomersLeft = totalCustomersLeft;
        this.totalCustomersServed = totalCustomersServed;

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
