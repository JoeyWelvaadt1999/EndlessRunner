using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	[SerializeField]private Text usernameTextField;
	[SerializeField]private Text usernamePlaceholderTextField;
	bool nee = false;
	private string uname;
	public void ChangeScene(int scene) {
		if(usernameTextField.text != "" && scene == 1) {
			uname = usernameTextField.text;
			PlayerPrefs.SetString("Username", uname);
			Application.LoadLevel(scene);
		} else {
			usernamePlaceholderTextField.text = "Please enter username:";
		}
	}

	public void ToMain(int scene) {
		Application.LoadLevel(scene);
	}

	public void DestroyPlaceHolder() {
		usernamePlaceholderTextField.enabled = nee;
	}
}
