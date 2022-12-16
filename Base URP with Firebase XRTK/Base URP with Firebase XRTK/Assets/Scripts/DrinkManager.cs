using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            StartCoroutine("WaitToDelete");
        }
    }

    IEnumerator WaitToDelete()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
        yield return null;
    }
}
