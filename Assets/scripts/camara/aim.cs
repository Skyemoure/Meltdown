using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
 
    
    public GameObject mainCamera;
    public GameObject aimCamera;
   
    public GameObject follow2;
    public GameObject follow1;
    public GameObject botella;
    public GameObject mira;

    Vector3 dir;
    GameObject i;
    public Transform mano;
    private Player_Cambio Camara;
    void Start()
    {
        Camara = GameObject.FindWithTag("MainCamera").GetComponent<Player_Cambio>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0) && Camara.botellas > 0)
            {
                i = Instantiate(botella, mano.transform.position, Quaternion.identity);
                dir = mira.transform.position - mano.transform.position;
                i.GetComponent<Rigidbody>().AddForce(dir * 100f, ForceMode.Force);
                Camara.botellas -= 1;
                print(Camara.botellas);
            }

        }
    }

   
    
}

