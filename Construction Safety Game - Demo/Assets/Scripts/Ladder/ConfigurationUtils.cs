using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields

    public static ConfigurationData configurationData;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    /// 
    public static float BuildingHeight
    {
        get { return configurationData.BuildingHeight; }
    }

    public static Vector3 LadderFixRotation
    {
        get { return configurationData.LadderFixRotation; }
    }
    public static float LadderLength
    {
        get { return configurationData.LadderLength; }
    }

    public static float LadderWidth
    {
        get { return configurationData.LadderWidth; }
    }

    public static int LADDER
    {
        get { return configurationData.LADDER; }
    }

    public static int WLADDER
    {
        get { return configurationData.WLADDER; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
