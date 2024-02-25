using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa2 : MonoBehaviour
{
    public bool Act;
    public Transform PosA;
    public Transform PosB;
    public GameObject Enemigo;
    public float Velocidad;

    void Start()
    {
        if(Act)
        {
            StartCoroutine(MoverObjeto());
        }

    }

    IEnumerator MoverObjeto()
    {
        while (true)
        {
            float tiempoPasado = 0f;
            Vector3 puntoInicial = PosA.position;
            Vector3 puntoFinal = PosB.position;

            while (tiempoPasado < Velocidad)
            {
                tiempoPasado += Time.deltaTime;
                Enemigo.transform.position = Vector3.Lerp(puntoInicial, puntoFinal, tiempoPasado / Velocidad);
                yield return null;
            }

            Transform temp = PosA;
            PosA = PosB;
            PosB = temp;

            yield return new WaitForSeconds(1.0f);
        }
    }
}

