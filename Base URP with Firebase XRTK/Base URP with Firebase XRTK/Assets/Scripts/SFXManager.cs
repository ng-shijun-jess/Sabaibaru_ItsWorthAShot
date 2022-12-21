using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource sfxBeerSnapped;
    public AudioSource sfxRudeCustomer;
    public AudioSource sfxTavernBGM;

    //When called, Beer snapped Audio plays
    public void BeerSnappedSFXOn()
    {
        sfxBeerSnapped.Play();
        Debug.Log("beer snapped audio is playing");
    }

    //When called, Rude customer Audio plays
    public void RudeCustomerSFXOn()
    {
        sfxRudeCustomer.Play();
        Debug.Log("Rude customer audio is playing");
    }
    //When called, Rude customer Audio stops playing
    public void RudeCustomerSFXOff()
    {
        sfxRudeCustomer.Stop();
        Debug.Log("Rude customer audio has stopped");
    }
    //When called, Tavern BGM Audio stops playing
    public void TavernBGMOFF()
    {
        sfxTavernBGM.Stop();
        Debug.Log("Tavern BGM audio has stopped");
    }
    //When called, Tavern BGM Audio plays
    public void TavernBGMOn()
    {
        sfxTavernBGM.Play();
        Debug.Log("Tavern BGM audio has stopped");
    }
}
