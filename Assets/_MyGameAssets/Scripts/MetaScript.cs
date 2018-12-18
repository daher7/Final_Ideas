using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaScript : MonoBehaviour {

    
    private void Start() {
        //ResetearMeta();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (other.gameObject.GetComponentInParent<MickeyMouseScript>().puntosTemporales > PlayerPrefs.GetInt("puntosGanados")) {
                other.gameObject.GetComponentInParent<MickeyMouseScript>().puntuacionActual = other.gameObject.GetComponentInParent<MickeyMouseScript>().puntosTemporales;
                PlayerPrefs.SetInt("puntosGanados", other.gameObject.GetComponentInParent<MickeyMouseScript>().puntuacionActual);
            }
            PlayerPrefs.SetInt("nivelDesbloqueado", MainMenuScript.nivelesDesbloqueados = 1);
            SceneManager.LoadScene(2);
            PlayerPrefs.Save();
        }
    }

    public void ResetearMeta() {
        PlayerPrefs.SetInt("puntosGanados", 0);
    }
}
