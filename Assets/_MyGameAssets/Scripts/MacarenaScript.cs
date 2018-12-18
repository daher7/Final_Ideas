using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacarenaScript : MonoBehaviour {

    Animator anim;
    [SerializeField] int time = 4;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Invoke("ActivarAnimacion", time);
    }

    private void ActivarAnimacion()
    {
        anim.SetBool("isDancing", true);
        Invoke("CargarMenuPrincipal", 15f);
    }

    private void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
	
	
}
