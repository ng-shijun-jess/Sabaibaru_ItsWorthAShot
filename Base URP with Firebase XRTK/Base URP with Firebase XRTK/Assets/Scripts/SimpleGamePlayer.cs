using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleGamePlayer
{
    //properties of our SimpleGamePlayer
    public string userName;
    public string displayName;
    public string email;
    public bool active;
    public long lastLoggedIn;
    public long createdOn;
    public long updatedOn;

    //empty constructor
    public SimpleGamePlayer()
    {

    }
    
    /// <summary>
    /// constructor to create a new player with active as true
    /// Timestamps are being logged
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="displayName"></param>
    /// <param name="email"></param>
    /// <param name="active"></param>
    public SimpleGamePlayer(string userName, string displayName, string email, bool active = true)
    {
        this.userName = userName;
        this.displayName = displayName;
        this.email = email;
        this.active = active;

        //timestamp properties
        var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        this.lastLoggedIn = timestamp;
        this.createdOn = timestamp;
        this.updatedOn = timestamp;
    }

    /// <summary>
    /// simple helper function convert object to JSON
    /// </summary>
    /// <returns></returns>
    //helper functions
    public string SimpleGamePlayerToJson()
    {
        return JsonUtility.ToJson(this);
    }

    //simple helper function to print player details
    /// <summary>
    /// return player details
    /// </summary>
    /// <returns></returns>
    public string PrintPlayer()
    {
        return String.Format("Player details: {0} \n User Name: {1}\n Email: {2}\n Active: {3}",
            this.displayName, this.userName, this.email, this.active
            );
    }
    
}
