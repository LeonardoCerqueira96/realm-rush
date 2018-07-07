using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;

    private Queue<Tower> towerRingBuffer = new Queue<Tower>();

    public void PlaceTower(Waypoint waypoint)
    {
        if (towerRingBuffer.Count < towerLimit)
        {
            CreateTower(waypoint);
        }
        else
        {
            MoveExistingTower(waypoint);
        }

        waypoint.isPlaceable = false;
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        Tower movingTower = towerRingBuffer.Dequeue();

        movingTower.basePlace.isPlaceable = true;

        movingTower.transform.position = waypoint.transform.position;
        movingTower.basePlace = waypoint;

        towerRingBuffer.Enqueue(movingTower);
    }

    private void CreateTower(Waypoint waypoint)
    {
        Transform towersParent = GameObject.Find("Towers").transform;
        Tower newTower = Instantiate(towerPrefab.gameObject, waypoint.transform.position, 
                            Quaternion.identity).GetComponent<Tower>();

        newTower.transform.parent = towersParent;
        newTower.basePlace = waypoint;

        towerRingBuffer.Enqueue(newTower);
    }
}
