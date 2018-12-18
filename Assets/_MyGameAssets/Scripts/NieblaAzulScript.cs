using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieblaAzulScript : MonoBehaviour {

    [SerializeField] int danyo = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Pupita");
            //other.gameObject.GetComponent<MickeyMouseScript>().QuitarSalud(danyo);
            other.gameObject.GetComponentInParent<MickeyMouseScript>().QuitarSalud(danyo);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<MickeyMouseScript>().QuitarSalud(danyo);
            other.gameObject.GetComponentInParent<MickeyMouseScript>().QuitarSalud(danyo);
        }
    }

}
