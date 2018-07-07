using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Dictionary<Vector2Int, Waypoint> worldGrid = new Dictionary<Vector2Int, Waypoint>();

    private Queue<Waypoint> nodesQueue = new Queue<Waypoint>();
    private List<Waypoint> knownNodes = new List<Waypoint>();

    private List<Waypoint> path = new List<Waypoint>();

    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] private Waypoint startPoint, endPoint;

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (worldGrid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Detected overlapping block at " + gridPos + "... Skipping");
            }
            else
            {
                worldGrid.Add(gridPos, waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.red);
        endPoint.SetTopColor(Color.blue);
    }

    private void BreadthFirstSearch()
    {
        nodesQueue.Enqueue(startPoint);
        knownNodes.Add(startPoint);

        while (nodesQueue.Count > 0)
        {
            Waypoint searchCenter = nodesQueue.Dequeue();

            if (searchCenter == endPoint)
            {
                break;
            }

            ExploreNeighbours(searchCenter);
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        foreach (Vector2Int direction in directions)
        {
            Waypoint neighbour;
            if (worldGrid.TryGetValue(from.GetGridPos() + direction, out neighbour))
            {
                if (!knownNodes.Contains(neighbour))
                {
                    nodesQueue.Enqueue(neighbour);
                    knownNodes.Add(neighbour);
                    neighbour.exploredFrom = from;
                }
            }
        }
    }

    private void RecoverPath()
    {
        Waypoint currentNode = endPoint;
        path.Add(currentNode);
        currentNode.isPlaceable = false;
        while (currentNode != startPoint)
        {
            currentNode = currentNode.exploredFrom;
            path.Add(currentNode);
            currentNode.isPlaceable = false;
        }

        path.Reverse();
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            ColorStartAndEnd();
            BreadthFirstSearch();
            RecoverPath();
        }

        return path;
    }

}
