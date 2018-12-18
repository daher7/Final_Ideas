using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectaLlaveScript : MonoBehaviour {

    [SerializeField] Animator puertaAnimator;
    [SerializeField] GameObject puerta;
    [SerializeField] Text llaveText;

    private void Start() {
        // DEsactivamos el texto 
        llaveText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.GetComponentInParent<MickeyMouseScript>().tengoLlave) {
                print("HOLA");
                puertaAnimator.SetBool("AbreteSesamo", true);
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            llaveText.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            llaveText.gameObject.SetActive(false);
        }
    }
}
