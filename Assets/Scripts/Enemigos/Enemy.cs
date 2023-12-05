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

    public Vector3 Objetivo;

    public bool Act;


    [SerializeField]
    private float Vida;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agente.speed = speed_value;
        Vida = 50;
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

        Objetivo = Player.transform.position;

        if(Vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trampa"))
        {
            Vida -= 100;
        }
    }

    private void OnTriggerStay(Collider other)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player_attack"))
        {
            Vector3 direccionRetroceso = -transform.forward * 100 * Time.deltaTime;
            transform.Translate(direccionRetroceso, Space.World);
            Vida -= 25;
        }
    }
}
