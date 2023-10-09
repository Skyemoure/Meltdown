using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class ControlCharacter1 : MonoBehaviour
{
    static public int botellas;


    private void Start()
    {

        
        botellas = 5;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            botellas += 5;
            Destroy(other.gameObject);


        }
    }



}
