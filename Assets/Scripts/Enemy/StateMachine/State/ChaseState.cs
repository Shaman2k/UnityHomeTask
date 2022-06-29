using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]

public class ChaseState : State
{
    private float _lookRadius;
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _lookRadius = GetComponent<Enemy>().LookRadius;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanse = Vector3.Distance(Target.transform.position, transform.position);

  //      if (distanse <= _lookRadius)
            _agent.SetDestination(Target.transform.position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
}
