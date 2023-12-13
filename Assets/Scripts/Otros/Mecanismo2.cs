using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanismo2 : MonoBehaviour
{
    public GameObject Puente1;
    public GameObject Puente2;
    public GameObject Puente3;
    public GameObject Puente4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(Puente1);
            Destroy(Puente2);
            Destroy(Puente3);
            Destroy(Puente4);
        }
    }
}
