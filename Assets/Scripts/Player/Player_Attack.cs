using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject weapon;
    public float tiempo_ataque;
    public bool attacking = false;
    private float attackTimer = 0f;
    private Player_Cambio Camara;
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<Collider>().enabled = false;
        Camara = GameObject.FindWithTag("MainCamera").GetComponent<Player_Cambio>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
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
                attacking = false;
                attackTimer = 0f;
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            m_Animator.Play("attack");
        }
    }

    public void ScriptAtaque()
    {
        attacking = true;
        weapon.GetComponent<Collider>().enabled = true;
    }
}


