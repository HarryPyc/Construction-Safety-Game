using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

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
        Debug.Log(ConfigurationUtils.InitialLevel);
        for(int i=1;i<=ConfigurationUtils.InitialLevel;i++)
        {
            GenerateLevel(i);
            levelIndex++;
        }
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

    public void ReadConfigFile(out string names, out string values)
    {
        StreamReader input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationData.ConfigurationDataFileName));

        names = input.ReadLine();
        values = input.ReadLine();

        input.Close();
    }

    public void WriteConfigFile(string csvNames, string csvValues)
    {
        StreamWriter sc = new StreamWriter(Path.Combine(
                Application.streamingAssetsPath, ConfigurationData.ConfigurationDataFileName), false);

        sc.WriteLine(csvNames);
        sc.WriteLine(csvValues);

        sc.Close();
    }

    public void ResetToLevel(int l)
    {
        string csvNames;
        string csvValues;

        ReadConfigFile(out csvNames, out csvValues);

        string[] values = csvValues.Split(',');
        values[0] = l.ToString();
        values[1] = 0.ToString();

        csvValues = "";
        for (int i = 0; i < values.Length; i++)
        {
            csvValues += values[i];
            if (i < values.Length - 1)
            {
                csvValues += ',';
            }
        }

        WriteConfigFile(csvNames, csvValues);

        SceneManager.LoadScene("SampleScene");
    }

    public void ResetConfigurationDataAndExit()
    {
        string csvNames;
        string csvValues;

        ReadConfigFile(out csvNames, out csvValues);

        string[] values = csvValues.Split(',');
        values[0] = 0.ToString();
        values[1] = 1.ToString();

        csvValues = "";
        for (int i = 0; i < values.Length; i++)
        {
            csvValues += values[i];
            if (i < values.Length - 1)
            {
                csvValues += ',';
            }
        }

        WriteConfigFile(csvNames, csvValues);
        Application.Quit();
    }
    
}
