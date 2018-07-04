using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour 
{
    [SerializeField] private List<Waypoint> path;

    private Pathfinder pathfinder;

    void Awake()
    {
        pathfinder = FindObjectOfType<Pathfinder>();   
    }

    // Use this for initialization
    void Start()
    {
        path = pathfinder.GetPath();
        StartCoroutine(FollowPath());
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
    void Update() 
	{
		
	}
}
