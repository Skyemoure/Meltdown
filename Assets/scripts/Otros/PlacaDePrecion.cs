using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePrecion : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer SpikeMesh;
    public BoxCollider SpikeCollider;
    
    void Start()
    {
        SpikeMesh.enabled = false;
        SpikeCollider.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpikeMesh.enabled = true;
            SpikeCollider.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpikeMesh.enabled = false;
            SpikeCollider.enabled = false;
        }
    }

}
