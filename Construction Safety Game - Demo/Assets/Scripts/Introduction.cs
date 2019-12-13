using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Introduction : MonoBehaviour
{
    public Button Page1;
    public Button Page2;
    public Button Page3;
    public Button Page4;
    public Button Close;

    // Start is called before the first frame update
    void Start()
    {

        Page1.onClick.AddListener(delegate () {
            ShowUI(Page2.gameObject);
            ShowUI(Page1.gameObject);
        });

        Page2.onClick.AddListener(delegate () {
            ShowUI(Page3.gameObject);
            ShowUI(Page2.gameObject);
        });

        Page3.onClick.AddListener(delegate () {
            ShowUI(Page4.gameObject);
            ShowUI(Page3.gameObject);
        });

        Page4.onClick.AddListener(delegate () {
            ShowUI(Page1.gameObject);
            ShowUI(Page4.gameObject);
        });

        Close.onClick.AddListener(delegate ()
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().ShowHint(1);
            Destroy(gameObject);
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
