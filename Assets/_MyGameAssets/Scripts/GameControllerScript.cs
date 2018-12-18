using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    // Declaracion de constantes
    private const string XPOS = "xPos";
    private const string YPOS = "yPos";
    private const string ZPOS = "zPos";

    // Guardamos la posicion del jugador
    public static void AlmacenarPosicion(Vector3 posicion)
    {
        PlayerPrefs.SetFloat(XPOS, posicion.x);
        PlayerPrefs.SetFloat(YPOS, posicion.y);
        PlayerPrefs.SetFloat(ZPOS, posicion.z);
        PlayerPrefs.Save();
    }
    public static Vector3 ObtenerPosicion()
    {
        // Validamos que previamente haya un guardado
        Vector3 posicion;
        if (PlayerPrefs.HasKey(XPOS) && PlayerPrefs.HasKey(YPOS))
        {
            float x = PlayerPrefs.GetFloat(XPOS);
            float y = PlayerPrefs.GetFloat(YPOS);
            float z = PlayerPrefs.GetFloat(ZPOS);
            posicion = new Vector3(x, y, z);
            print(x + ":" + y);
        }
        else
        {
            posicion = Vector3.zero;
        }
        return posicion;
    }
}
