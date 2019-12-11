using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minDistance = 10.0f;
    public float maxDistance = 20.0f;
    public float moveSpeed = 10.0f;
    public Camera m_camera;
    public float shakeDuration = 0.1f;
    [Range(0.0f, 2.0f)]
    public float shakeIntensity = 0.5f;
    
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
    public void ShakeCamera()
    {
        StartCoroutine(Shake(shakeDuration, shakeIntensity));
    }

    IEnumerator Shake(float duration, float intensity)
    {
        Vector3 pos = transform.position;
        while(duration > 0)
        {
            transform.position = pos + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)) * intensity;
            duration -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = pos;
    }
}
