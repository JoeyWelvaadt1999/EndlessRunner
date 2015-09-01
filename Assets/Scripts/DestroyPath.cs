using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyPath : MonoBehaviour {
	public static GameObject[] blocks;
	private Vector2 screenSize;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
		blocks = GameObject.FindGameObjectsWithTag("Grass");
		for(int i = 0; i < blocks.Length; i++) {
			if(SpawnPath.totalSpawnedBlocks > 40) {
				if(blocks[i].gameObject.transform.position.x < GameObject.FindWithTag("Player").transform.position.x - 20) {
					Destroy(blocks[i].gameObject);
					SpawnPath.totalSpawnedBlocks-=1;

				}
			}
		}
	}
}
