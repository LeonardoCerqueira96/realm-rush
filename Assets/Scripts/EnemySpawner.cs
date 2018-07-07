using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float secondBetweenSpawns = 5f;
    [SerializeField] private Vector2Int spawnPoint = new Vector2Int(0, 0);

    [SerializeField] private EnemyMover enemyPrefab;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {

            Vector3 worldSpawnPos = new Vector3(spawnPoint.x, 0f, spawnPoint.y);
            GameObject newEnemy = Instantiate(enemyPrefab.gameObject, worldSpawnPos, Quaternion.identity);
            newEnemy.transform.parent = transform;

            yield return new WaitForSeconds(secondBetweenSpawns);
        }
    } 
}
