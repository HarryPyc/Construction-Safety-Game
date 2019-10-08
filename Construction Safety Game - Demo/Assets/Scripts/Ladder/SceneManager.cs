﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject hintPointPrefab;
    [SerializeField] GameObject ladderPrefab;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ConfigurationUtils.Initialize();

        EventManager.AddUndecidedLadderListener(AddUndecidedLadder);
        EventManager.AddShowHintPointsListener(ShowHintPoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowHintPoints(ConfigurationUtils.LADDER);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroyAllHintPoints();
        }
    }

    void DestroyAllHintPoints()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("HintPoint");
        for (int i = list.Length - 1; i >= 0; i--)
        {
            Destroy(list[i]);
        }
    }

    void ShowHintPoints(int label)
    {
        if(label == ConfigurationUtils.LADDER)
        {
            // First destroy all previous points
            DestroyAllHintPoints();

            // Get and set all hintPoints to show (will be a for loop to search for ConfigurationData)
            HintPointStruct hintPoint = new HintPointStruct(new Vector3(7.5f, 10.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), ConfigurationUtils.LADDER);
            GameObject newHintPoint = Instantiate(hintPointPrefab, hintPoint.position, Quaternion.identity);
            newHintPoint.GetComponent<HintPoint>().SetPosition(hintPoint.position);
            newHintPoint.GetComponent<HintPoint>().SetNormal(hintPoint.normal);
            newHintPoint.GetComponent<HintPoint>().SetLabel(hintPoint.label);

            hintPoint = new HintPointStruct(new Vector3(5.0f, 10.0f, 5.0f), new Vector3(1.0f, 0.0f, 0.0f), ConfigurationUtils.LADDER);
            newHintPoint = Instantiate(hintPointPrefab, hintPoint.position, Quaternion.identity);
            newHintPoint.GetComponent<HintPoint>().SetPosition(hintPoint.position);
            newHintPoint.GetComponent<HintPoint>().SetNormal(hintPoint.normal);
            newHintPoint.GetComponent<HintPoint>().SetLabel(hintPoint.label);
        }
    }

    void AddUndecidedLadder(Vector3 pos, Vector3 nom)
    {
        DestroyAllHintPoints();

        // Add new ladder to the hintpoint place
        GameObject newLadder = Instantiate(ladderPrefab, Vector3.zero, Quaternion.identity);

        newLadder.transform.Rotate(ConfigurationUtils.LadderFixRotation, Space.World);
        newLadder.transform.RotateAround(Vector3.zero, Vector3.up, Vector3.Angle(Vector3.forward, nom));
        newLadder.transform.Translate(pos + nom * ConfigurationUtils.LadderWidth / 2.0f + new Vector3(0.0f, ConfigurationUtils.LadderLength - ConfigurationUtils.BuildingHeight, 0.0f), Space.World);

        newLadder.GetComponent<Ladder>().SetNormal(nom);
        newLadder.GetComponent<Ladder>().SetPosition(pos);
    }
}
