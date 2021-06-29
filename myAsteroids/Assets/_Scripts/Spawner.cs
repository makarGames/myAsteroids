using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Asteroid _asteroidPrefub;
    [SerializeField] private Enemy _enemyPrefub;

    [SerializeField, Range(0f, 2f)] private float spawnDelay = 1f;
    private float spawnDistance = 15f;
    private float trajectoryVariance = 15f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            SpawnAsteroid(spawnPoint, spawnDirection, rotation);
            yield return new WaitForSeconds(spawnDelay);
        }

        SpawnEnemy(Random.insideUnitCircle.normalized * spawnDistance);
        StartCoroutine(Spawn());
    }

    private void SpawnAsteroid(Vector3 position, Vector3 direction, Quaternion rotation)
    {
        Asteroid asteroid = Instantiate(_asteroidPrefub, position, rotation);
        asteroid.transform.localScale = new Vector3(Random.Range(0.75f, 1.1f), Random.Range(0.75f, 1.1f), 1);
        asteroid.SetTrajectory(rotation * -direction);
    }

    private void SpawnEnemy(Vector3 position)
    {
        Enemy enemy = Instantiate(_enemyPrefub, position, Quaternion.identity);
    }
}
