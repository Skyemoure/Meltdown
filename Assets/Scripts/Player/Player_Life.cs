using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    [SerializeField]
    private float Vida;

    private float VidaMax;
    private ControlCharacter1 Control;

    public Image LifeBar;

    void Start()
    {
        Control = GetComponent<ControlCharacter1>();
        Vida = 100;
        VidaMax = 100;
    }

    // Update is called once per frame
    void Update()
    {
        LifeBar.fillAmount = Vida / VidaMax;

        if(Vida <= 0)
        {
            RecargarEscenaActual();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trampa") || collision.gameObject.CompareTag("Enemy"))
        {
            //Vector3 direccionRetroceso = -transform.forward * 100 * Time.deltaTime;
            //transform.Translate(direccionRetroceso, Space.World);
            Control.EmpujarHaciaAtras(200);
            Vida -= 25;
        }
    }

    public void RecargarEscenaActual()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
