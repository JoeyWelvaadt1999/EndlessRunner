﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {
	private float movementSpeed = 0.25f; 
	private bool showScreen = false;
	private string uname;
	private int score;
	private float showScreenTime = 0;
	GameObject eb;
	GameObject et;
	[SerializeField]private GameObject topEndPos;
	[SerializeField]private GameObject bottomEndPos;
	[SerializeField]private GameObject endScreen;
	[SerializeField]private GameObject sparkPrefab;
	[SerializeField]private GameObject nozzle;
	[SerializeField]private Text scoreText;


	public bool ShowScreen{
		get{
			return showScreen;
		} set {
			showScreen = value;
		}
	}
	// Use this for initialization
	private EndScreen(){

	}

	void Start () {
		et = GameObject.FindWithTag("EndTop");
		eb = GameObject.FindWithTag("EndBottom");
		endScreen.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		ScreenShow();
	}

	void ScreenShow() {
		score = PlayerPrefs.GetInt("Score");
		scoreText.text = "Score : " + score.ToString();
		Vector3 etPos = et.transform.position;
		Vector3 ebPos = eb.transform.position;
		if(showScreen) {
			showScreenTime += Time.deltaTime;
			if(etPos == topEndPos.transform.position && ebPos == bottomEndPos.transform.position) {
				endScreen.gameObject.SetActive(true);
				Instantiate(sparkPrefab, nozzle.transform.position, Quaternion.identity);
			}
			
			if(showScreenTime > 0.3f) {
				endScreen.gameObject.SetActive(true);
				Instantiate(sparkPrefab, nozzle.transform.position, Quaternion.identity);
			}
			et.transform.position = Vector3.Lerp(et.transform.position, topEndPos.transform.position, movementSpeed);
			eb.transform.position = Vector3.Lerp(eb.transform.position, bottomEndPos.transform.position, movementSpeed);
		}
	}

	[SerializeField] void Action(int action){
		switch(action) {
		case 0:
			Application.LoadLevel(0);
			break;
		case 1:
			Application.LoadLevel(1);
			break;
		case 2:
			Application.OpenURL("http://www.re-creator.com/endless/");
			break;
		}
	}
}
