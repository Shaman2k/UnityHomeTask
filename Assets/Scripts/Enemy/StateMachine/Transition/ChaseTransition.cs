using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]

public class ChaseTransition : Transition
{
    private float _transitionRange;
    private float _stopDistance;

    private void Start()
    {
        _transitionRange = GetComponent<Enemy>().LookRadius;
        _stopDistance = GetComponent<NavMeshAgent>().stoppingDistance;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _transitionRange && Vector3.Distance(transform.position, Target.transform.position) > _stopDistance)
        {
            NeedTransit = true;
        }
    }
}