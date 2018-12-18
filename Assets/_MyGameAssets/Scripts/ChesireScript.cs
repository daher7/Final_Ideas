using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChesireScript : MonoBehaviour {
    [SerializeField] int salud = 100;
    [SerializeField] int danyo = 25;
    [SerializeField] int saludActual;

    [SerializeField] int puntos = 100;
    [SerializeField] GameObject player;
    [SerializeField] float distanceDetection = 6.0f;
    
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField] ParticleSystem chesireParticles;
    [SerializeField] ParticleSystem chesireDieParticles;
    [SerializeField] float timeToDie = 5.0f;
    private CapsuleCollider capsule;
    private BoxCollider box;

    [SerializeField] AudioClip sonidoDolor;
    AudioSource fuenteAudio;

    public bool isDead = false;

    void Start() {
        capsule = GetComponent<CapsuleCollider>();
        box = GetComponentInChildren<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        fuenteAudio = GetComponent<AudioSource>();
        //chesireParticles = GetComponentInChildren<ParticleSystem>();

        saludActual = salud;
    }

    void Update() {
        if (isDead == false && player != null) {
            if (Vector3.Distance(player.transform.position, this.transform.position) < distanceDetection) {
                nav.SetDestination(player.transform.position);
                if (nav.remainingDistance >= nav.stoppingDistance) {
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isIdle", false);
                } else {
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isIdle", true);
                }
            } else {
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);
            }
        }

    }

    public void RecibirDanyo(int danyo) {
        saludActual -= danyo;
        fuenteAudio.clip = sonidoDolor;
        fuenteAudio.Play();
        chesireParticles.Play();
        if (saludActual <= 0) {
            Morir();
        }
    }

    private void Morir() {
        isDead = true;
        nav.enabled = false;
        anim.SetTrigger("isDead");
        capsule.enabled = false;
        box.enabled = true;
        player.gameObject.GetComponent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
        Invoke("ActivarSistemaParticulas", timeToDie);
        Destroy(gameObject, 5f);
    }

    private void ActivarSistemaParticulas() {
        ParticleSystem ps = Instantiate(chesireDieParticles, transform.position, Quaternion.identity);
        ps.Play();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<MickeyMouseScript>().QuitarSalud(danyo);
        }
    }
}
