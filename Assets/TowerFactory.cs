using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private int towerLimit = 5;
    [SerializeField] private Tower towerPrefab;

    private int numberOfTowers = 0;

    public void PlaceTower(Waypoint waypoint)
    {
        if (numberOfTowers < towerLimit)
        {
            Transform towersParent = GameObject.Find("Towers").transform;
            GameObject newTower = Instantiate(towerPrefab.gameObject, waypoint.transform.position, Quaternion.identity);
            newTower.transform.parent = towersParent;
            numberOfTowers++;

            waypoint.isPlaceable = false;
        }
        else
        {
            Debug.Log("You can't place anymore towers");
        }
    }
}
