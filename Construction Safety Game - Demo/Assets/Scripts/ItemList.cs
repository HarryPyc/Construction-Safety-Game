using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] GameObject ladderIconPrefab;
    [SerializeField] GameObject wrongLadderIconPrefab;

    List<Vector3> itemPos = new List<Vector3>();
    List<GameObject> items = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        itemPos.Add(new Vector3(0.0f, 120.0f, 0.0f));
        itemPos.Add(new Vector3(0.0f, -40.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(int item)
    {
        if (item == ConfigurationUtils.LADDER)
        {
            GameObject prefabInstance = Instantiate(ladderIconPrefab);
            prefabInstance.transform.parent = this.transform;
            prefabInstance.transform.localPosition = itemPos[items.Count];
            prefabInstance.GetComponent<Item>().index = items.Count;
            prefabInstance.GetComponent<Item>().label = item;
            items.Add(prefabInstance);
        }
        else if (item == ConfigurationUtils.WLADDER)
        {
            GameObject prefabInstance = Instantiate(wrongLadderIconPrefab);
            prefabInstance.transform.parent = this.transform;
            prefabInstance.transform.localPosition = itemPos[items.Count];
            prefabInstance.GetComponent<Item>().index = items.Count;
            prefabInstance.GetComponent<Item>().label = item;
            items.Add(prefabInstance);
        }
    }

    public void DeleteItem(int index)
    {
        if (items.Count > index)
        {
            Destroy(items[index]);
            items.RemoveAt(index);
            for (int i = items.Count - 1; i >= 0; i--)
            {
                items[i].transform.localPosition = itemPos[i];
                items[i].GetComponent<Item>().index = i;
            }
        }
        else
        {
            Debug.Log("Fail to delete item because no item in itemlist.");
        }

    }
}
