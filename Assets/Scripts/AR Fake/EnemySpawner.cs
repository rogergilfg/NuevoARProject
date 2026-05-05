using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera arCamera;
    [SerializeField] private float spawnOffset;
    [SerializeField] private float spawnTime;
    [SerializeField] private float distance;
    [SerializeField] private GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arCamera = Camera.main;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition;
        spawnPosition = arCamera.transform.position + Quaternion.Euler(0f, Random.Range(0, 360), 0f) * arCamera.transform.forward * distance + new Vector3(Random.Range(-spawnOffset, spawnOffset), Random.Range(-spawnOffset, spawnOffset), 0f);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
