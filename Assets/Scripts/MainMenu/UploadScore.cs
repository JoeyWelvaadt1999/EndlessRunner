using UnityEngine;
using System.Collections;

public class UploadScore : MonoBehaviour {
	private int score;
	private string uname;

	// Use this for initialization
	void Start()
	{
		score = PlayerPrefs.GetInt("Score");
		uname = PlayerPrefs.GetString("Username");
		string url = "http://re-creator.com/endless/highscore.php";
		
		WWWForm form = new WWWForm();
		
		form.AddField("RandomValue", "RandomValue");
		form.AddField("username", uname);
		form.AddField("score", score);
		
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		
		yield return www;
		
		if (www.error != null)
		{
			Debug.Log("Failed : " + www.error);
		}
		else
		{
			Debug.Log("The score script was successfully executed and returned : " + www.text);
		}
	}
}
