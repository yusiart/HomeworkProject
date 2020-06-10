using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _timeToSpawn;

    private float _timer;
    private int _pointNumber;
    private int _numberOfEnemy;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        {
            if (_timer >= _timeToSpawn)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    _pointNumber = Random.Range(0, _points.Length);
                    SetEnemy(enemy, _points[_pointNumber].position);
                    _timer = 0;
                }
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPosition)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPosition;
    }
}

