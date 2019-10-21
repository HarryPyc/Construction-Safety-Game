using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button BtnTutorial;
    public Button BtnTool;

    public GameObject ScrollView;
    public GameObject ItemList;

    // Start is called before the first frame update
    void Start()
    {

        BtnTool.onClick.AddListener(delegate () {
            ShowUI(ItemList);
        });
        BtnTutorial.onClick.AddListener(delegate ()
        {
            ShowUI(ScrollView);
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
