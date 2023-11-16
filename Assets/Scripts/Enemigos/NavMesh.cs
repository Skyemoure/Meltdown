using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    //public Transform objetivo;
    private NavMeshAgent agente;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        //agente.destination = objetivo.position;

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
            {
                agente.destination = hit.point;
            }
        }
    }
}
