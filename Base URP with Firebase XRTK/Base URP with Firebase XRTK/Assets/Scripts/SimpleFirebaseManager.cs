using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;
public class SimpleFirebaseManager : MonoBehaviour
{
    DatabaseReference dbPlayerStatsReference;
    DatabaseReference dbLeaderboardsReference;

    public void Awake()
    {
        InitializeFirebase();
    }

    public void InitializeFirebase()
    {
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");
        dbLeaderboardsReference = FirebaseDatabase.DefaultInstance.GetReference("leaderboards");
    }
    // Start is called before the first frame update

    /// <summary>
    /// create a new entry only if first time playing, update whem there's exisitng entries
    /// </summary>
    /// <param name="uuid"></param>
    /// <param name="score"></param>
    /// <param name="xp"></param>
    /// <param name="totalTimeSpent"></param>
    /// <param name="totalMoneyEarned"></param>
    /// <param name="totalCustomersLeft"></param>
    /// <param name="totalCustomersServed"></param>
    /// <param name="displayName"></param>
    public void UpdatePlayerStats(string uuid, int score, int xp, int totalTimeSpent, int totalMoneyEarned , int totalCustomersLeft , int totalCustomersServed, string displayName)
    {
        Query playerQuery = dbPlayerStatsReference.Child(uuid);

        //read the data first and check whether there has beena an entry on my uuid
        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error creating your entries, Error: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
               
                DataSnapshot playerStats = task.Result;
                //check if there is an entry created
                if (playerStats.Exists)
                {
                    //update player stats
                    //compare existing highscore and set new highscore
                    //add xp per game
                    //add time spent

                    SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                    sp.xp += xp;
                    sp.totalTimeSpent += totalTimeSpent;
                    sp.updatedOn += sp.GetTimeUnix();
                 
                    if (score > sp.highScore)
                    {
                        sp.highScore = score;
                        UpdatePlayerLeaderBoardEntry(uuid, sp.highScore, sp.updatedOn);
                    }


                    //path: playerStats/$uuid
                    dbPlayerStatsReference.Child(uuid).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                }
                else
                {
                    //Create player stats
                    SimplePlayerStats sp = new SimplePlayerStats(displayName, score, xp, totalTimeSpent, totalMoneyEarned, totalCustomersLeft, totalCustomersServed);

                    SimpleLeaderBoard lb = new SimpleLeaderBoard(displayName, score);

                    dbPlayerStatsReference.Child(uuid).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                    dbLeaderboardsReference.Child(uuid).SetRawJsonValueAsync(lb.SimpleLeaderBoardToJson());
                }
            }
        });

    }
    public void UpdatePlayerLeaderBoardEntry(string uuid, int highScore, long updatedOn)
    {

        //path: leaderboards/$uuid/highScore
        //path: leaderboards/$uuid/updatedOn

        dbLeaderboardsReference.Child(uuid).Child("highsScore").SetValueAsync(highScore);
        dbLeaderboardsReference.Child(uuid).Child("updatedOn").SetValueAsync(updatedOn);
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="uuid">retrieve form authenticate</param>
    /// <returns></returns>
    public async Task<SimplePlayerStats> GetPlayerStats(string uuid)
    {
        Query q = dbPlayerStatsReference.Child(uuid).LimitToFirst(1);
        SimplePlayerStats playerStats = null;

        await dbPlayerStatsReference.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled|| task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error receiving player Stats: Error: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot ds = task.Result;//path -> playerstats/$uuid
                //path to the datasnap shot playerstats/$uuid/<we want this value>
                playerStats = JsonUtility.FromJson<SimplePlayerStats>(ds.Child(uuid).GetRawJsonValue());

                Debug.Log("ds..." + ds.GetRawJsonValue());
                Debug.Log("player stats value.. " + playerStats.SimplePlayerStatsToJson());
            }
        });

        return playerStats;
    }
}
