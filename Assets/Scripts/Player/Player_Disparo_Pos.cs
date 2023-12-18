using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Disparo_Pos : MonoBehaviour
{
    public Transform objetivo; // El objetivo al que quieres seguir la rotación

    void Update()
    {
        if (objetivo != null)
        {
            // Obtener la rotación del objetivo
            Quaternion rotacionObjetivo = Quaternion.LookRotation(objetivo.position - transform.position);

            // Aplicar la rotación al objeto, solo en la rotación
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotacionObjetivo.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
}
