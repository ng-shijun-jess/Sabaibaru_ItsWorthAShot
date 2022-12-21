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


    //Sign the user out
    public void SignOut()
    {
        authMgr.SignOutUser();

    }

    //Goes to the game scene to start game
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    //When player wishes to exit the game
    public void ExitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();

    }

}
