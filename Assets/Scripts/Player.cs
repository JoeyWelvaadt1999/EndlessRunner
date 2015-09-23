using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	bool jump = false;
	bool isGrounded = false;
	bool getPoints = false;
	AudioSource asrc;
	Animator anim;
	Rigidbody2D rb2d;
	Vector3 spawnPos;
	private int multiplier = 1;
	private int score = 0;
	private float jumpStrength = 3f;
	private float movementSpeed = 5;
	[SerializeField]private Text multiplierText;
	[SerializeField]private Text scoreText;
	[SerializeField]private AudioClip getStarSound;


	// Use this for initialization
	void Start () {
		asrc = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		scoreText.text = score.ToString();
		multiplierText.text = multiplier.ToString() + "X";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && isGrounded) {
			jump = true;
			rb2d.velocity = new Vector2(0,jumpStrength);
			isGrounded = false;
		}

		if(jump) {
			anim.Play("Jumping");
		}

		transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));

		DrawRaycast();
	}

	void DrawRaycast() {
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.585f), -Vector2.up);
		if(hit.transform.name == "Lava(Clone)") {
			if(getPoints) {
				score += 1 * multiplier;
				getPoints = false;
				scoreText.text = score.ToString();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.transform.name == "Block(Clone)") {
			jump = false;
			isGrounded = true;
			anim.Play("Running");
			getPoints = true;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.name == "Lava(Clone)") {
			movementSpeed = 0;
			Destroy(this.gameObject);
			Application.LoadLevel(2);
			PlayerPrefs.SetInt("Score", score);
		} 

		if(coll.transform.name == "Star(Clone)") {
			multiplier++;
			Destroy(coll.gameObject);
			movementSpeed += 0.5f;
			jumpStrength -= 0.2f;
			asrc.PlayOneShot(getStarSound);
			multiplierText.text = multiplier.ToString() + "X";
		}
	}
}
