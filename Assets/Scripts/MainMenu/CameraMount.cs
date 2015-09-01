using UnityEngine;
using System.Collections;

public class CameraMount : MonoBehaviour {
	public Transform currentMount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, currentMount.position, 0.05f);
		transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, 0.05f);
	}

	public void SetMount(Transform newMount) {
		currentMount = newMount;
	}

	public void SwitchScene(int scene) {
		Application.LoadLevel(scene);
	}
}
