using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField]Transform m_camera;
    private void Start() 
    {
        //カメラを検索
        m_camera = GameObject.Find("AR Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクトをカメラに向かせる
        transform.LookAt(m_camera); 
    }
}
