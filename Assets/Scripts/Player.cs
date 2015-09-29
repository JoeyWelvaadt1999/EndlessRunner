using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	bool isGrounded = false;
	bool getPoints = false;
	bool canShoot = true;
	AudioSource asrc;
	Rigidbody2D rb2d;
	Vector3 mousePos;
	Vector3 spawnPos;
	EndScreen eso;
	private int multiplier = 1;
	private int score = 0;
	private int coins = 0;
	private float jumpStrength = 4f;
	private float movementSpeed = 6;
	private bool useGrapplingHook = false;
	float coolDown = 0;
	float waitTime = 0;
	[SerializeField]private Text multiplierText;
	[SerializeField]private Text scoreText;
	[SerializeField]private Text coinText;
	[SerializeField]private AudioClip getStarSound;
	[SerializeField]private LevelSystem ls;
	[SerializeField]private GameObject grapplingHookPref;
	[SerializeField]private GameObject endPos;
	[SerializeField]private Material cableMaterial;
	[SerializeField]private GameObject nozzle;
	public int Coins{
		get{
			return coins;
		} set {
			coins = value;
		}
	}

	// Use this for initialization
	void Start () {
		eso = GameObject.FindObjectOfType<EndScreen>();
		asrc = GetComponent<AudioSource>();
		rb2d = GetComponent<Rigidbody2D>();
		scoreText.text = score.ToString();
		multiplierText.text = multiplier.ToString() + "X";
		coinText.text = coins.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		Jump();
		coinText.text = coins.ToString();
		transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));

		DrawRaycast();
		GrapplingHook();
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void DrawRaycast() {
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1f), -Vector2.up);
		if(hit.transform.name == "Lava(Clone)") {
			if(getPoints) {
				score += 1 * multiplier;
				getPoints = false;
				scoreText.text = score.ToString();
				isGrounded = false;
			}
		}
	}

	void Jump() {
		if(Input.GetMouseButtonDown(0) && isGrounded && mousePos.x < transform.position.x) {
			rb2d.velocity = new Vector2(0,jumpStrength);
			isGrounded = false;	
		}
	}

	void GrapplingHook() {
		if(Input.GetMouseButtonDown(0) && canShoot && mousePos.x > transform.position.x) {
			useGrapplingHook = true;
		}

		if(useGrapplingHook) {
			canShoot = false;
			GetLineRenderer();
			grapplingHookPref.transform.position = Vector3.Slerp(grapplingHookPref.transform.position, endPos.transform.position, 0.2f);
			waitTime += Time.deltaTime;
			if(waitTime >= 0.3f) {
				useGrapplingHook = false;
				waitTime = 0;
			}
		} 

		if(!useGrapplingHook) {
			GetLineRenderer();
			grapplingHookPref.transform.position = Vector3.Slerp(grapplingHookPref.transform.position,nozzle.transform.position,0.2f);

			coolDown += Time.deltaTime;
			if(coolDown >= 2f) {
				canShoot = true;
			}

			if(grapplingHookPref.transform.position == nozzle.transform.position) {
				Destroy(grapplingHookPref.GetComponent<LineRenderer>());

			}
		}
	}

	void GetLineRenderer() {
		LineRenderer lr = grapplingHookPref.GetComponent<LineRenderer>();
		if(lr == null) {
			lr = grapplingHookPref.AddComponent<LineRenderer>();
		} else {
			lr.material = cableMaterial;
			lr.SetPosition(0, nozzle.transform.position);
			lr.SetPosition(1, grapplingHookPref.transform.position);
			lr.SetWidth(0.1f, 0.1f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.transform.name == "Block(Clone)") {
			isGrounded = true;
//			anim.Play("Running");
			getPoints = true;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.name == "Lava(Clone)") {
			movementSpeed = 0;
			Destroy(this.gameObject);
			eso.ShowScreen = true;
			PlayerPrefs.SetInt("Score", score);
			ls.Experience = Mathf.FloorToInt(ls.Experience + score);
			SaveLoad sl = GameObject.FindObjectOfType<SaveLoad>();
			sl.Save();
		} 

		if(coll.transform.name == "Star(Clone)") {
			multiplier++;
			Destroy(coll.gameObject);
			movementSpeed += 0.5f;
			asrc.PlayOneShot(getStarSound);
			multiplierText.text = multiplier.ToString() + "X";
		}
	}
}
