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
    private Player_Anim Anim;


    void Start()
    {
        Control = GetComponent<ControlCharacter1>();
        Anim = gameObject.GetComponentInChildren<Player_Anim>();
        Camara = GameObject.FindWithTag("MainCamera").GetComponent<Player_Cambio>();
        if (Camara.Act)
        {
            Camara.Act = true;
        }
        StartIFrames = Iframes;
    }

    private void Update()
    {
        if(Camara.Act)
        {
            if (Camara.Vida <= 0)
            {
                SceneManager.LoadScene("Escena_06_Nivel_5");
                Destroy(Camara.gameObject);
            }
        }
        else
        {
            if (Camara.Vida <= 0)
            {
                RecargarEscenaActual();
                Destroy(Camara.gameObject);
            }
        }

        if (invulnerabilidad)
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
                Hit(25);
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
                Hit(15);
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

        if (!invulnerabilidad)
        {
            if (other.CompareTag("Trampa"))
            {
                Hit(15);
            }
        }
    }

    public void Hit(int daño)
    {
        Camara.Vida -= daño;
        invulnerabilidad = true;
        Anim.GolpeadoAnim();
        Control.EmpujarHaciaAtras(200);
    }
}
