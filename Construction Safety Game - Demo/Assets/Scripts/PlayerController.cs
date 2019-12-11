using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private bool isClimbing = false;
    private Animator animator;
    private NavMeshAgent agent;
    private Rigidbody rigidbody;
    private int layerMask = (1 << 9) | (1 << 10);
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

   
    public void StartClimb(Vector3 pos, bool willFall, GameObject ladder)
    {
        agent.enabled = false;
        Debug.Log(ladder.transform.rotation.eulerAngles.y);
        transform.Rotate(new Vector3(0, ladder.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y, 0));
        if (!willFall)
            StartCoroutine(Climb(pos));
        else
            StartCoroutine(Fall(pos,ladder));

    }
    IEnumerator Climb(Vector3 pos)
    {
        Vector3 dir =pos - transform.position;
        dir = dir.normalized;
        isClimbing = true;
        animator.SetBool("isClimbing", true);
        while (Vector3.Distance(transform.position,pos)>0.1f)
        {

            rigidbody.MovePosition(transform.position + dir*Time.fixedDeltaTime * 6.0f);
            yield return null;
        }
        isClimbing = false;
        animator.SetBool("isClimbing", false);
        agent.enabled = true;
        LevelManager.instance.GenerateLevel(1);
    }
    IEnumerator Fall(Vector3 pos, GameObject ladder)
    {
        Vector3 dir = pos - transform.position;
        dir = dir.normalized;
        isClimbing = true;
        animator.SetBool("isClimbing", true);
        pos = Vector3.Lerp(transform.position, pos, 0.5f);
        while (Vector3.Distance(transform.position, pos) > 0.1f)
        {

            rigidbody.MovePosition(transform.position + dir * Time.fixedDeltaTime * 6.0f);
            yield return null;
        }
        animator.SetBool("Fall", true);
        ladder.GetComponent<Rigidbody>().isKinematic = false;
        Camera.main.GetComponent<CameraController>().ShakeCamera();
        isClimbing = false;
        rigidbody.isKinematic = false;
        //animator.enabled = false;
       
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            Camera.main.GetComponent<CameraController>().ShakeCamera();
        }
    }*/
}
