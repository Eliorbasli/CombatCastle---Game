using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EagleMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && animator.GetInteger("Status") != 2)
        {
            animator.SetInteger("Status", 1); // starts flying
            agent.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetInteger("Status", 4);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetInteger("Status", 5);
        }

        //sets the new path for motion and start the motion
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position); // Here A* is used to get path to target

            //showing the path
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);



        }
    }
}
