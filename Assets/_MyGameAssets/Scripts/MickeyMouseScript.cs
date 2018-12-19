using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MickeyMouseScript : MonoBehaviour {

    //MOVIMIENTO
    [SerializeField] float maxSpeed = 6.0f;
    [SerializeField] bool yendoDerecha = true;
    [SerializeField] float xDirection;
    Rigidbody rigidMickey;

    // ANIMACIONES
    Animator anim;

    // SALTO
    [SerializeField] float yDirection;
    [SerializeField] float jumpSpeed = 600.0f;
    [SerializeField] bool enSuelo = true;
    [SerializeField] Transform ground;
    [SerializeField] float longRaycast = 0.5f;

    // VIDA
    [SerializeField] int saludActual = 100;
    [SerializeField] int saludMaxima = 100;
    [SerializeField] int vidas = 3;
    [SerializeField] int vidasMaximas = 3;
    [SerializeField] Slider saludSlider;
    [SerializeField] UIScript uiScript;

    // DISPARAR
    [SerializeField] Transform ptoGeneracion;
    [SerializeField] GameObject prefabCuchillo;
    [SerializeField] int fuerza;
    public bool puedoDisparar;
    [SerializeField] float tiempoEntreDisparos = 1f;
    float tiempoAtaque;

    // PUNTUACION
    public int puntuacionActual;
    [SerializeField] Text textPuntuacion;
    public int puntosTemporales = 0;

    // SONIDOS
    [SerializeField] AudioClip sonidoSalto;
    [SerializeField] AudioClip sonidoDisparo;
    AudioSource fuenteAudio;

    // ABRIR PUERTA
    public bool tengoLlave = false;

    void Start() {
        rigidMickey = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        fuenteAudio = GetComponent<AudioSource>();
        saludActual = saludMaxima;
        vidas = vidasMaximas;
        puedoDisparar = false;
        tiempoAtaque = tiempoEntreDisparos;
        // Para que aparezca la puntuacion inicial
        textPuntuacion.text = "" + puntosTemporales.ToString();

    }

    void Update() {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");

        // Salto con RayCast
        EstarEnSuelo();

        if (enSuelo && Input.GetButtonDown("Jump")) {
            print("Puedo Saltar");
            anim.SetTrigger("isJumping");
            rigidMickey.AddForce(new Vector2(0, jumpSpeed));
            fuenteAudio.clip = sonidoSalto;
            fuenteAudio.Play();
            //rigidMickey.AddForce(Vector3.up * jumpSpeed);
        }

        if (Input.GetButtonDown("Fire1") && puedoDisparar) {
            IntentoDeAtaque();
        }
    }

    private void FixedUpdate() {
        if (Mathf.Abs(xDirection) > 0.01f) {
            rigidMickey.velocity = new Vector2(xDirection * maxSpeed, rigidMickey.velocity.y);
        }
        if (xDirection > 0.0f && !yendoDerecha) {
            DarLaVuelta();
        } else if (xDirection < 0.0f && yendoDerecha) {
            DarLaVuelta();
        }
        anim.SetFloat("Speed", Mathf.Abs(xDirection));
    }

    void DarLaVuelta() {
        yendoDerecha = !yendoDerecha;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    private void EstarEnSuelo() {
        RaycastHit lanzoRaycast;
        Vector3 groundCheck = ground.transform.position;
        //Debug.DrawRay(groundCheck, Vector3.down * longRaycast, Color.green, 1);
        if (Physics.Raycast(groundCheck, Vector3.down, out lanzoRaycast, longRaycast)) {
            if (lanzoRaycast.transform.gameObject.tag != "Player") {
                enSuelo = true;
            }
        } else {
            enSuelo = false;
        }
        print(gameObject.tag);
    }

    private void IntentoDeAtaque() {
        tiempoAtaque += Time.deltaTime;
        if (tiempoAtaque >= tiempoEntreDisparos) {
            tiempoAtaque = 0;
            // Genera disparo, ataca, lanza
            Disparar();
        }
    }

    // Disparar
    private void Disparar() {
        GameObject proyectil = Instantiate(prefabCuchillo, ptoGeneracion.position, ptoGeneracion.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerza);
        fuenteAudio.clip = sonidoDisparo;
        fuenteAudio.Play();
    }

    // Funcion para recibir puntos
    public void IncrementarPuntuacion(int puntuacionGanada) {
        puntosTemporales += puntuacionGanada;
        textPuntuacion.text = "" + puntosTemporales.ToString();
        //puntuacionActual = puntosTemporales;
    }
    // Funcion para recibir salud
    public void RecibirSalud(int saludSumada) {
        saludActual += saludSumada;
        if (saludActual > saludMaxima) {
            saludActual = saludMaxima;
        }
        saludSlider.value = saludActual;
    }
    // Funcion para recibir daño

    public void QuitarSalud(int danyo) {
        saludActual -= danyo;
        if (saludActual <= 0) {
            vidas--;
            saludActual = saludMaxima;
            uiScript.RestarVida();
            if (vidas <= 0 && saludActual <= 0) {
                //Morir();
            }
            print("Pierdes una vida");
        }
        saludSlider.value = saludActual;
    }

    // Funcion para recibir vida
    public void RecibirVida(int vidaSumada) {
        vidas += vidaSumada;

        if (vidas > vidasMaximas) {
            vidas = vidasMaximas;
        }
        uiScript.SumarVida();
    }
    // Mostrar vidas al UI
    public int GetVidas() {
        return this.vidas;
    }

    // Morir
    public void Morir() {
        saludActual = 0;
        saludSlider.value = saludActual;
        Destroy(gameObject);
    }
}
