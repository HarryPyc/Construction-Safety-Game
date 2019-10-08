using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class ProjectLODLightmaps : MonoBehaviour
{

    public Renderer m_Renderer;

    public void OnEnable()
    {
        var renderer = GetComponent<Renderer>();

        if (renderer && m_Renderer)
        {
            renderer.lightmapScaleOffset = m_Renderer.lightmapScaleOffset;
            renderer.lightmapIndex = m_Renderer.lightmapIndex;
            //print("Projected lightmap on " + gameObject.name);
        }
    }
}
