using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]

public class AttackState : State
{
    private int _damage;
    private float _delay;
    private float _attackDistance;
    private float _rotationSpeed;
    private float _lastAttackTime;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _attackDistance = GetComponent<Enemy>().AttackDistance;
        _delay = GetComponent<Enemy>().TimeBetweenAttack;
        _damage = GetComponent<Enemy>().Damage;
        _rotationSpeed = GetComponent<Enemy>().RotationSpeed;
    }

    private void Update()
    {
        float distanse = Vector3.Distance(Target.transform.position, transform.position);
        if (distanse <= _attackDistance)
        {
            FaceTarget(Target);

            if (_lastAttackTime <= 0)
            {
                Attack(Target);
                _lastAttackTime = _delay;
            }
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.SetTrigger("Attack");
    }

    private void FaceTarget(Player target)
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }
}
