using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : EnemyPool
{
    [SerializeField] private GameObject _spawnBlock;
    [SerializeField] private GameObject _template;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private List<Transform> _spawnPoints;
    private Transform _currentSpawnPoint;
    private int _spawnPointIndex;
    private float _elapsedTime = 0;

    private void Awake()
    {
        _spawnPoints = new List<Transform>();

        foreach (Transform spawnPoint in _spawnBlock.GetComponentInChildren<Transform>())
        {
            _spawnPoints.Add(spawnPoint);
        }
    }

    private void Start()
    {
        Initialze(_template);
    }

    private void OnEnable()
    {
        _spawnPointIndex = 0;
    }

    private void Update()
    {
        if (_elapsedTime >= _timeBetweenSpawn)
        {
            _elapsedTime = 0;
            GetEnemy(GetSpawnPoint());
        }
        _elapsedTime += Time.deltaTime;
    }

    private Transform GetSpawnPoint()
    {
        _currentSpawnPoint = _spawnPoints[_spawnPointIndex];
        _spawnPointIndex++;

        if (_spawnPointIndex >= _spawnPoints.Count)
            _spawnPointIndex = 0;

        return _currentSpawnPoint;
    }

    private void GetEnemy(Transform spawnPoint)
    {
        if (TryGetObject(out GameObject enemy))
        {
            enemy.SetActive(true);
            enemy.GetComponent<NavMeshAgent>().Warp(spawnPoint.position);
        }
    }
}
