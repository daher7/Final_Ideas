using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAlturaCamara : MonoBehaviour {

    [SerializeField] CameraFollow cambioCamera;
    int puntos = 100;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
            cambioCamera.gameObject.GetComponent<CameraFollow>().cambiarYcamara = true;
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
