using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public bool willFall = false;
    public Transform start, end;
    public bool ready = false;
    private GameObject player;
    private bool hasClimb = false;
    public int fallType;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
        if (hasClimb || !ready)
            return;
        Vector2 p = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 s = new Vector2(start.position.x, start.position.z);
        if(Vector2.Distance(p,s) < 2)
        {
            if (willFall)
            {
                GameObject UI = GameObject.FindGameObjectWithTag("UI");
                UI.GetComponent<UIManager>().ShowFeedback(fallType);
            }
            else
            {
                print("Climb");
                player.GetComponent<PlayerController>().StartClimb(start.position, end.position, willFall, gameObject);
                hasClimb = true;
            }
        }
    }
}
