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
using UnityEngine.SceneManagement; //scene loading
using System.Threading.Tasks;
using System;

using System.Text.RegularExpressions;

public class SimpleAuthManager : MonoBehaviour
{
    //Firebase references
    public FirebaseAuth auth;
    public DatabaseReference dbReference;

    //retrieve user text
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField usernameInput;

    //setup buttons and UI
    public GameObject signUpBtn;
    public GameObject signInBtn;
    public GameObject forgetPasswordBtn;
    public GameObject signOutBtn;

    public TextMeshProUGUI errorMsgContent;

    private void Awake()
    {
        InitializeFirebase();
    }

    //handle Firebase in the start
    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    
    public async void SignUpNewUser()
    {
        string email = emailInput.text.Trim();
        string password = passwordInput.text.Trim();

        if(ValidateEmail(email) && ValidatePassword(password))
        {
            FirebaseUser newPlayer = await SignUpNewUserOnly(email, password);

            string username = usernameInput.text;

            if (newPlayer != null)
            {
                await CreateNewSimplePlayer(newPlayer.UserId, username, username, newPlayer.Email);
                await UpdatePlayerDisplayName(username); //update user's display name in auth service
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            errorMsgContent.text = "Error in Signing Up.Invalid email or password";
            errorMsgContent.gameObject.SetActive(true);
        }
        
    }
    
    public async Task<FirebaseUser> SignUpNewUserOnly(string email,string password)
    {
        Debug.Log("Sign Up method...");
        

        FirebaseUser newPlayer = null;
        await auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if(task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Sorry, there was an error creating your new Account, ERROR: " + task.Exception);
            }

            else if(task.IsCompleted)
            {
                newPlayer = task.Result;

                Debug.LogFormat("NewPlayer Details {0} {1}", newPlayer.UserId, newPlayer.Email);
            }
        });
        return newPlayer;
    }

    public async Task CreateNewSimplePlayer(string uuid, string displayName,
       string userName, string email)
    {
        SimpleGamePlayer newPlayer = new SimpleGamePlayer(displayName, userName, email);
        Debug.LogFormat("Player details : {0}", newPlayer.PrintPlayer());

        //root/players/$uuid
        await dbReference.Child("players/" + uuid).SetRawJsonValueAsync(newPlayer.SimpleGamePlayerToJson());

        //update auth player with new display name -> tagging along the username input field
        //UpdatePlayerDisplayName(displayName);
    }

    public async Task UpdatePlayerDisplayName(string displayName)
    {
        if(auth.CurrentUser != null)
        {
            UserProfile profile = new UserProfile { 
                DisplayName = displayName 
            };
            await auth.CurrentUser.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was cancelled");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileasync encountered an error: " + task.Exception);
                    return;
                }
                Debug.Log("User profile updated successfully");
                Debug.LogFormat("Checking current user display name from auth {0}", GetCurrentUserDisplayName());
            });
        }
    }
 

    public string GetCurrentUserDisplayName()
    {
        return auth.CurrentUser.DisplayName;
    }

    public void SignInUser()
    {
        Debug.Log("Sign In method...");
        string email = emailInput.text.Trim();
        string password = passwordInput.text.Trim();

        if(ValidateEmail(email) && ValidatePassword(password))
        {
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
                    SceneManager.LoadScene(1);
                }
            });
        }
        else
        {
            errorMsgContent.text = "Error in Signing in. Invalid email / password";

        }
        
    }

    public void SignOutUser()
    {
        Debug.Log("Sign Out method...");
        if (auth.CurrentUser != null)
        {
            Debug.LogFormat("Auth user {0} {1}", auth.CurrentUser.UserId, auth.CurrentUser.Email);

            //get current index of a scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            auth.SignOut();
            if(currentSceneIndex == 0)
            {
                SceneManager.LoadScene(0);
            }

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

    public FirebaseUser GetCurrentUser()
    {
        return auth.CurrentUser;
    }

    ///<summary>
    /// Simple client side email validation
    ///</summary>
    ///<param name="email"></param>
    ///<returns></returns>
    public bool ValidateEmail(string email)
    {
        bool isValid = false;

        //for all emails have @
        const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        if (email != "" && Regex.IsMatch(email, pattern, options))
        {
            isValid = true;
        }

        return isValid;
    }

    public bool ValidatePassword (string password)
    {
        bool isValid = false;

        //length of password at least 6 characters
        if(password != "" && password.Length >= 6)
        {
            isValid = true;
        }
        return isValid;
    }

    //handles user sign in errors
    public string HandleSigninError(Task<FirebaseUser> task)
    {
        string errorMsg = "";

        if (task.Exception != null)
        {
            FirebaseException firebaseEx = task.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            errorMsg = "Sign in Fail\n";
            switch (errorCode)
            {
                //if email input is null
                case AuthError.MissingEmail:
                    errorMsg += "Missing an email.. ";
                    break;
                //if password is wrong
                case AuthError.WrongPassword:
                    errorMsg += "Password is wrong..!";
                    break;
                //if password input is null
                case AuthError.MissingPassword:
                    errorMsg += "Password is missing";
                    break;
                //if email is wrong
                case AuthError.InvalidEmail:
                    errorMsg += "Invalid email used";
                    break;
                //if no such user exists
                case AuthError.UserNotFound:
                    errorMsg += "User is not found";
                    break;
                //for any other error case
                default:
                    errorMsg += "Issue in authentication: " + errorCode;
                    break;
            }
            Debug.Log("Error message " + errorMsg);
        }

        return errorMsg;
    }
}
