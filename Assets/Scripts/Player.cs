using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 spawnPos = new Vector3(0,4,0);
	private float speed = 0.0f;
	private bool spaceIsClicked = false;
	private bool isGrounded = false;

	// Use this for initialization
	void Start () {
		transform.position = spawnPos;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(spaceIsClicked);
		Destroy (this.GetComponent<PolygonCollider2D> ());
		this.gameObject.AddComponent<PolygonCollider2D> ();

		Vector3 tPos = transform.position;
		if(spaceIsClicked) {
			speed -= 0.6f * Time.deltaTime;
			tPos.y -= speed;
		} else if(!spaceIsClicked) {
			speed -= 0.6f * Time.deltaTime;
			tPos.y += speed;
		}
		transform.position = tPos;

		MoveAndRotatePlayer();
	}

	void MoveAndRotatePlayer() {
		transform.Translate(8 * Time.deltaTime, 0, 0);
		Quaternion tRot = transform.rotation;
		if(spaceIsClicked) {
			tRot.x = 180;
		}else {
			tRot.x = 0;
		}

		transform.rotation = tRot;
	}

	void FixedUpdate() {
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			spaceIsClicked = !spaceIsClicked; 
			GetComponent<Rigidbody2D>().velocity = new Vector3(0,6,0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.transform.tag == "Grass") {
			isGrounded = true;
			speed = 0;
		} else {
			isGrounded = false;
		}
	}
}
