using UnityEngine;
using System.Collections;

public class SpawnPath : MonoBehaviour {
	public GameObject blockPrefab;
	public static int totalSpawnedBlocks;
	private Vector2 screenSize;

	// Use this for initialization
	void Start () {

		screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		SpawnBlocks();
	}

	void SpawnBlocks() {
		Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * -0.45f)), Quaternion.identity);
		Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * 0.45f)), new Quaternion(0,0,180, 0));
		totalSpawnedBlocks++;
	}
}
