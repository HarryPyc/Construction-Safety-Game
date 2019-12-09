using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minDistance = 10.0f;
    public float maxDistance = 20.0f;
    public float moveSpeed = 10.0f;
    public Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0 && m_camera.transform.position.z > minDistance)
            {
                m_camera.transform.position += m_camera.transform.forward * Input.GetAxis("Mouse ScrollWheel") * moveSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && m_camera.transform.position.z < maxDistance)
            {
                m_camera.transform.position += m_camera.transform.forward * Input.GetAxis("Mouse ScrollWheel") * moveSpeed;
            }
        }
    }
}
