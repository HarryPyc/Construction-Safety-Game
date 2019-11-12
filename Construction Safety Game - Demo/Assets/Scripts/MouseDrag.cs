using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public GameObject target;
    private Outline outline;
    private int layerMask = 1 << 10;
    private bool isNear;

    public GameObject pointLight;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();   
    }

    // Update is called once per frame

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
    private void OnMouseDown()
    {
        target.SetActive(true);
        pointLight.SetActive(false);
    }
    private void OnMouseUp()
    {
        target.SetActive(false);
        if (isNear)
        {
            transform.position = target.transform.position;
            outline.enabled = false;
            pointLight.SetActive(true);
            /*Destroy(target.GetComponentInParent<MouseDrag>());
            Destroy(this);*/
        }
    }
    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity,layerMask))
        {
            Vector3 pos = hit.point;
            pos.y = transform.position.y;
            transform.position = pos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target)
        {
            isNear = true;
            target.GetComponent<HintCube>().isNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target)
        {
            isNear = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            isNear = false;
            target.GetComponent<HintCube>().isNear = false;
        }
    }
}
