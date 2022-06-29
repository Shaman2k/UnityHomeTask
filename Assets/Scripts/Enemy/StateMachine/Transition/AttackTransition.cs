using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class AttackTransition : Transition
{
    private float _attackRange;

    private void Start()
    {
        _attackRange = GetComponent<Enemy>().AttackDistance;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _attackRange)
        {
            NeedTransit = true;
        }
    }
}
