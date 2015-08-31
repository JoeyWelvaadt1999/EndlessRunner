using UnityEngine;
using System.Collections;

public class SpawnPath : MonoBehaviour {
	public GameObject blockPrefab;
	private int totalSpawnedBlocks;
	private Vector3 screenSize;

	// Use this for initialization
	void Start () {
		Debug.Log(Screen.width);
		screenSize = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
		SpawnBlocks();
	}

	void SpawnBlocks() {
		Instantiate(blockPrefab, new Vector3((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * -0.45f) ,0), Quaternion.identity);
		totalSpawnedBlocks++;
	}
}
