using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private float rotationSpeed; // Velocidad de rotación, puedes ajustarla en el inspector

    void Update()
    {
        rotationSpeed++;
        transform.rotation = Quaternion.Euler(-125f, rotationSpeed, 0f);
    }
}
