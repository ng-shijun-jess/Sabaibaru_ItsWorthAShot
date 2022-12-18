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
        fbManager.GetLeaderboard(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
