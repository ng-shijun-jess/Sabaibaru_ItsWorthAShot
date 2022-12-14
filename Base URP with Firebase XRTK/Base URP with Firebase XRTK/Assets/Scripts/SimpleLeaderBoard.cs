using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SimpleLeaderBoard
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

    public string userName;
    public int highScore;
    public long updatedOn;

    //simpleLeaderBoard
    public SimpleLeaderBoard()
    {

    }
    //constructor with parameters
    public SimpleLeaderBoard(string uesrName, int highScore)
    {
        this.userName = uesrName;
        this.highScore = highScore;
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
