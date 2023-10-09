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
    public Transform mano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1) && !aimCamera.activeInHierarchy)
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);

            RaycastHit hit;
            
            if (Physics.Raycast(follow2.transform.position, follow2.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (Input.GetMouseButton(2))
                {

                    Instantiate(botella, mano.transform.position, transform.rotation);


                }
               


            }


           
        }
        else if (!Input.GetMouseButton(1) && !mainCamera.activeInHierarchy)
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
            

        }

    }

   
    
}

