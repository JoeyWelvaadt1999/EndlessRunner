using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyPath : MonoBehaviour {
	public static Queue<GameObject> blocks = new Queue<GameObject>(); 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		blocks = GameObject.FindGameObjectsWithTag("Grass");
		if(SpawnPath.totalSpawnedBlocks > 40) {
			Destroy(blocks.Dequeue().gameObject);
			SpawnPath.totalSpawnedBlocks--;
		}		

	}
}
