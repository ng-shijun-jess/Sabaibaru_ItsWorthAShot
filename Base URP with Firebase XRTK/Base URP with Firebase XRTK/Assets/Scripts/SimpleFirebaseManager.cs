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
    /// <param name="customersHit"></param>
    /// <param name="customersLost"></param>
    /// <param name="customersChasedAway"></param>
    /// /// <param name="totalMoneyEarned"></param>
    /// /// <param name="totalTimeWorked"></param>
    /// /// <param name="customersServed"></param>
    /// <param name="displayName"></param>
    public void UpdatePlayerStats(string uuid, int totalMoneyEarned, int totalTimeWorked, int customersHit, int customersLost, int customersChasedAway,  int customersServed, string displayName)
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
                    Debug.Log("player stats does exist");
                    //update player stats
                    //compare existing highscore and set new highscore

                    SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                    //sp.totalTimeWorked += totalTimeWorked;
                    sp.updatedOn = sp.GetTimeUnix();
                 
                    if (totalMoneyEarned > sp.highestMoneyEarned)
                    {
                        sp.highestMoneyEarned = totalMoneyEarned;
                        UpdatePlayerLeaderBoardEntry(uuid, sp.highestMoneyEarned, sp.updatedOn);
                    }
                    if (totalTimeWorked > sp.mostTimeWorked)
                    {
                        sp.mostTimeWorked = totalTimeWorked;
                        //UpdatePlayerLeaderBoardEntry(uuid, sp.mostTimeWorked, sp.updatedOn);
                    }


                    //path: playerStats/$uuid
                    dbPlayerStatsReference.Child(uuid).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                }
                else
                {

                    //Create player stats
                    SimplePlayerStats sp = new SimplePlayerStats(displayName, totalMoneyEarned, totalTimeWorked, customersHit, customersLost, customersChasedAway, customersServed);

                    SimpleLeaderBoard lb = new SimpleLeaderBoard(displayName, totalMoneyEarned);

                    dbPlayerStatsReference.Child(uuid).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                    dbLeaderboardsReference.Child(uuid).SetRawJsonValueAsync(lb.SimpleLeaderBoardToJson());
                }
            }
        });

    }
    public void UpdatePlayerLeaderBoardEntry(string uuid, int highestMoneyEarned, long updatedOn)
    {

        //path: leaderboards/$uuid/highScore
        //path: leaderboards/$uuid/updatedOn

        dbLeaderboardsReference.Child(uuid).Child("highestMoneyEarned").SetValueAsync(highestMoneyEarned);
        dbLeaderboardsReference.Child(uuid).Child("updatedOn").SetValueAsync(updatedOn);
    }

    public async Task<List<SimpleLeaderBoard>> GetLeaderboard(int limit = 4)
    {
        Query q = dbLeaderboardsReference.OrderByChild("score").LimitToLast(limit);

        List<SimpleLeaderBoard> leaderBoardList = new List<SimpleLeaderBoard>();

        await dbLeaderboardsReference.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error getting leaderboard entries, : ERROR: " + task.Exception);
            } else if (task.IsCompleted)
            {
                DataSnapshot ds = task.Result;

                if (ds.Exists)
                {
                    int rankCounter = 1;
                    foreach (DataSnapshot d in ds.Children)
                    {
                        //create temp objects based on the results
                        SimpleLeaderBoard lb = JsonUtility.FromJson<SimpleLeaderBoard>(d.GetRawJsonValue());
                        
                        //add item to list
                        leaderBoardList.Add(lb);
                        
                        Debug.LogFormat("Leaderboard: Rank {0} Playername {1} Score{2}", rankCounter, lb.userName, lb.highestMoneyEarned);
                    }
                    //change list to descending order
                    leaderBoardList.Reverse();

                    for (int i = 0; i < leaderBoardList.Count; i++)
                    {
                        for(int j = i + 1; j < leaderBoardList.Count; j++)
                        {
                            if(leaderBoardList[j].highestMoneyEarned > leaderBoardList[i].highestMoneyEarned)
                            {
                                SimpleLeaderBoard tmp = leaderBoardList[i];
                                leaderBoardList[i] = leaderBoardList[j];
                                leaderBoardList[j] = tmp;
                            }
                        }
                    }

                    //for each simpleleaderboard object inside our leaderboardlist
                    foreach(SimpleLeaderBoard lb in leaderBoardList)
                    {
                        Debug.LogFormat("Leaderboard: Rank{0} Playername {1} High Score {2}", rankCounter, lb.userName, lb.highestMoneyEarned);

                        rankCounter++;
                    }
                }
            }
        });

        return leaderBoardList;
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

        await dbPlayerStatsReference.GetValueAsync().ContinueWithOnMainThread(task => //doesnt work
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
