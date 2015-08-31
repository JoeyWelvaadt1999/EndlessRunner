using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 spawnPos = new Vector3(0,Screen.width / 2,0);
	private float gravity = 1.2;
	private float curGravity = 0.0;
	private bool isGrounded = false;
	private double speed = 0;

	// Use this for initialization
	void Start () {
		transform.position = spawnPos;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.GetComponent<PolygonCollider2D> ());
		this.gameObject.AddComponent<PolygonCollider2D> ();

		if (!isGrounded) {
			speed += gravity;
			gravity += 0.1;
			transform.position.y += speed;
		} else {
			speed = 0;
			gravity = 1.2;
		}

	}
}
