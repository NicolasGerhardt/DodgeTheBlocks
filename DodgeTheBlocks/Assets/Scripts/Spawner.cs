using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;

    public float secondsBetweenSpawns = 1;
    float nextSpawnTime;

    Vector2 screenHalfSizeInWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        float width = Camera.main.aspect * Camera.main.orthographicSize;
        float height = Camera.main.orthographicSize;
        screenHalfSizeInWorldUnits = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimetoSpawnNextBlock())
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            SpawnNewFallingBlock();
        }
    }

    private bool TimetoSpawnNextBlock()
    {
        return Time.time > nextSpawnTime;
    }

    private void SpawnNewFallingBlock()
    {
        Vector2 spawnPosition = GenerateRandomSpawnPosition();
        Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 GenerateRandomSpawnPosition()
    {
        float x = UnityEngine.Random.Range(-screenHalfSizeInWorldUnits.x, screenHalfSizeInWorldUnits.x);
        float y = screenHalfSizeInWorldUnits.y;

        return new Vector2(x, y);
    }
}
