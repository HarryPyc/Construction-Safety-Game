using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    //private Animator animator;
    private GameObject player;
    public GameObject itemList;

    private AudioSource[] m_AudioSource;

    [SerializeField]
    public GameObject doors;

    private bool isOpened;
    private bool isOpening;

    private int blendShapeWeight;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = gameObject.GetComponents<AudioSource>();

        isOpened = false;
        isOpening = false;

        blendShapeWeight = 0;

        //animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpening)
        {
            doors.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, ++blendShapeWeight);
            if (blendShapeWeight == 100) isOpening = false;
        }
        
    }
    private void OnMouseDown()
    {
        if(Vector3.Distance(transform.position,
            player.transform.position)<4 && isOpened == false)
        {
            print("OpenChest");
            //animator.SetTrigger("Open");
            isOpened = true;
            isOpening = true;

            m_AudioSource[0].Play();

            itemList.GetComponent<ItemList>().AddItem(ConfigurationUtils.LADDER);
            itemList.GetComponent<ItemList>().AddItem(ConfigurationUtils.WLADDER);
        }

    }
}
