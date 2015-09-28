using UnityEngine;
using System.Collections;

public class SpawnUnits : MonoBehaviour {
	[SerializeField]private GameObject lavaPref;
	[SerializeField]private GameObject blockPref;
	[SerializeField]private GameObject starPref;
	[SerializeField]private GameObject[] coins;
	private int prevObject = 0;
	private int totalSpawnedBlocks = 0;
	private bool startSpawning = true;
	private Vector2 screenSize = new Vector2(1.0f,1.0f);
	private GameObject player;

	// Use this for initialization
	void Start () {
		screenSize = Camera.main.ViewportToWorldPoint(new Vector2(1.0f,1.0f));
		for(int x = 0; x < 20; x++) {
			for(int y = 0; y < 4; y++) {
				GameObject block = Instantiate(blockPref, new Vector3((screenSize.x * -1) + (0.8f * totalSpawnedBlocks), -2.4f + (-0.8f * y), 0), Quaternion.identity) as GameObject;
				block.transform.parent = transform;
			}
			totalSpawnedBlocks++;
		}
	}
	

	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("Player");
		DestroyPath();
		if(player != null) {
			if(0.8f * totalSpawnedBlocks < player.transform.position.x + screenSize.x * 2.5f) {
				SpawnPath();
				SpawnStars();
			}
		}

		SpawnCoins();
	}


	void SpawnPath() {
		int rand = Random.Range(0,2);

		switch(rand) {
		case 0:
			if(rand != prevObject) {
				for(int x = 0; x < 4; x++) {
					for(int y = 0; y < 4; y++) {
//						GameObject lava = Instantiate(lavaPref, new Vector3((screenSize.x * -1) + (0.8f * totalSpawnedBlocks), -2.6f + (-0.8f * y), 0), Quaternion.identity) as GameObject;
//						lava.transform.parent = transform;
					}
					totalSpawnedBlocks++;

				}

				prevObject = 0;

			}
			break;
		case 1:
			for(int x = 0; x < 5; x++) {
				for(int y = 0; y < 4; y++) {
					GameObject block = Instantiate(blockPref, new Vector3((screenSize.x * -1) + (0.8f * totalSpawnedBlocks) , -2.4f + (-0.8f * y), 0), Quaternion.identity) as GameObject;
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
		if(GameObject.FindWithTag("Player") != null) {
			for(int i = 0; i < objects.Length; i++) {
				if(objects[i].transform.position.x < GameObject.FindWithTag("Player").transform.position.x - 15) {
	//				totalSpawnedBlocks--;
					Destroy(objects[i].gameObject);
				}
			}
		}
	}

	void SpawnStars() {
		int rand = Random.Range(0,21);
		if(rand == 0) {
			if(player != null) {
				GameObject star = Instantiate(starPref, new Vector3(((screenSize.x * -1) + (0.64f * totalSpawnedBlocks)) + GameObject.FindWithTag("Player").transform.position.x , -1.4f, 0), Quaternion.identity) as GameObject;
				star.transform.parent = transform;
			}
		}
	}

	void SpawnCoins(){
		int rand = Random.Range(0,121);
		if(rand == 0) {
			if(player != null) {
				if(player.transform.position.y <= 1.55f) {
					Instantiate(coins[Random.Range(0, coins.Length )].gameObject, new Vector3(player.transform.position.x + Random.Range(10,20), 3, 0), Quaternion.identity);
				}
			}
		}
	}
}
