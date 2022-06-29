using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

public class ZombieAnimator : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);
    }
}
