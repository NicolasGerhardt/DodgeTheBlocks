using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;

    public float spawnSizeMin = 0.3f;
    public float spawnSizeMax = 3f;

    public float spawnAngleMax = 10;

    public float secondsBetweenSpawnsMin = 0.1f;
    public float secondsBetweenSpawnsMax = 1f;
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
            SpawnNewFallingBlock();
            SetTimeForNextSpawn();
        }
    }

    private bool TimetoSpawnNextBlock()
    {
        return Time.time > nextSpawnTime;
    }

    private void SpawnNewFallingBlock()
    {
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        float spawnSize = Random.Range(spawnSizeMin, spawnSizeMax);
        Vector2 spawnPosition = GenerateRandomSpawnPosition(spawnSize);
        GameObject NewBlock = (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        NewBlock.transform.localScale = Vector2.one * spawnSize;
    }

    private Vector2 GenerateRandomSpawnPosition(float spawnSize)
    {
        float x = Random.Range(-screenHalfSizeInWorldUnits.x, screenHalfSizeInWorldUnits.x);
        float y = screenHalfSizeInWorldUnits.y + spawnSize;

        return new Vector2(x, y);
    }

    private void SetTimeForNextSpawn()
    {
        float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMax, secondsBetweenSpawnsMin, Difficulty.GetDifficultyPercent());
        nextSpawnTime = Time.time + secondsBetweenSpawns;
    }
}
