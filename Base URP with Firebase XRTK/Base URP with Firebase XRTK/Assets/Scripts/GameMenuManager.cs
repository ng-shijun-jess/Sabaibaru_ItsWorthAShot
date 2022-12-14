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

public class GameMenuManager : MonoBehaviour
{
    
    public SimpleAuthManager authMgr;
    public GameObject signOutBtn;

    public GameObject playBtn;
    public TextMeshProUGUI displayName;

    public void Awake()
    {
        displayName.text = "Welcome, " + authMgr.GetCurrentUserDisplayName();
    }

    public void SignOut()
    {
        authMgr.SignOutUser();
    }
}
