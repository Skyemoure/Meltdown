using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AtacarAnim()
    {
        {
            anim.SetTrigger("attack");
        }
    }
    public void AtacarADistanciaAnim()
    {
        {
            anim.SetTrigger("Tirar");
        }
    }
    public void MuerteAnim()
    {
        {
            anim.SetTrigger("death");
        }
    }
    public void GolpeadoAnim()
    {
        {
            anim.SetTrigger("hit");
        }
    }

}
