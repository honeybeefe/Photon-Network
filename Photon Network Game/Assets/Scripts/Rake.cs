using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public enum State
{
    WALK,
    ATTACK,
    DIE
}

public class Rake : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] Animator animator;
    [SerializeField] GameObject destination;
    [SerializeField] NavMeshAgent navMeshAgent;    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        state = State.WALK;
        destination = GameObject.Find("Projector Star");
    }

    void Update()
    {
        switch(state)
        {
            case State.WALK:Walk();
                    break;

            case State.ATTACK:Attack();
                    break;

            case State.DIE: Die();
                    break;
        }
    }

    public void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);        
    }

    public void Attack()
    {
        animator.Play("Attack");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projector Star"))
        {
            state = State.ATTACK;
        }
    }
}