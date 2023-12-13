using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private ControlCharacter1 Control;
    private Player_Cambio Camara;


    private bool Act;
    void Start()
    {
        Control = GetComponent<ControlCharacter1>();
        Camara = GameObject.FindWithTag("MainCamera").GetComponent<Player_Cambio>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trampa") || collision.gameObject.CompareTag("Enemy"))
        {
            Control.EmpujarHaciaAtras(200);
            Camara.Vida -= 25;
        }
    }

    public void RecargarEscenaActual()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hielo"))
        {
            Camara.Act = true;
            Camara.Vida = 500;
        }
    }
}
