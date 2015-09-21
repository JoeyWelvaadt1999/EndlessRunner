using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPath : MonoBehaviour {
	[SerializeField]private GameObject blockPrefab,upBlockPrefab,downBlockPrefab,spikePrefab;
	public static int totalSpawnedBlocks = 0;
	private Vector2 screenSize;
	private int curHeight = 0;

	// Use this for initialization
	void Start () {
		screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		SpawnBlocks();
//		Debug.Log(totalSpawnedBlocks);
	}

	void SpawnBlocks() {
//		if(totalSpawnedBlocks < 100) {
			if(totalSpawnedBlocks > 40) {

				int ran = Random.Range(0,3);
				switch(ran)
				{
					case(0):
					for(int i = 0; i < 5; i++) {
						curHeight++;
						Instantiate(upBlockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * (-0.45f + (0.1f * curHeight)))), Quaternion.identity);
						totalSpawnedBlocks++;
					}

					for(int i = 0; i < 5; i++) {
						Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * (-0.45f + (0.1f * curHeight)))), Quaternion.identity);
						totalSpawnedBlocks++;
					}

					break;
					case(1):

					for(int i = 0; i < 10; i++) {
						Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * (-0.45f + (0.1f * curHeight)))), Quaternion.identity);
						totalSpawnedBlocks++;
					}
					break;
					case(2):

					for(int i = 0; i < 5; i++) {

						Instantiate(downBlockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * (-0.45f + (0.1f * curHeight)))), Quaternion.identity);
						curHeight--;
						totalSpawnedBlocks++;
					}

					for(int i = 0; i < 5; i++) {
						Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * (-0.45f + (0.1f * curHeight)))), Quaternion.identity);
						totalSpawnedBlocks++;
					}

					break;
				}

			} else {
				Instantiate(blockPrefab, new Vector2((screenSize.x * -1) + (1*totalSpawnedBlocks),(screenSize.x * -0.45f)), Quaternion.identity);
				totalSpawnedBlocks++;

//			}

		}
	}
}