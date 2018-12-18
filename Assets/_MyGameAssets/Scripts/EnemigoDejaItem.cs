using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDejaItem : MonoBehaviour {

    [SerializeField] GameObject llaveItem;
    bool estaGenerado = false;
    private void Update()
    {
        if (!estaGenerado && GetComponent<OggieBoogieScript>().isDead) {
                Instantiate(llaveItem, transform.position, Quaternion.identity);
                estaGenerado = true;
        }
    }

}
