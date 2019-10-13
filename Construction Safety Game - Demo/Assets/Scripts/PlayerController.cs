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
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject.layer == 9)
            {
                agent.SetDestination(hit.point);
            }
        }
    }

   
    public void StartClimb(Vector3 pos, bool willFall, GameObject ladder)
    {
        if (!willFall)
            StartCoroutine(Climb(pos));
        else
            StartCoroutine(Fall(pos,ladder));

    }
    IEnumerator Climb(Vector3 pos)
    {
        Vector3 dir =pos - transform.position;
        dir = dir.normalized;
        agent.enabled = false;
        isClimbing = true;
        while (Vector3.Distance(transform.position,pos)>0.1f)
        {

            rigidbody.MovePosition(transform.position + dir*Time.fixedDeltaTime * 6.0f);
            yield return null;
        }
        isClimbing = false;
        agent.enabled = true;
        LevelManager.instance.GenerateLevel(1);
    }
    IEnumerator Fall(Vector3 pos, GameObject ladder)
    {
        Vector3 dir = pos - transform.position;
        dir = dir.normalized;
        agent.enabled = false;
        isClimbing = true;
        pos = Vector3.Lerp(transform.position, pos, 0.5f);
        while (Vector3.Distance(transform.position, pos) > 0.1f)
        {

            rigidbody.MovePosition(transform.position + dir * Time.fixedDeltaTime * 6.0f);
            yield return null;
        }
        ladder.GetComponent<Rigidbody>().isKinematic = false;
        isClimbing = false;
        rigidbody.isKinematic = false;
        animator.enabled = false;
       
    }
}
