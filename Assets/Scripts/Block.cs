using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	Player p;
	GameObject player;

	void Start() {
		player = GameObject.FindWithTag("Player");
		p = player.GetComponent<Player> ();
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.transform.tag == "Player") {
//			p.speed = 0;
//			Debug.Log(p.speed);
		}
	}
}
