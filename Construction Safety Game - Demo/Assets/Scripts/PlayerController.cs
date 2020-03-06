using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public bool isFalling = false;
    public bool isWinning = false;

    private bool isClimbing = false;
    private Animator animator;
    private NavMeshAgent agent;
    private Rigidbody rigidbody;
    private AudioSource[] m_AudioSource;

    private int layerMask = (1 << 9) | (1 << 10);
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        m_AudioSource = gameObject.GetComponents<AudioSource>();


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

   
    public void StartClimb(Vector3 start, Vector3 end, bool willFall, GameObject ladder)
    {
        agent.enabled = false;
        Debug.Log(ladder.transform.rotation.eulerAngles.y);
        float angle = ladder.transform.rotation.eulerAngles.y == 0 ? ladder.transform.rotation.eulerAngles.y: 180 ;
        rigidbody.MovePosition(start);
        transform.Rotate(new Vector3(0, angle - transform.rotation.eulerAngles.y, 0));
        //if (ladder.transform.rotation.eulerAngles.x < 90 && ladder.transform.rotation.eulerAngles.x > 0)
        //    transform.Rotate(new Vector3(0, 180, 0));
        if (!willFall)
            StartCoroutine(Climb(end));
        else
            StartCoroutine(Fall(end,ladder));

    }
    IEnumerator Climb(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        dir = dir.normalized;
        isClimbing = true;
        animator.SetBool("isClimbing", true);
        while (Vector3.Distance(transform.position,pos)>0.1f)
        {

            rigidbody.MovePosition(transform.position + dir*Time.fixedDeltaTime * 6.0f);
            yield return null;
        }

        //m_AudioSource[2].Play();
        isWinning = true;
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

        // Play Sound Effect
        m_AudioSource[0].Play();
        m_AudioSource[1].Play();

        ladder.GetComponent<Rigidbody>().isKinematic = false;
        Camera.main.GetComponent<CameraController>().ShakeCamera();
        isClimbing = false;
        isFalling = true;
        rigidbody.isKinematic = false;
        //animator.enabled = false;
       
    }
   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9 )
        {
            animator.SetTrigger("FalltoGround");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 9 )
        {
            animator.SetTrigger("FalltoGround");
        }
    }
}
