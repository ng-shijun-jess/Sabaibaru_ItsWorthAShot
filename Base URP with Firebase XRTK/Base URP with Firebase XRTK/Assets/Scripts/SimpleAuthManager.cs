using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//importing directives for auth
using Firebase;
using Firebase.Auth;//using firebase auth service
using Firebase.Extensions;//For threading purposes
using Firebase.Database; //Firebase real time database
using TMPro; //TextMesh Pro
using UnityEngine.UI; //UI handling
using UnityEditor.SceneManagement; //scene loading
public class SimpleAuthManager : MonoBehaviour
{
    //Firebase references
    public FirebaseAuth auth;

    //retrieve user text
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField usernameInput;

    //setup buttons and UI
    public GameObject signUpBtn;
    public GameObject signInBtn;
    public GameObject forgetPasswordBtn;

    private void Awake()
    {
        InitializeFirebase();
    }

    //handle Firebase in the start
    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
    }
    
    public void SignUpNewUser()
    {
        Debug.Log("Sign Up method...");
        string email = emailInput.text.Trim();
        string password = passwordInput.text.Trim();

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if(task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Sorry, there was an error creating your new Account, ERROR: " + task.Exception);
            }

            else if(task.IsCompleted)
            {
                FirebaseUser newPlayer = task.Result;
                Debug.LogFormat("NewPlayer Details {0} {1}", newPlayer.UserId, newPlayer.Email);
            }
        });
    }

    public void SignInUser()
    {
        Debug.Log("Sign In method...");
        string email = emailInput.text.Trim();
        string password = passwordInput.text.Trim();
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
         {
             if (task.IsFaulted || task.IsCanceled)
             {
                 Debug.LogError("Sorry, there was an error signing in your account, ERROR: " + task.Exception);
             }
             else if (task.IsCompleted)
             {
                 FirebaseUser currentPlayer = task.Result;
                 Debug.LogFormat("Welcome to It's Worth A Shot {0} :: {1}", currentPlayer.UserId, currentPlayer.Email);
             }
         });
    }

    public void SignOutUser()
    {
        Debug.Log("Sign Out method...");
        if (auth.CurrentUser != null)
        {
            auth.SignOut();
        }
    }

    public void ForgetPassword()
    {
        string email = emailInput.text.Trim();

        auth.SendPasswordResetEmailAsync(email).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Sorry,there was an error sending a password reset, ERROR: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Forget password email sent successfully...");
            }
        });
        Debug.Log("Forget password method...");
    }
}
