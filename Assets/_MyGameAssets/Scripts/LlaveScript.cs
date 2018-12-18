using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveScript : MonoBehaviour {

    int puntos = 250;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponentInParent<MickeyMouseScript>().tengoLlave = true;
            other.gameObject.GetComponentInParent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
            Destroy(gameObject);
        }
    }
}
