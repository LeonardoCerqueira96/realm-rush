using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour 
{
    [Range(1f, 20f)]
    [SerializeField] private float gridSize = 10f;

    private TextMesh textMesh;

    void Update()
	{
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos;

        string labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = labelText;

        gameObject.name = "Block " + labelText;
    }
}
