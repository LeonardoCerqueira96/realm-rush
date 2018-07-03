using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour 
{
    [Range(1f, 20f)]
    [SerializeField] private float gridSize = 10f;

    TextMesh labelText;

    void Start()
    {
        labelText = GetComponentInChildren<TextMesh>();    
    }

    void Update() 
	{
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = snapPos;

        labelText.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}
