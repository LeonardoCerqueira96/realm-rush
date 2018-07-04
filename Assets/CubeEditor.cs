using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour 
{

    private Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();    
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2Int snapPos = waypoint.GetGridPos() * gridSize;

        transform.position = new Vector3
        (
            snapPos.x,
            0f,
            snapPos.y
        );
    }

    private void UpdateLabel()
    {
        Vector2Int gridPos = waypoint.GetGridPos();
        string labelText = gridPos.x + "," + gridPos.y;

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = labelText;

        gameObject.name = "Waypoint " + labelText;
    }
}
