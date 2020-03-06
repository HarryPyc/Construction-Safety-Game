using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Feedback : MonoBehaviour
{
    public Button LadderTooShort;
    public Button WrongAngle;
    public Button Close;

    // Start is called before the first frame update
    void Start()
    {

        Close.onClick.AddListener(delegate ()
        {
            LadderTooShort.gameObject.SetActive(false);
            WrongAngle.gameObject.SetActive(false);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowFeedback(int type)
    {
        if(type == 1)
        {
            ShowUI(LadderTooShort.gameObject);
        }
        if (type == 2)
        {
            ShowUI(WrongAngle.gameObject);
        }
    }

    public void ShowUI(GameObject UI)
    {
        UI.SetActive(true);
    }
}
