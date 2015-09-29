using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.transform.tag == "GrapplingHook") {
			Destroy(this.gameObject);
			GameObject.FindWithTag("Player").GetComponent<Player>().Coins++;
			Debug.Log(GameObject.FindWithTag("Player").GetComponent<Player>().Coins);
		}
	}
}
