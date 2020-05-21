using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShopperController : MonoBehaviour
{

    public Transform goal;
    public Rigidbody hipsRB;
    public Collider col;
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

    public void killShopper(bool upKillTally=true)
    {
        if (!isAlive) return;
        agent.enabled = false;
        animator.enabled = false;
        col.enabled = false;
        isAlive = false;
        ShopperSpawn.currentNumberOfShoppers--;
        if (upKillTally) GameManager.shoppersKilled++;
        hipsRB.AddForce(Vector3.up * 200f, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    private void updateNavAgentDestination()
    {
        if (goal != null)
        agent.destination = goal.position;
    }

    private void setAnimatorVariables()
    {
        animator.SetFloat("X_Velocity", agent.velocity.x);
        animator.SetFloat("Y_Velocity", agent.velocity.y);
        animator.SetFloat("VelocityMagnitude", agent.velocity.magnitude);
    }
}
