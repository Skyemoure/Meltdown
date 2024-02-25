using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player_Camara : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] CinemachineComposer cameras;
    void Start()
    {
        //virtualCamera = GameObject.Find("cinemachineVC").GetComponent<CinemachineVirtualCamera>();
        cameras = virtualCamera.GetComponent<CinemachineComposer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            cameras.m_TrackedObjectOffset = new Vector3(1.5f, 1f);
        }
    }
}
