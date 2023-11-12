using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Player;
    public GameObject Proyectil;
    public float rango_disparo;
    public float intervalo_disparo;
    public bool can_shoot;

    // Start is called before the first frame update
    void Start()
    {
        can_shoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < rango_disparo)
        {
            if(can_shoot)
                StartCoroutine(Shoot()); 
        }
    }
    IEnumerator Shoot()
    {
        Instantiate(Proyectil, transform.position, Quaternion.identity);
        can_shoot=false;
        yield return new WaitForSeconds(intervalo_disparo);
        can_shoot=true;
    }
}
