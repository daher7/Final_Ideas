using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    [SerializeField] Text puntosNivel1;
    [SerializeField] Text puntosNivel2;
    [SerializeField] GameObject panel;
    public static int nivelesDesbloqueados = 0;

    private void Start() {
        PlayerPrefs.GetInt("nivelDesbloqueado");
        //PlayerPrefs.GetInt("puntosGanados");
        //ResetearPlayerPrefs();
        puntosNivel1.text = PlayerPrefs.GetInt("puntosGanados").ToString();
        puntosNivel2.text = PlayerPrefs.GetInt("puntosGanados2").ToString();
        if (PlayerPrefs.GetInt("nivelDesbloqueado") != 0) {
            panel.SetActive(true);
        }
    }

    public void QuitGame() {
        SceneManager.LoadScene(0);
    }

    public void StartLevel1() {
        SceneManager.LoadScene(1);
    }

    public void StartLevel2() {
        SceneManager.LoadScene(2);
    }

    void ResetearPlayerPrefs () {
        PlayerPrefs.SetInt("puntosGanados", 0);
        PlayerPrefs.SetInt("puntosGanados2", 0);
        PlayerPrefs.SetInt("nivelDesbloqueado", 0);
        PlayerPrefs.Save();
    }
}
