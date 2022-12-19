using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource sfxBeerSnapped;
    public AudioSource sfxRudeCustomer;

    public void BeerSnappedSFXOn()
    {
        sfxBeerSnapped.Play();
        Debug.Log("beer snapped audio is playing");
    }

    public void RudeCustomerSFXOn()
    {
        sfxRudeCustomer.Play();
        Debug.Log("Rude customer audio is playing");
    }
    public void RudeCustomerSFXOff()
    {
        sfxRudeCustomer.Stop();
        Debug.Log("Rude customer audio has stopped");
    }
}
