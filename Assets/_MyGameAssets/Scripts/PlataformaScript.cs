using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaScript : MonoBehaviour {

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
