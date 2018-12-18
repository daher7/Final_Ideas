using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("CHECKPOINT");
            GameControllerScript.AlmacenarPosicion(other.gameObject.transform.position);
            print("Almacenando:" + other.gameObject.transform.position);
        }
    }
}
