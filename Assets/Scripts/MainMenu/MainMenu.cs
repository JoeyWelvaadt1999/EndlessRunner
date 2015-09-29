using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	[SerializeField]private Button chooseLevel;
	[SerializeField]private Button[] levels;
	
	void Update() {
		RotateAround();
	}
	
	void RotateAround() {
		Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, 0.5f);
	}	
	
	public void ButtonOnClick(int scene) {
		if(scene == 0) {
			chooseLevel.gameObject.SetActive(false);
			for(int i = 0; i < levels.Length; i++) {
				levels[i].gameObject.SetActive(true);
				Debug.Log(levels[i].name);
			}
		} else {
			Application.LoadLevel(scene);
		}
	}
}