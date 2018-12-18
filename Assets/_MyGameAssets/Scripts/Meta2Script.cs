using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta2Script : MonoBehaviour
{
    private void Start() {
        //ResetearMeta();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponentInParent<MickeyMouseScript>().puntosTemporales > PlayerPrefs.GetInt("puntosGanados2"))
            {
                other.gameObject.GetComponentInParent<MickeyMouseScript>().puntuacionActual = other.gameObject.GetComponentInParent<MickeyMouseScript>().puntosTemporales;
                PlayerPrefs.SetInt("puntosGanados2", other.gameObject.GetComponentInParent<MickeyMouseScript>().puntuacionActual);
            }
            SceneManager.LoadScene(3);
        }
    }

    public void ResetearMeta()
    {
        PlayerPrefs.SetInt("nivelDesbloqueado", 0);
    }
}

