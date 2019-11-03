using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCube : MonoBehaviour
{
    private Renderer renderer;
    public bool isNear;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear)
            renderer.material.SetColor("_Color", new Color(0, 1, 0, 0.5f+0.5f*Mathf.Sin(2*Time.fixedTime)));
        else
            renderer.material.SetColor("_Color", new Color(0, 1, 0, 0.5f ));
    }
}
