using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private ControlCharacter1 Control;
    private Player_Cambio Camara;
    public bool invulnerabilidad;
    private int Iframes = 25;
    private int StartIFrames;

    void Start()
    {
        Control = GetComponent<ControlCharacter1>();
        Camara = GameObject.FindWithTag("MainCamera").GetComponent<Player_Cambio>();
        if (Camara.Act)
        {
            Camara.Act = true;
            Camara.Vida = 120;
        }
        StartIFrames = Iframes;
    }

    private void Update()
    {
        if (Camara.Vida <= 0)
        {
            RecargarEscenaActual();
            Destroy(Camara.gameObject);
        }

        if(invulnerabilidad)
        {
            Iframes--;
        }

        if(Iframes < 0)
        {
            invulnerabilidad = false;
            Iframes = StartIFrames;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!invulnerabilidad)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Control.EmpujarHaciaAtras(200);
                Camara.Vida -= 25;
                invulnerabilidad = true;
            }
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
            Camara.Vida = 350;
        }

        if (!invulnerabilidad)
        {
            if (other.CompareTag("Trampa"))
            {
                Control.EmpujarHaciaAtras(200);
                Camara.Vida -= 15;
                invulnerabilidad = true;
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zona_de_Calor"))
        {
            if (Camara.Act)
            {
                Camara.Vida -= Time.deltaTime * 5;
            }
        }
    }
}
