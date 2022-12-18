using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement; //to load back to main menu
public class SimpleLeaderboardManager : MonoBehaviour
{
    public SimpleFirebaseManager fbManager;
    public GameObject rowPrefab;
    public Transform tableContent;


    // Start is called before the first frame update
    void Start()
    {
        GetLeaderboard();
    }

    /// <summary>
    /// Get and update leaderboard UI
    /// </summary>
    public void GetLeaderboard()
    {
        UpdateLeaderboardUI();
    }

    public async void UpdateLeaderboardUI()
    {
        var leaderBoardList = await fbManager.GetLeaderboard(5);
        int rankCounter = 1;

        foreach(Transform item in tableContent)
        {
            Destroy(item.gameObject);
        }

        //create prefabs of our rows
        //assign each value from list to prefab text content
        foreach(SimpleLeaderBoard lb in leaderBoardList)
        {
            Debug.LogFormat("Leaderboard Mgr: Rank{0} Playername {1} High Score {2}", rankCounter, lb.userName, lb.highestMoneyEarned);

            //create prefabs in the position of tableContent
            GameObject entry = Instantiate(rowPrefab, tableContent);
            TextMeshProUGUI[] leaderBoardDetails = entry.GetComponentsInChildren<TextMeshProUGUI>();
            leaderBoardDetails[0].text = rankCounter.ToString();
            leaderBoardDetails[1].text = lb.userName;
            leaderBoardDetails[2].text = lb.highestMoneyEarned.ToString();

            rankCounter++;
        }
    }

    public void GoToGameMenu()
    {
        SceneManager.LoadScene(1);
    }
}
