using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    Player_Attack MeleePlayerAttack;
    ControlCharacter1 control;
    public Animator m_Animator;
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
    }

    public void GolpeadoAnim()
    {
        {
            m_Animator.Play("hit");
        }
    }

    public void DisparoAnim()
    {
        control.ControlDisparo();
    }

    public void AtaqueAnim()
    {
        MeleePlayerAttack.ScriptAtaque();
    }

    public void DeathAnim()
    {
        m_Animator.Play("death");
    }
}
