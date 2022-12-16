using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // If Drink collides with floor
        if (collision.gameObject.tag == "Floor")
        {
            StartCoroutine("WaitToDelete");
        }
    }

    IEnumerator WaitToDelete()
    {
        // Destroy Drink after 10 seconds
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
        yield return null;
    }
}
