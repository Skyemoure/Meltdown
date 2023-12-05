using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePrecion : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer SpikeMesh;
    public BoxCollider SpikeCollider;
    public bool Activate;
    private int Timer = 70;
    
    void Start()
    {
        SpikeMesh.enabled = false;
        SpikeCollider.enabled = false;
    }

    void Update()
    {
        if(Timer <= 0)
        {
            SpikeMesh.enabled = true;
            SpikeCollider.enabled = true;
        }
        else
        {
            SpikeMesh.enabled = false;
            SpikeCollider.enabled = false;
        }

        if(Timer <= -70)
        {
            Activate = false;
        }

        if (Activate)
        {
            Timer--;
        }
        if(!Activate)
        {
            Timer = 70;
        }    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Activate = true;
        }

    }

}
