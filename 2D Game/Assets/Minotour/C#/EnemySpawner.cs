using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Prefab;

    void Start()
    {
        SpawnEnemy();
    }

    void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += SpawnEnemy;
    }

    void SpawnEnemy()
    {

        int randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        Instantiate(Prefab, SpawnPoints[randomNumber].transform.position, Quaternion.identity);
    }
      
}
