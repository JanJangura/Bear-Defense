using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float enemySpawnerIntervals = 0.5f;

    public TextMeshProUGUI waveTimer;
    private float countdown = 2f;
    private int waveIndex = 0;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        waveTimer.text = Mathf.Ceil(countdown).ToString(); // This will cut off all decimal numbers and keep it a whole number

        // Time.deltaTime is the amount of time passed since the last time we drew a frame.
        // This will reduce countdown by 1 every sec.
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            // Spawn Enemy, then wait .5f seconds and repeat for however many times the waveNumber is
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnerIntervals);
        }
        waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
