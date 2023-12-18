using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrojarBotella : MonoBehaviour
{
    float tiempo = 5f;
    float speed = 30f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

}
