using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float secondBetweenSpawns = 5f;
    [SerializeField] private Vector2Int spawnPoint = new Vector2Int(0, 0);

    [SerializeField] private EnemyMover enemyPrefab;
    [SerializeField] private Text enemyText;

    [SerializeField] private AudioClip enemySpawnClip;

    private int totalEnemiesSpawned = 0;

    // Use this for initialization
    void Start()
    {
        UpdateText();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            InstantiateEnemy();
            PlayClip();
            UpdateScore();

            yield return new WaitForSeconds(secondBetweenSpawns);
        }
    }

    private void PlayClip()
    {
        AudioSource.PlayClipAtPoint(enemySpawnClip, Camera.main.transform.position, 1f);
    }

    private void InstantiateEnemy()
    {
        Vector3 worldSpawnPos = new Vector3(spawnPoint.x, 0f, spawnPoint.y);
        GameObject newEnemy = Instantiate(enemyPrefab.gameObject, worldSpawnPos, Quaternion.identity);
        newEnemy.transform.parent = transform;
    }

    private void UpdateScore()
    {
        totalEnemiesSpawned++;
        UpdateText();
    }

    private void UpdateText()
    {
        enemyText.text = totalEnemiesSpawned.ToString();
    }
}
