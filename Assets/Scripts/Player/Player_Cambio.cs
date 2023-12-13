using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Cambio : MonoBehaviour
{
    public float Vida;
    public float VidaMax;
    public Image LifeBar;
    public bool Act;

    public int botellas;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainCamera");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Vida = 100;
        VidaMax = 100;
        botellas = 5;
    }
    void Update()
    {
        LifeBar.fillAmount = Vida / VidaMax;

        if (Act)
        {
            VidaMax = 500;
            Vida -= Time.deltaTime;
            LifeBar.color = Color.blue;
        }

        if (Vida <= 0)
        {
            RecargarEscenaActual();
        }
    }
    public void RecargarEscenaActual()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
