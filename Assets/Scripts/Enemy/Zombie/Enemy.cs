using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _damage = 20;
    [SerializeField] private int _reward = 20;
    [SerializeField] private float _attackDistance = 2f;
    [SerializeField] private float _timeBetweenAttack = 2f;
    [SerializeField] private float _lookRadius = 10f;
    [SerializeField] private float _rotationSpeed = 6f;
    [SerializeField] private float _deadBodyExistTime = 10f;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private Player _target;

    public Player Target => _target;
    public int Reward => _reward;
    public int Damage => _damage;
    public float AttackDistance => _attackDistance;
    public float TimeBetweenAttack => _timeBetweenAttack;
    public float LookRadius => _lookRadius;
    public float RotationSpeed => _rotationSpeed;

    private void Start()
    {
        _target = FindObjectOfType<Player>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
         StartCoroutine(Die());
            
    }

    private IEnumerator Die()
    {
        _animator.SetTrigger("Die");
        _navMeshAgent.enabled = false;
        yield return new WaitForSeconds(4);

        Destroy(gameObject);
    }
}
