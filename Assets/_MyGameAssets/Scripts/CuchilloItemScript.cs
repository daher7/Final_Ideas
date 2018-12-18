using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuchilloItemScript : MonoBehaviour {

    [SerializeField] int speedRotation = 3;
    int puntos = 50;
   

    private void Update() {
        transform.Rotate(new Vector3(0, -1, 0) * speedRotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInParent<MickeyMouseScript>().puedoDisparar = true;
            other.GetComponentInParent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
            Destroy(gameObject);
        }
    }
}
