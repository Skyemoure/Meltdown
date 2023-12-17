using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    ControlCharacter1 control;
    Animator m_Animator;
    public float move;

    void Start()
    {
        //Get the animator, which you attach to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlCharacter1>();
    }

    void Update()
    {
        //Translate the left and right button presses or the horizontal joystick movements to a float
        move = control.animSpeed;

        
        m_Animator.SetFloat("Speed", move );
    }
}
