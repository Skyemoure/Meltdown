using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanismo1 : MonoBehaviour
{
    public GameObject Puente;

    void Start()
    {
        Puente.transform.position = new Vector3(0,-10,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player_attack"))
        {
            Puente.transform.position = new Vector3(0, 0, 0);
        }
    }
}
