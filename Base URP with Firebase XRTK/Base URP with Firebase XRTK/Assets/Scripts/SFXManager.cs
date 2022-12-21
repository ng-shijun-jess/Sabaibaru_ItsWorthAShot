using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource sfxBeerSnapped;
    public AudioSource sfxRudeCustomer;
    public AudioSource sfxTavernBGM;

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
    public void TavernBGMOFF()
    {
        sfxTavernBGM.Stop();
        Debug.Log("Tavern BGM audio has stopped");
    }
    public void TavernBGMOn()
    {
        sfxTavernBGM.Play();
        Debug.Log("Tavern BGM audio has stopped");
    }
}
