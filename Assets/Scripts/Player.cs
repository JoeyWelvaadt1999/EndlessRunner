using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 spawnPos = new Vector3(0,Screen.width / 2,0);
	private float gravity = 1.2f;
	private float curGravity = 0.0f;
	private bool isGrounded = false;
	private float speed = 0.0f;

	// Use this for initialization
	void Start () {
		transform.position = spawnPos;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.GetComponent<PolygonCollider2D> ());
		this.gameObject.AddComponent<PolygonCollider2D> ();

		Vector3 tPos = transform.position;

		if (!isGrounded) {
			curGravity = gravity + curGravity;
			speed += curGravity;
			curGravity += 0.1f;
			tPos.y += speed;
			transform.position = tPos;
		} else {
			speed = 0.0f;
			gravity = 1.2f;
		}

	}
}
