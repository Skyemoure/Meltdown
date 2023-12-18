using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class cameraGuille : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vc;
    [SerializeField] CinemachineComposer cameras;
    void Start()
    {
        //vc = GameObject.Find("cinemachineVC").GetComponent<CinemachineVirtualCamera>();
        cameras = vc.GetComponent<CinemachineComposer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           cameras.m_TrackedObjectOffset = new Vector3(1.5f, 1f);
        }
    }
}
