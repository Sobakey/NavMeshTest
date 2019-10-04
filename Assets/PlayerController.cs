using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public float velocity;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        velocity = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speed", velocity);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }          
        }
    }
}
