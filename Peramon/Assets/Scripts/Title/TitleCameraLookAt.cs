using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraLookAt : MonoBehaviour
{
    [SerializeField]Transform m_camera;
    private void Start() 
    {
        m_camera = GameObject.Find("AR Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_camera);
        transform.position = m_camera.position + new Vector3(0,-5,19); 
    }
}
