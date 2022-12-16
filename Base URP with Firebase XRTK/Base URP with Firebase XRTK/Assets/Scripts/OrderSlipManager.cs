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
    public CoasterSocket1 coasterSocket1;
    public CoasterSocket2 coasterSocket2;
    public CoasterSocket3 coasterSocket3;
    public CoasterSocket4 coasterSocket4;

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
                    if (j == "coasterSocket1")
                    {
                        coasterSocket1.currentDrink = "Beer";
                        coasterSocket1.CheckDrink();
                    }
                    if (j == "coasterSocket2")
                    {
                        coasterSocket2.currentDrink = "Beer";
                        coasterSocket2.CheckDrink();
                    }
                    if (j == "coasterSocket3")
                    {
                        coasterSocket3.currentDrink = "Beer";
                        coasterSocket3.CheckDrink();
                    }
                    if (j == "coasterSocket4")
                    {
                        coasterSocket4.currentDrink = "Beer";
                        coasterSocket4.CheckDrink();
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
                    if (j == "coasterSocket1")
                    {
                        coasterSocket1.currentDrink = "Corba";
                        coasterSocket1.CheckDrink();
                    }
                    if (j == "coasterSocket2")
                    {
                        coasterSocket2.currentDrink = "Corba";
                        coasterSocket2.CheckDrink();
                    }
                    if (j == "coasterSocket3")
                    {
                        coasterSocket3.currentDrink = "Corba";
                        coasterSocket3.CheckDrink();
                    }
                    if (j == "coasterSocket4")
                    {
                        coasterSocket4.currentDrink = "Corba";
                        coasterSocket4.CheckDrink();
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
                    if (j == "coasterSocket1")
                    {
                        coasterSocket1.currentDrink = "Milk";
                        coasterSocket1.CheckDrink();
                    }
                    if (j == "coasterSocket2")
                    {
                        coasterSocket2.currentDrink = "Milk";
                        coasterSocket2.CheckDrink();
                    }
                    if (j == "coasterSocket3")
                    {
                        coasterSocket3.currentDrink = "Milk";
                        coasterSocket3.CheckDrink();
                    }
                    if (j == "coasterSocket4")
                    {
                        coasterSocket4.currentDrink = "Milk";
                        coasterSocket4.CheckDrink();
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
    public void SetSocket1Customer()
    {
        coasterSocket1.customerPrefab = customerSpawner.customer;
        coasterSocket1.InitialiseCustomerScript();
    }
    public void SetSocket2Customer()
    {
        coasterSocket2.customerPrefab = customerSpawner.customer;
        coasterSocket2.InitialiseCustomerScript();
    }
    public void SetSocket3Customer()
    {
        coasterSocket3.customerPrefab = customerSpawner.customer;
        coasterSocket3.InitialiseCustomerScript();
    }
    public void SetSocket4Customer()
    {
        coasterSocket4.customerPrefab = customerSpawner.customer;
        coasterSocket4.InitialiseCustomerScript();
    }
}
