using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
    public Image prefabImagenVida;
    public GameObject panelVidas;
    public MickeyMouseScript script;
    public GameObject player;
    Image[] imagenesVida;
    private int numeroVidas;

    // REFERENCIA AL GAMEOVER y RESTART
    [SerializeField] Text gameOverText;
    private bool gameOver;
    private bool restart;
    private bool playerVivo = true;

    void Start() {
        gameOver = false;
        restart = false;
        // DEsactivamos los textos de game over
        gameOverText.gameObject.SetActive(false);
        // Para saber las vidas que tiene el personaje necesitamos acceder al script del Player
        numeroVidas = script.GetVidas();
        imagenesVida = new Image[numeroVidas];
        // Recorremos el array con las vidas
        for (int i = 0; i < imagenesVida.Length; i++) {
            imagenesVida[i] = Instantiate(prefabImagenVida, panelVidas.transform);
        }
    }
    
    public void RestarVida() {
        numeroVidas = script.GetVidas();
        for (int i = numeroVidas; i < imagenesVida.Length; i++) {
            imagenesVida[i].color = new Color32(160, 160, 160, 128);
            if (numeroVidas == 0) {
                MickeyMouseScript.Destroy(player, 0.1f);
                GameOver();
                print("MUERTO");
            }
        }
    }

    public void SumarVida() {
        numeroVidas = script.GetVidas();
        print("SUMAR VIDA:" + numeroVidas);
        for (int i = 0; i < numeroVidas; i++) {
            imagenesVida[i].color = new Color32(255, 255, 255, 255);
        }
    }

    public void GameOver() {
        playerVivo = false;
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
    }

    public void QuitGame() {
        SceneManager.LoadScene(0);
    }

    public void RestartGame() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLevel1() {
        SceneManager.LoadScene(1);
    }

    public void StartLevel2() {
        SceneManager.LoadScene(2);
    }

}