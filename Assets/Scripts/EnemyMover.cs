using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour 
{
    [SerializeField] private float moveSpeed = 10f;

    private Pathfinder pathfinder;

    private Transform pointA, pointB;
    private Vector3 movementVector;
    private float distanceToMove;

    private int pathProgress = 0;

    private List<Waypoint> path;

    void Awake()
    {
        pathfinder = FindObjectOfType<Pathfinder>();   
    }

    // Use this for initialization
    void Start()
    {
        path = pathfinder.GetPath();

        SetWaypoints();
    }

    private void SetWaypoints()
    {
        if (pathProgress == path.Count - 1)
        {
            return;
        }

        pointA = path[pathProgress].transform;
        pointB = path[++pathProgress].transform;

        movementVector = (pointB.position - pointA.position).normalized;
        distanceToMove = Vector3.Distance(pointA.position, pointB.position);
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate() 
	{
        HandleMovement();
	}

    private void HandleMovement()
    {
        if (distanceToMove <= 0)
        {
            SetWaypoints();
        }

        MoveEnemy();
    }

    private void MoveEnemy()
    {
        float distanceThisFrame = moveSpeed * Time.deltaTime;
        distanceThisFrame = Mathf.Clamp(distanceThisFrame, 0f, distanceToMove);

        transform.Translate(movementVector * distanceThisFrame);
        distanceToMove -= distanceThisFrame;
    }
}
