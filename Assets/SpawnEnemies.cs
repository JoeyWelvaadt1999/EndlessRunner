using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
	[SerializeField]private GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindWithTag("Player");
		if(Input.GetKeyDown(KeyCode.U)) {
			Instantiate(enemyPrefab, new Vector3(player.transform.position.x + Random.Range(10,15), player.transform.position.y + 5, 0), enemyPrefab.transform.rotation);	
		}
	}
}