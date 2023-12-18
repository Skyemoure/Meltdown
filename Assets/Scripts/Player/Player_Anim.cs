using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    Player_Attack MeleePlayerAttack;
    ControlCharacter1 control;
    Animator m_Animator;
    public float move;
    public float health = 100f;

    void Start()
    {
        //Get the animator, which you attach to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlCharacter1>();
        MeleePlayerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack>();
    }

    void Update()
    {
        //Translate the left and right button presses or the horizontal joystick movements to a float
        move = control.animSpeed;

        m_Animator.SetFloat("Speed", move);

        if (control.disparo == true)
        {
            //m_Animator.SetTrigger("Tirar");
        }

        if (MeleePlayerAttack.attacking == true)
        {
            m_Animator.SetTrigger("attack");
        }
        if (health <= 0)
        {
            m_Animator.Play("death");
        }

    }

    public void GolpeadoAnim()
    {
        {
            m_Animator.SetTrigger("hit");
        }
    }

    public void DisparoAnim()
    {
        control.ControlDisparo();
    }
}
