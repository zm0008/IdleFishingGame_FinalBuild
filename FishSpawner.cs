using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;

    public float spawnInterval = 3f;

    // spawn area boundaries
    public float minX = -8f;
    public float maxX = 8f;

    public float minY = -4f;
    public float maxY = 4f;

    private float spawnTimer;


    // size and colour
    public Vector2 minSize = new Vector2(0.7f, 0.7f);
    public Vector2 maxSize = new Vector2(1.3f, 1.3f);
    public Color[] fishColours;



    private void Start()
    {
        spawnTimer = spawnInterval;

        Debug.Log("Fish Spawner Started");
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnFish();

            spawnTimer = spawnInterval;
        }
    }

    private void SpawnFish()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 spawnPosition = new Vector2(randomX, randomY);

        GameObject fish = Instantiate(
            fishPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // random size
        float randomSizeX = Random.Range(minSize.x, maxSize.x);
        float randomSizeY = randomSizeX / 3.5f;
        fish.transform.localScale = new Vector3(randomSizeX, randomSizeY, 1f);

        // random colours
        SpriteRenderer spriteRenderer = fish.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && fishColours != null && fishColours.Length > 0)
        {
            spriteRenderer.color = fishColours[
                Random.Range(0, fishColours.Length)
            ];
        }
    }
}