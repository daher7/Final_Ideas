using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveScript : MonoBehaviour {

    int puntos = 250;
    [SerializeField] ParticleSystem particle;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponentInParent<MickeyMouseScript>().tengoLlave = true;
            other.gameObject.GetComponentInParent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
            ParticleSystem ps = Instantiate(particle, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(gameObject);
        }
    }
}
