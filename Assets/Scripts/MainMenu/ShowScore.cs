using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour {
	[SerializeField]private Text scoreText;
	private int score;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("Score");
		scoreText.text = "Score : " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToHighscores() {
		Application.OpenURL("http://re-creator.com/endless/");
	}
}
