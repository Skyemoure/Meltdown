using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Player;
    public GameObject Proyectil;
    public float intervalo_disparo;
    public bool can_shoot;

    // Start is called before the first frame update
    void Start()
    {
        can_shoot = true;
        Player = GameObject.FindWithTag("Player");
    }

    IEnumerator Shoot()
    {
        Instantiate(Proyectil, transform.position, Quaternion.identity);
        can_shoot=false;
        yield return new WaitForSeconds(intervalo_disparo);
        can_shoot=true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (can_shoot)
                StartCoroutine(Shoot());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player_attack"))
        {
            Destroy(gameObject); ;
        }
    }
}
