using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterSocket2 : MonoBehaviour
{
    public string currentDrink;
    public bool drinkSnapped;

    // Check if WrongDrink coroutine is started
    bool coroutineStarted;

    // Reference Customer Prefab
    public GameObject customerPrefab;
    // Reference Customer Script
    private AICustomer1 customerScript;

    // Reference Text Canvas on customer prefab
    private Transform wrongDrinkCanvas;

    //Reference to SFX Manager script
    private GameObject sfxManager;
    private SFXManager sfxManagerScript;

    public void InitialiseCustomerScript()
    {
        Debug.Log("InitialiseCustomer");
        // Set Customer Prefab transform to find child canvas
        Transform customerTransform = customerPrefab.transform;
        // Find Child Text Canvas
        wrongDrinkCanvas = customerTransform.Find("Text Canvas");
        customerScript = customerPrefab.GetComponent<AICustomer1>();
    }
    public void CheckDrink()
    {
        Debug.Log("Check Drink");
        drinkSnapped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (drinkSnapped)
        {
            //Find the SFX and play Beer snapped audio
            sfxManager = GameObject.Find("SFXManager");
            sfxManagerScript = sfxManager.GetComponent<SFXManager>();
            sfxManagerScript.BeerSnappedSFXOn();

            if (other.gameObject.name == "Milk(Clone)" && currentDrink == "Milk")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
                // Add Money here
            }
            else if (other.gameObject.name == "Beer(Clone)" && currentDrink == "Beer")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
                // Add Money Here
            }
            else if (other.gameObject.name == "Corba(Clone)" && currentDrink == "Corba")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
                // Add Money Here
            }
            else
            {
                StartCoroutine(WrongDrink(other.gameObject));
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (drinkSnapped)
        {
            if (other.gameObject.name == "Milk(Clone)" && currentDrink == "Milk(Clone)")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
                // Add Money Here
            }
            else if (other.gameObject.name == "Beer(Clone)" && currentDrink == "Beer(Clone)")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
                // Add Money Here
            }
            else if (other.gameObject.name == "Corba(Clone)" && currentDrink == "Corba(Clone)")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
                // Add Money Here
            }
            // If Given Drink is wrong
            else
            {
                if (!coroutineStarted)
                {
                    Debug.Log("Coroutine");
                    coroutineStarted = true;
                    StartCoroutine(WrongDrink(other.gameObject));
                }
            }
        }
    }

    IEnumerator WrongDrink(GameObject drink)
    {
        wrongDrinkCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Debug.Log("OFF");
        wrongDrinkCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Destroy(drink);
        coroutineStarted = false;
        yield return null;
    }
}