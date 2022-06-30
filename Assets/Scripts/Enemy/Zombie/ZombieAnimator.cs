using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

public class ZombieAnimator : MonoBehaviour
{
    //private NavMeshAgent _navMeshAgent;
    //private Animator _animator;
    //private string _animationSpeedState = "Speed";

    //private void Start()
    //{
    //    _navMeshAgent = GetComponent<NavMeshAgent>();
    //    _animator = GetComponent<Animator>();
    //}

    //private void Update()
    //{
    //    _animator.SetFloat(_animationSpeedState, _navMeshAgent.velocity.magnitude);
    //}
}
