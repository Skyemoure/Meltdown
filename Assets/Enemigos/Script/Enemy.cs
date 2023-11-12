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

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(agente.transform.position, (Player.transform.position - agente.transform.position).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agente.destination = Origin.transform.position;
        }
        else if (Vector3.Distance(Player.transform.position, agente.transform.position) < distance_value)
        {
            agente.destination = Player.transform.position;
        }
        else
        {
            agente.destination = Origin.transform.position;
        }
    }
}
