using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(8 * Time.deltaTime, 0, 0);
	}
}
