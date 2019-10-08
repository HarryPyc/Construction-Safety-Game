using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float buildingHeight = 10.0f;
    static Vector3 ladderFixRotation = new Vector3(110.0f, 0.0f, 90.0f);
    static float ladderLength = 12.0f;
    static float ladderWidth = 1.0f;
    static int ladderCode = 1;

    #endregion

    #region Properties

    public float BuildingHeight
    {
        get { return buildingHeight; }
    }

    public Vector3 LadderFixRotation
    {
        get { return ladderFixRotation; }    
    }

    public float LadderLength
    {
        get { return ladderLength; }
    }

    public float LadderWidth
    {
        get { return ladderWidth; }
    }

    public int LADDER
    {
        get { return ladderCode; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationDataFields(values);

        }
        catch (Exception e)
        {
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        /*
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifetime = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockProbility = float.Parse(values[8]);
        bonusBlockProbility = float.Parse(values[9]);
        freezerBlockProbility = float.Parse(values[10]);
        speedupBlockProbility = float.Parse(values[11]);
        ballsNumber = int.Parse(values[12]);
        freezerEffectDuration = float.Parse(values[13]);
        speedUpDuration = float.Parse(values[14]);
        speedUpFactor = float.Parse(values[15]);
        */
    }

    #endregion
}
