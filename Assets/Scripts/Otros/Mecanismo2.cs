using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanismo2 : MonoBehaviour
{
    public GameObject Objeto1;
    public GameObject Objeto2;
    public GameObject Objeto3;
    public GameObject Objeto4;
    public GameObject Objeto5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(Objeto1);
            Destroy(Objeto2);
            Destroy(Objeto3);
            Destroy(Objeto4);
            Destroy(Objeto5);
        }
    }
}
