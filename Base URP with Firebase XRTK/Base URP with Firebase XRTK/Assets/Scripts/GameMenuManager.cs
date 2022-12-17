/*
 Simple Script to allow usrs to choose between options in the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    
    public SimpleAuthManager authMgr;
    public GameObject signOutBtn;

    public GameObject startGameBtn;
    public GameObject leaderboardBtn;
    public GameObject playerProfileBtn;



    public void SignOut()
    {
        authMgr.SignOutUser();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerProfile()
    {
        SceneManager.LoadScene(3);
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene(4);
    }
}
