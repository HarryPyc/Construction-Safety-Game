using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int index;
    public int label;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        print("Clicked! " + index);
        GameObject.FindGameObjectWithTag("LadderManager").GetComponent<Level1Manager>().itemIndex = index;
        GameObject.FindGameObjectWithTag("LadderManager").GetComponent<Level1Manager>().itemChoose = label;
        GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().ShowHint(2);
    }
}
