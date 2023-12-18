using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour
{
    public void Boton_Jugar()
    {
        SceneManager.LoadScene("Escena_01_Tutorial");
    }

    public void Boton_Salir()
    {
        Application.Quit();
    }
}
