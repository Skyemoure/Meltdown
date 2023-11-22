using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject weapon;
    public float tiempo_ataque;
    private bool attacking = false;
    private float attackTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<Collider>().enabled = false;
        weapon.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= tiempo_ataque)
            {
                weapon.GetComponent<Collider>().enabled = false;
                weapon.GetComponent<MeshRenderer>().enabled = false;
                attacking = false;
                Debug.Log("dejo de pegar");
                attackTimer = 0f;
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            attacking = true;
            weapon.GetComponent<Collider>().enabled = true;
            weapon.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("estoy pegando");
        }
    }
}

