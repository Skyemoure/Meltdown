using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject[] Player;
    private Vector3 direction;
    private Rigidbody rb;
    public float force;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");

        direction = (Player[0].transform.position - transform.position).normalized;

        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction * force);
    }
}
