using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class ChaseState : State
{
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanse = Vector3.Distance(Target.transform.position, transform.position);
        _agent.SetDestination(Target.transform.position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
}
