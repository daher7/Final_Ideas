using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludItemScript : MonoBehaviour {

    [SerializeField] int salud = 50;
    [SerializeField] ParticleSystem particle;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //print("Te curo");
            other.GetComponentInParent<MickeyMouseScript>().RecibirSalud(salud);
            ParticleSystem ps = Instantiate(particle, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(gameObject);
        }
    }
}
