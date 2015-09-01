using UnityEngine;
using System.Collections;

public class SpawnPath : MonoBehaviour {
	public GameObject blockPrefab;
	public static int totalSpawnedBlocks;
	private Vector2 screenSize;
	private int firstRandom = 0;
	private int secondRandom = 0;
	private bool trigger = false;

	// Use this for initialization
	void Start () {

		screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		SpawnBlocks();
	}

	void SpawnBlocks() {

		if (trigger) {

			int curRandom = Random.Range(4,10);
			float curSecondRandom = Random.Range(0.2f,0.45f);

			for(int i = 0; i < curRandom; i++)
			{
				Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * -curSecondRandom)), Quaternion.identity);
				totalSpawnedBlocks++;
			}

			trigger = !trigger;

		} else {

			int curRandom = Random.Range(4,10);
			float curSecondRandom = Random.Range(0.2f,0.45f);
			
			for(int i = 0; i < curRandom; i++)
			{
				Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * curSecondRandom)), new Quaternion(0,0,180, 0));
				totalSpawnedBlocks++;
			}

			trigger = !trigger;

		}

	}
}