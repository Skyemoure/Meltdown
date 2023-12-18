using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrojarBotella : MonoBehaviour
{
    float speed = 30f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
