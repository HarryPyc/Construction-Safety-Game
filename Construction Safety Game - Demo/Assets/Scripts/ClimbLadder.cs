using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public bool willFall = false;
    public Transform start, end;
    private GameObject player;
    private bool hasClimb = false;
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
        
        if (hasClimb)
            return;
        if(Vector3.Distance(player.transform.position, start.position) < 2)
        {
            print("Climb");
            
            player.GetComponent<CharacterController>().StartClimb(end.position,willFall,gameObject);
            
            hasClimb = true;
        }
    }
}
