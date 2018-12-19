using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OggieBoogieScript : MonoBehaviour {
    [SerializeField] int salud = 100;
    [SerializeField] int danyo = 25;
    [SerializeField] int saludActual;

    [SerializeField] int puntos = 100;
    [SerializeField] GameObject player;
    [SerializeField] float distanceDetection = 6.0f;

    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField] ParticleSystem oggieParticles;
    [SerializeField] ParticleSystem oggieDieParticles;
    [SerializeField] float timeToDie = 5.0f;

    [SerializeField] AudioClip sonidoDolor;
    AudioSource fuenteAudio;

    private BoxCollider box;
    private CapsuleCollider capsule;

    public bool isDead = false;

    void Start() {
        nav = GetComponentInChildren<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        fuenteAudio = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider>();
        capsule = GetComponentInChildren<CapsuleCollider>();
        saludActual = salud;
    }

    void Update() {
        if (isDead == false && player != null) {
            if (Vector3.Distance(player.transform.position, this.transform.position) < distanceDetection) {
                nav.SetDestination(player.transform.position);
                if (nav.remainingDistance >= nav.stoppingDistance) {
                    anim.SetBool("isRunning", true);
                } else {
                    anim.SetBool("isRunning", false);
                }
            } else {
                anim.SetBool("isRunning", false);
            }
        }
    }

    public void RecibirDanyo(int danyo) {
        saludActual -= danyo;
        oggieParticles.Play();
        fuenteAudio.clip = sonidoDolor;
        fuenteAudio.Play();
        if (saludActual <= 0) {
            Morir();
        }
    }

    private void Morir() {
        isDead = true;
        nav.enabled = false;
        anim.SetTrigger("isDead");
        box.enabled = true;
        capsule.enabled = false;
        player.gameObject.GetComponent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
        Invoke("ActivarSistemaParticulas", timeToDie);
        Destroy(gameObject, 5f);
    }

    private void ActivarSistemaParticulas() {
        ParticleSystem ps = Instantiate(oggieDieParticles, transform.position, Quaternion.identity);
        ps.Play();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<MickeyMouseScript>().QuitarSalud(danyo);
        }
    }
}
