using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agente;
    public GameObject Player;
    public GameObject Origin;
    public float speed_value;

    public Vector3 V;

    public bool Act;

    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agente.speed = speed_value;
    }

    void Update()
    {
        if (Act)
        {
            agente.destination = Player.transform.position;
        }
        else
        {
            agente.destination = Origin.transform.position;
        }

        V = Player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Act = true;
        } 

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Act = false;
        }
    }
}
