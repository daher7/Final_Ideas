using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxScript : MonoBehaviour {

    GameObject mm;
    private void Start() {
        mm = GameObject.Find("MickeyMouse");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("KILLBOX");
            Vector3 position = GameControllerScript.ObtenerPosicion();
            print("POSICION RECUPERADA:" + position);
            other.gameObject.GetComponentInParent<MickeyMouseScript>().QuitarSalud(50);
            mm.transform.position = position;
            //other.transform.parent.position = position;
            //other.gameObject.transform.position = position;
            //other.gameObject.GetComponentInParent<Transform>().position = position;

        }
    }
}
