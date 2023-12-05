using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerEnemigos : MonoBehaviour
{
    public Text tiempo;
    public float puntos;
    public float Tiempo_max;
    private bool starto = false;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(starto)
        {
            puntos += Time.deltaTime;

            tiempo.text = Mathf.Round(Tiempo_max - puntos).ToString();
        }
    }
    void OnCollisionEnter(Collision hielo)
    {
        //Se ejecuta cuando se inicia la colision

        if (hielo.gameObject.tag == "hielo")
        {
            starto = true;
        }

    }
}

