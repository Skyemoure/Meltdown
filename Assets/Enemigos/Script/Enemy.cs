using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public Transform objetivo;
    private UnityEngine.AI.NavMeshAgent agente;
    public GameObject Player;
    public GameObject Origin;
    public float distance_value;
    public float speed_value;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agente.speed = speed_value;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agente.destination = Player.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agente.destination = Origin.transform.position;
        }
    }
}
