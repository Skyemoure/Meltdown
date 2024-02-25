using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Boton_Jugar()
    {
        SceneManager.LoadScene("Escena_01_Tutorial");
    }

    public void Boton_Salir()
    {
        Application.Quit();
    }
}
