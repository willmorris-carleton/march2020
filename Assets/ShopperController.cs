using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShopperController : MonoBehaviour
{

    public Transform goal;
    public Rigidbody hipsRB;
    public bool isAlive { get; private set; }

    private Animator animator;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            updateNavAgentDestination();
            setAnimatorVariables();
        }
    }

    public void killShopper()
    {
        agent.enabled = false;
        animator.enabled = false;
        isAlive = false;
        ShopperSpawn.currentNumberOfShoppers--;
        Destroy(gameObject, 5f);
    }

    private void updateNavAgentDestination()
    {
        agent.destination = goal.position;
    }

    private void setAnimatorVariables()
    {
        animator.SetFloat("X_Velocity", agent.velocity.x);
        animator.SetFloat("Y_Velocity", agent.velocity.y);
        animator.SetFloat("VelocityMagnitude", agent.velocity.magnitude);
    }
}
