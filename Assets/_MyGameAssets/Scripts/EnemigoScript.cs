using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoScript : MonoBehaviour {

    [SerializeField] int salud = 100;
    public int danyo = 25;
    [SerializeField] int saludActual;
    // [SerializeField] Transform player;
    [SerializeField] int puntos = 100;
    public ParticleSystem particles;
    public GameObject player;
    public bool isDead = false;

    private NavMeshAgent nav;
    public Animator anim;
    public CapsuleCollider capsule;

    public float distanceDetection = 6.0f;

    private void Start()
    {
        saludActual = salud;
        particles = GetComponentInChildren<ParticleSystem>();
        capsule = GetComponentInChildren<CapsuleCollider>();
        nav = GetComponentInChildren<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }


    public void RecibirDanyo(int danyo/*, Vector3 hitPoint*/)
    {
        saludActual -= danyo;
        //chesireParticles.transform.position = hitPoint;
        particles.Play();
        if (saludActual <= 0)
        {
            Morir();
        }
    }


    private void Morir()
    {
        isDead = true;
        nav.enabled = false;
        anim.SetTrigger("isDead");
        capsule.enabled = false;
        player.gameObject.GetComponent<MickeyMouseScript>().IncrementarPuntuacion(puntos);
        Destroy(gameObject, 5f);
    }


}
