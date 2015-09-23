using UnityEngine;
using System.Collections;

public class SpawnUnits : MonoBehaviour {
	[SerializeField]private GameObject lavaPref;
	[SerializeField]private GameObject blockPref;
	[SerializeField]private GameObject starPref;
	private int prevObject = 0;
	private int totalSpawnedBlocks = 0;
	private Vector2 screenSize = new Vector2(1.0f,1.0f);

	// Use this for initialization
	void Start () {
		screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1.0f,1.0f));
		for(int x = 0; x < 8; x++) {
			for(int y = 0; y < 4; y++) {
				GameObject block = Instantiate(blockPref, new Vector3((screenSize.x * -1) + (0.8f * totalSpawnedBlocks), -2.4f + (-0.8f * y), 0), Quaternion.identity) as GameObject;
				block.transform.parent = transform;
			}
			totalSpawnedBlocks++;
		}

	}
	

	// Update is called once per frame
	void Update () {
//		DestroyPath();
		SpawnPath();
		SpawnStars();
	}

	void SpawnPath() {
		int rand = Random.Range(0,2);

		switch(rand) {
		case 0:
			if(rand != prevObject) {
				for(int x = 0; x < 3; x++) {
					for(int y = 0; y < 4; y++) {
						GameObject lava = Instantiate(lavaPref, new Vector3((screenSize.x * -1) + (0.8f * totalSpawnedBlocks), -2.6f + (-0.8f * y), 0), Quaternion.identity) as GameObject;
						lava.transform.parent = transform;
					}
					totalSpawnedBlocks++;
				}

				prevObject = 0;

			}
			break;
		case 1:
			for(int x = 0; x < 3; x++) {
				for(int y = 0; y < 4; y++) {
					GameObject block = Instantiate(blockPref, new Vector3((screenSize.x * -1) + (0.8f * totalSpawnedBlocks), -2.4f + (-0.8f * y), 0), Quaternion.identity) as GameObject;
					block.transform.parent = transform;
				}
				totalSpawnedBlocks++;
			}
			prevObject = 1;
	
			break;
		}
	}

	void DestroyPath() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Objects");
		for(int i = 0; i < objects.Length; i++) {
			if(objects[i].transform.position.x < GameObject.FindWithTag("Player").transform.position.x - screenSize.x - 0.8f) {
				totalSpawnedBlocks--;
				Destroy(objects[i].gameObject);
				Debug.Log(totalSpawnedBlocks);
			}
		}
	}

	void SpawnStars() {
		int rand = Random.Range(0,101);
		if(rand == 0) {
			GameObject star = Instantiate(starPref, new Vector3((screenSize.x * -1) + (0.64f * totalSpawnedBlocks), -1.4f, 0), Quaternion.identity) as GameObject;
			star.transform.parent = transform;
		}
	}
}
