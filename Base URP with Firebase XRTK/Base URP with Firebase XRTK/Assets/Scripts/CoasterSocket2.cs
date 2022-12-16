using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterSocket2 : MonoBehaviour
{
    public string currentDrink;
    public bool drinkSnapped;

    // Check if WrongDrink coroutine is started
    bool coroutineStarted;

    public GameObject customerPrefab;
    private AICustomer1 customerScript;

    private Transform wrongDrinkCanvas;

    public void InitialiseCustomerScript()
    {
        Debug.Log("InitialiseCustomer");
        Transform customerTransform = customerPrefab.transform;
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
            if (other.gameObject.name == "Milk(Clone)" && currentDrink == "Milk")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name == "Beer(Clone)" && currentDrink == "Beer")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name == "Corba(Clone)" && currentDrink == "Corba")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
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
            }
            else if (other.gameObject.name == "Beer(Clone)" && currentDrink == "Beer(Clone)")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name == "Corba(Clone)" && currentDrink == "Corba(Clone)")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
                Destroy(other.gameObject);
            }
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
