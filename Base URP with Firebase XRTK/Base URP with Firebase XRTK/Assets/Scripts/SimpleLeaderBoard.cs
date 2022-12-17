using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SimpleLeaderBoard
{

    /*
    Key:uuid
    userName;
    customersHit;
    customersLost;
    customersChasedAway;
    highestMoneyEarned;
    totalMoneyEarned;
    mostTimeWorked;
    totalTimeWorked;
    customersServed;
    updatedOn;
    createdOn;
 */

    public string userName;
    public int highestMoneyEarned;
    public long updatedOn;

    //simpleLeaderBoard
    public SimpleLeaderBoard()
    {

    }
    //constructor with parameters
    public SimpleLeaderBoard(string uesrName, int highestMoneyEarned)
    {
        this.userName = uesrName;
        this.highestMoneyEarned = highestMoneyEarned;
        this.updatedOn = GetTimeUnix();

       
    }
    public long GetTimeUnix()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

    }

    public string SimpleLeaderBoardToJson()
    {
        return JsonUtility.ToJson(this);
    }

}
