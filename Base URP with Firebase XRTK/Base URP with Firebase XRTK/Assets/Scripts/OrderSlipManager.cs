using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderSlipManager : MonoBehaviour
{
    public GameObject[] orderSlips;
    public TextMeshProUGUI[] orderSlipText;

    public void OrderSlipEnable(int orderSlipIndex, int customerIndex)
    {
        for (int i = 0; i < 5; i++)
        {
            if (orderSlipIndex == i)
            {
                orderSlips[i].SetActive(true);
                if (customerIndex == 0)
                {
                    orderSlipText[i].text = "Beer";
                }

                if (customerIndex == 1)
                {
                    orderSlipText[i].text = "Corba Svedese";
                }

                if (customerIndex == 2)
                {
                    orderSlipText[i].text = "Milk";
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
}
