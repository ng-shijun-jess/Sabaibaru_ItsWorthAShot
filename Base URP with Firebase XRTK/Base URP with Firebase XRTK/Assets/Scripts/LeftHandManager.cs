using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandManager : MonoBehaviour
{
    public GameObject coasterGroup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            coasterGroup.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            Debug.Log("Trigger");
            coasterGroup.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            coasterGroup.SetActive(false);
        }
    }

    public void HideCoaster()
    {
        coasterGroup.SetActive(false);
    }
}
