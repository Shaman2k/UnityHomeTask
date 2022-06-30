using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : EnemyPool
{
    [SerializeField] private GameObject _spawnBlock;
    [SerializeField] private GameObject _template;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private List<Transform> _spawnPoints;
    private Transform _currentSpawnPoint;
    private int _spawnPointIndex;
    private int _spawned;
    private Coroutine coroutine;


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
        _spawned = 0;

        if (coroutine == null)
            coroutine = StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {

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
            _spawned++;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (_spawned <= Capacity)
        {
            GetEnemy(GetSpawnPoint());
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
