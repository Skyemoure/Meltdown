using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrojarBotella : MonoBehaviour
{
    float tiempo = 5f;
    float speed = 100f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
