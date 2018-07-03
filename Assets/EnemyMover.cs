using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour 
{
    [SerializeField] private List<Block> path;


	// Use this for initialization
	void Start() 
	{
		foreach (Block block in path)
        {
            Debug.Log(block.gameObject.name);
        }
	}
	
	// Update is called once per frame
	void Update() 
	{
		
	}
}
