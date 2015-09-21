using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Player p;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		p = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate(p.movementSpeed * Time.deltaTime, 0, 0);
		Quaternion tRot = transform.rotation;
		tRot.z = 0;

		transform.rotation = tRot;
	}
}
