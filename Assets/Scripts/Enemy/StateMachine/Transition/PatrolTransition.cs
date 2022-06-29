using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class PatrolTransition : Transition
{
    private float _transitionRange;

    private void Start()
    {
        _transitionRange = GetComponent<Enemy>().LookRadius;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) > _transitionRange)
        {
            NeedTransit = true;
        }
    }
}