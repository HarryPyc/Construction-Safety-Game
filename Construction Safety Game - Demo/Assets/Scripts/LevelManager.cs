using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public float transition_sec = 2.0f;
    public Camera cam;
    public NavMeshSurface surface;
    public List<GameObject> levels;
    public int levelIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GenerateLevel(levelIndex++);
    }
    public void GenerateLevel(int index)
    {
        
        Instantiate(levels[index]);
        StartCoroutine(MoveCamera(transition_sec));
        //surface.BuildNavMesh();
    }
    IEnumerator MoveCamera(float sec)
    {
        float speed = 10f / (sec / Time.fixedDeltaTime);
        Vector3 dir = speed * Vector3.up;
        float dis = 10f;
        while (dis > 0)
        {
            cam.transform.Translate(dir,Space.World);
            dis -= speed;
            yield return new WaitForFixedUpdate();
        }
    }
}
