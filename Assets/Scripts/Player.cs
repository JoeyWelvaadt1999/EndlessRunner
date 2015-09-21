using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	private bool isGrounded = false;
	private int movementSpeed = 7;
	private Rigidbody2D rb2d;

	[SerializeField]private GameObject bulletPrefab,nozzle;
	[SerializeField]private List<GameObject> hearts = new List<GameObject>();
	Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.gravityScale = 1;
	}

	void Update() {

		Move();
	
		DrawRaycast();
		if(Input.GetKeyDown(KeyCode.Y)) {
			Destroy(hearts[hearts.Count - 1].gameObject);
			hearts.Remove(hearts[hearts.Count - 1].gameObject);
		}
		Debug.Log(isGrounded);
	}

	[SerializeField]void Shoot(){
		Debug.LogError("hey");
		Instantiate(bulletPrefab, nozzle.transform.position, new Quaternion(bulletPrefab.transform.rotation.x, bulletPrefab.transform.rotation.y,bulletPrefab.transform.rotation.z + transform.rotation.z, bulletPrefab.transform.rotation.w));
	}

	[SerializeField]void Jump() {
		if(isGrounded) {
			rb2d.AddForce(new Vector2(0,300));
			isGrounded = false;
		}
	}

	void Move() {
		transform.Translate(new Vector2(movementSpeed * Time.deltaTime,0));
	}

	void DrawRaycast() {
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.75f), -Vector2.up);
		Quaternion tRot = transform.rotation;
		Vector3 eA = tRot.eulerAngles;
		if(hit.transform.name == "UpBlock(Clone)") {
			eA.z = 45;
			rb2d.gravityScale = 0f;
		} else if (hit.transform.name == "DownBlock(Clone)") {
			eA.z = -45;
			rb2d.gravityScale = 1f;
		} else if (hit.transform.name == "Block(Clone)") {
			eA.z = 0;
			rb2d.gravityScale = 1f;
		}
		
		tRot.eulerAngles = eA;
		transform.rotation = tRot;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.transform.tag == "Block")  {
			isGrounded = true;
		}
	}
}
