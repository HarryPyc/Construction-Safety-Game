using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladder : MonoBehaviour
{
    #region Fields

    private Vector3 position;
    private Vector3 normal;
    private bool isSettled;
    private int posLabel;
    private float[] angle;
    private int ladderLabel;

    HintPointsShowed hintPointsShowed;

    #endregion

    #region Properties

    public void SetPosition(Vector3 val)
    {
        position = val;
    }

    public void SetNormal(Vector3 val)
    {
        normal = val;
    }

    public void SetLabel(int label)
    {
        ladderLabel = label;
    }

    public int GetLabel()
    {
        return ladderLabel;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        isSettled = false;
        posLabel = 0;
        angle = new float[] { 0.0f, 15.0f, 30.0f };

        // Set new ladder's material to transparent
        Vector4 tmp = GetComponent<Renderer>().material.color;
        tmp.w = 0.5f;
        GetComponent<Renderer>().material.color = tmp;

        // Add invoker
        hintPointsShowed = new HintPointsShowed();
        EventManager.AddShowHintPointsInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        // When the ladder is not settled
        if (!isSettled)
        {
            // Get mouse scroll event
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                SwitchPosition(-1);
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                SwitchPosition(1);
            }

            // Get mouse left click event
            if (Input.GetMouseButtonDown(0))
            {
                Settled();
            }
        }
    }

    void SwitchPosition(int toward)
    {
        if (!isSettled)
        {
            if ((posLabel > 0 && toward < 0) || (posLabel < 2 && toward > 0))
            {
                posLabel += toward;
                LadderTransform();
            }
        }
    }

    void LadderTransform()
    {
        // Set the ladder to the init position and rotation
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        transform.Rotate(ConfigurationUtils.LadderFixRotation, Space.World);
        transform.RotateAround(Vector3.zero, Vector3.up, Vector3.Angle(Vector3.forward, normal));
        transform.RotateAround(Vector3.zero, Vector3.Cross(normal, Vector3.up), angle[posLabel]);

        transform.Translate(new Vector3(0.0f, -ConfigurationUtils.LadderLength * (1.0f - Mathf.Cos((angle[posLabel] * (Mathf.PI)) / 180.0f)), 0.0f), Space.World);
        transform.Translate(position + normal * ConfigurationUtils.LadderWidth / 2.0f + new Vector3(0.0f, ConfigurationUtils.LadderLength - ConfigurationUtils.BuildingHeight, 0.0f), Space.World);
    }

    void Settled()
    {
        if (!isSettled)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().ShowHint(3);

            isSettled = true;
            Vector4 tmp = GetComponent<Renderer>().material.color;
            tmp.w = 1.0f;
            GetComponent<Renderer>().material.color = tmp;
            if (ladderLabel == ConfigurationUtils.LADDER && posLabel == 1)
            {
                gameObject.GetComponent<ClimbLadder>().willFall = false;
            }
            else
            {
                gameObject.GetComponent<ClimbLadder>().willFall = true;
            }
        }
    }

    void UnSettled()
    {
        if (isSettled)
        {
            isSettled = false;
            Vector4 tmp = GetComponent<Renderer>().material.color;
            tmp.w = 0.5f;
            GetComponent<Renderer>().material.color = tmp;
        }
    }

    public void OnMouseOver()
    {
        if (isSettled)
        {
            if (Input.GetMouseButtonUp(2))
            {
                GameObject UI = GameObject.FindGameObjectWithTag("UI");
                UI.GetComponent<UIManager>().ItemList.SetActive(true);
                GameObject itemList = UI.GetComponent<UIManager>().ItemList;
                itemList.GetComponent<ItemList>().AddItem(GetLabel());
                Debug.Log("Label = " + GetLabel());
                Destroy(gameObject);
                    
                GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().ShowHint(1);
            }
        }

    }

    void OnMouseEnter()
    {
        if(isSettled)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().ShowHint(3);
        }
    }


    //鼠标离开

    void OnMouseExit()
    {
        if (isSettled)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().ShowHint(1);
        }
    }

    public void AddShowHintPointsListener(UnityAction<int> listener)
    {
        hintPointsShowed.AddListener(listener);
    }
}