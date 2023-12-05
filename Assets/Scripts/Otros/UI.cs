using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public bool pausa;
    public RectTransform Menu; 
    void Start()
    {
        pausa = false; 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa = true;
        }

        if (pausa)
        {
            Time.timeScale = 0f;
            Menu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            Menu.gameObject.SetActive(false);
        }
    }

    public void Reanudar()
    {
        pausa = false;
    }
}
