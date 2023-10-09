using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrojarBotella : MonoBehaviour
{
    float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        tiempo = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tiempo -= Time.deltaTime;
        if ( tiempo < 0)
        {
            Destroy(gameObject);
        }
    }
}
