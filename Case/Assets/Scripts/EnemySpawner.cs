using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyType = 0;
    public GameObject enemyPrefab1, enemyPrefab2;
    public List<GameObject> spawns;
    public float spawnDelay = 5f;
    public float spawnDistance = 10f;
    private Camera mainCamera;
    private float spawnTimer = 0f;

    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnRate", 10f, 15f);
    }

    private void Update()
    {
        SpawnTimer();
    }
    private void SpawnRate()
    {
        if (spawnDelay > 2)
        {
            spawnDelay -= 1;
        }        
    }
    private void SpawnTimer()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            SpawnEnemy();
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }
    private void SpawnEnemy()
    {
        enemyType = Random.Range(1, 3);
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        Vector3 spawnPosition = new Vector3();

        int spawnSide = Random.Range(0, 4);
        if (spawnSide == 0)
        {
            spawnPosition.x = mainCamera.transform.position.x + cameraWidth / 2f + spawnDistance;
            spawnPosition.y = mainCamera.transform.position.y + Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
        }
        else if (spawnSide == 1)
        {
            spawnPosition.x = mainCamera.transform.position.x - cameraWidth / 2f - spawnDistance;
            spawnPosition.y = mainCamera.transform.position.y + Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
        }
        else if (spawnSide == 2)
        {
            spawnPosition.x = mainCamera.transform.position.x + Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            spawnPosition.y = mainCamera.transform.position.y + cameraHeight / 2f + spawnDistance;
        }
        else if (spawnSide == 3)
        {
            spawnPosition.x = mainCamera.transform.position.x + Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            spawnPosition.y = mainCamera.transform.position.y - cameraHeight / 2f - spawnDistance;
        }
        if (enemyType == 1)
        {
            var newEnemy = ObjectPool.instance.Instantiate(enemyPrefab1);
            newEnemy.transform.position = spawnPosition;
            spawns.Add(newEnemy);
        }
        if (enemyType == 2)
        {
            var newEnemy = ObjectPool.instance.Instantiate(enemyPrefab2);
            newEnemy.transform.position = spawnPosition;
            spawns.Add(newEnemy);
        }
    }
}
