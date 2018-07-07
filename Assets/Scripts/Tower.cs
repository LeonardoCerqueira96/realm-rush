using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Vector3 targetOffset = Vector3.zero;

    [SerializeField] private float damageTreshhold = 2f;
    [SerializeField] private float distanceTreshhold = 40f;
    [SerializeField] private float maxTurnSpeed = 2 * Mathf.PI;

    private ParticleSystem.EmissionModule particleEmission;

    private List<Transform> enemies = new List<Transform>();

    void Start()
    {
        particleEmission = GetComponentInChildren<ParticleSystem>().emission;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyList();

        Transform bestTarget = GetClosestEnemy();
        if (bestTarget && Vector3.Distance(transform.position, bestTarget.position) < distanceTreshhold)
        {
            Quaternion targetRotation = Quaternion.LookRotation((bestTarget.position + targetOffset) -
                                        objectToPan.transform.position);

            objectToPan.transform.rotation = Quaternion.Slerp(objectToPan.rotation, targetRotation, maxTurnSpeed * Time.deltaTime);
            particleEmission.enabled = true;
        }
        else
        {
            particleEmission.enabled = false;
        }
    }

    private void UpdateEnemyList()
    {
        enemies.Clear();

        EnemyMover[] enemyTypeList = FindObjectsOfType<EnemyMover>();
        foreach (EnemyMover enemyType in enemyTypeList)
        {
            enemies.Add(enemyType.transform);
        }
    }

    private Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }


    public float GetDamageTreshhold()
    {
        return damageTreshhold;
    }
}
