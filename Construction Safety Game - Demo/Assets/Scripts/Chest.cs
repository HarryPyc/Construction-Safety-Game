using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    public GameObject itemList;

    private bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(Vector3.Distance(transform.position,
            player.transform.position)<4 && isOpened == false)
        {
            print("OpenChest");
            animator.SetTrigger("Open");
            isOpened = true;

            itemList.GetComponent<ItemList>().AddItem(ConfigurationUtils.LADDER);
            itemList.GetComponent<ItemList>().AddItem(ConfigurationUtils.WLADDER);
        }

    }
}
