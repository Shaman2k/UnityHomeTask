using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PatrolState : State
{
    [SerializeField] private GameObject _patrolRoute;

    private NavMeshAgent _agent;
    private Transform[] _points;
    private int _currentPoint;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _points = new Transform[_patrolRoute.transform.childCount];

        for (int i = 0; i < _patrolRoute.transform.childCount; i++)
        {
            _points[i] = _patrolRoute.transform.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        float distanse = Vector3.Distance(target.position, transform.position);
        _agent.SetDestination(target.position);

        if (distanse <= _agent.stoppingDistance)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
