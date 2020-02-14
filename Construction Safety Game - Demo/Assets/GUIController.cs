using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public GameObject[] LadderInfo;
    // Start is called before the first frame update

    public void CloseAll()
    {
        for(int i = 0; i < 3; i++)
        {
            LadderInfo[i].SetActive(false);
        }
    }

    public void ShowLadderInfo(int i)
    {
        CloseAll();
        LadderInfo[i].SetActive(true);
    }
}
