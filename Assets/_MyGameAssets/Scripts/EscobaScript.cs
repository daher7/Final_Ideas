using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscobaScript : MonoBehaviour {

    [SerializeField] int danyo = 25;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Colision");
            collision.gameObject.GetComponent<MickeyMouseScript>().QuitarSalud(danyo);
        }
    }
}
