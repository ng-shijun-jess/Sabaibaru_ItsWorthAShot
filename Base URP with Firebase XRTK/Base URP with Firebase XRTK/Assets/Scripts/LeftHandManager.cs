using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandManager : MonoBehaviour
{
    public GameObject[] coasters;

    private MeshRenderer renderer;

    private void Start()
    {
        for (int i = 0; i < coasters.Length; i++)
        {
            renderer = coasters[i].GetComponent<MeshRenderer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            for (int i = 0; i < coasters.Length; i++)
            {
                renderer = coasters[i].GetComponent<MeshRenderer>();
                renderer.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            for (int i = 0; i < coasters.Length; i++)
            {
                renderer = coasters[i].GetComponent<MeshRenderer>();
                renderer.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Drink")
        {
            for (int i = 0; i < coasters.Length; i++)
            {
                renderer = coasters[i].GetComponent<MeshRenderer>();
                renderer.enabled = false;
            }
            HideCoaster();
        }
    }

    public void HideCoaster()
    {
        for (int i = 0; i < coasters.Length; i++)
        {
            renderer = coasters[i].GetComponent<MeshRenderer>();
            renderer.enabled = false;
        }
    }
}
