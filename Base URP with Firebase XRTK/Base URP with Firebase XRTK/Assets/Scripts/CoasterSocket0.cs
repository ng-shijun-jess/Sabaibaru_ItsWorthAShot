using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterSocket0 : MonoBehaviour
{
    public string currentDrink;
    public bool drinkSnapped;

    public GameObject customerPrefab;
    private AICustomer1 customerScript;

    public void CheckDrink()
    {
        drinkSnapped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (drinkSnapped)
        {
            customerScript = customerPrefab.GetComponent<AICustomer1>();
            if (other.gameObject.name == "Milk" && currentDrink == "Milk")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
            else if (other.gameObject.name == "Beer" && currentDrink == "Beer")
            {
                Debug.Log("Coaster");
                customerScript.drinkGiven = true;
                drinkSnapped = false;
            }
            else if (other.gameObject.name == "Corba" && currentDrink == "Corba")
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
            customerScript = customerPrefab.GetComponent<AICustomer1>();
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
