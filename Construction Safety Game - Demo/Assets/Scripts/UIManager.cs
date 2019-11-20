using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button BtnTutorial;
    public Button BtnTool;
    public Button BtnSelectLevel;
    public Button BtnExitGame;

    public GameObject ScrollView;
    public GameObject LevelsView;
    public GameObject ItemList;
    public GameObject Introduction;

    // Start is called before the first frame update
    void Start()
    {
        if(ConfigurationUtils.ShowTutorial == 1)
        {
            Introduction.SetActive(true);
        }
        else
        {
            Introduction.SetActive(false);
        }

        BtnTool.onClick.AddListener(delegate () {
            ShowUI(ItemList);
        });
        BtnTutorial.onClick.AddListener(delegate ()
        {
            ShowUI(ScrollView);
        });
        BtnSelectLevel.onClick.AddListener(delegate ()
        {
            ShowUI(LevelsView);
            ShowUI(BtnTool.gameObject);
            ItemList.SetActive(false);
        });

        BtnExitGame.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowUI(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);
    }
}
