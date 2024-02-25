using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    private Enemy Script;

    void Start()
    {
        Script = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trampa"))
        {
            Script.Vida -= 100;
        }
    }
}
