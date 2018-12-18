using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuchilloScript : MonoBehaviour
{

    [SerializeField] int danyo = 25;
    [SerializeField] float tiempoVida = 0.5f;

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chesire"))
        {
            other.GetComponent<ChesireScript>().RecibirDanyo(danyo);
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Oggie"))
        {
            print("TeDOYOGGIE");
            other.GetComponentInParent<OggieBoogieScript>().RecibirDanyo(danyo);
            Destroy(gameObject);
        }

    }
}
