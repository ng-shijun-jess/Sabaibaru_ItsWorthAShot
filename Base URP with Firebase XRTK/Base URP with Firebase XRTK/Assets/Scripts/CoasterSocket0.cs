using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterSocket0 : MonoBehaviour
{
    public string currentDrink;
    public bool drinkSnapped;

    public GameObject customerPrefab;
    private AICustomer1 customerScript;

    public void InitialiseCustomerScript()
    {
        Debug.Log("InitialiseCustomer");
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
            }
            else if (other.gameObject.name == "Beer(Clone)" && currentDrink == "Beer")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
            else if (other.gameObject.name == "Corba(Clone)" && currentDrink == "Corba")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (drinkSnapped)
        {
            if (other.gameObject.name == "Milk" && currentDrink == "Milk")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
            else if (other.gameObject.name == "Beer" && currentDrink == "Beer")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
            else if (other.gameObject.name == "Corba" && currentDrink == "Corba")
            {
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
        }
    }
}
