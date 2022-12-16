using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderSlipManager : MonoBehaviour
{
    public GameObject[] orderSlips;
    public TextMeshProUGUI[] orderSlipText;

    // Reference CustomerSpawner Script
    public CustomerSpawner customerSpawner;

    public CoasterSocket0 coasterSocket0;

    public void OrderSlipEnable(int orderSlipIndex, int customerIndex)
    {
        for (int i = 0; i < 5; i++)
        {
            if (orderSlipIndex == i && customerIndex != 3)
            {
                orderSlips[i].SetActive(true);
                if (customerIndex == 0 || customerIndex == 4)
                {
                    orderSlipText[i].text = "Beer";
                    string j = "coasterSocket" + i.ToString();
                    if (j == "coasterSocket0")
                    {
                        coasterSocket0.currentDrink = "Beer";
                        coasterSocket0.CheckDrink();
                    }
                }

                if (customerIndex == 1 || customerIndex == 5)
                {
                    orderSlipText[i].text = "Corba Svedese";
                    string j = "coasterSocket" + i.ToString();
                    if (j == "coasterSocket0")
                    {
                        coasterSocket0.currentDrink = "Corba";
                        coasterSocket0.CheckDrink();
                    }
                }

                if (customerIndex == 2 || customerIndex == 6)
                {
                    orderSlipText[i].text = "Milk";
                    string j = "coasterSocket" + i.ToString();
                    if (j == "coasterSocket0")
                    {
                        coasterSocket0.currentDrink = "Milk";
                        coasterSocket0.CheckDrink();
                    }
                }
            }
        }
    }

    public void OrderSlipDisable(int orderSlipIndex)
    {
        for (int i = 0; i < 5; i++)
        {
            if (orderSlipIndex == i)
            {
                orderSlips[i].SetActive(false);
            }
        }
    }

    public void SetSocket0Customer()
    {
        coasterSocket0.customerPrefab = customerSpawner.customer;
        coasterSocket0.InitialiseCustomerScript();
    }
}
