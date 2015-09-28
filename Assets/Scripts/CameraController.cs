using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	[SerializeField]private GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null) {
			if(target.transform.position.x > transform.position.x) {
				transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,0,-10), new Vector3(target.transform.position.x,0,-10), 1f);
			}
		}

	}
}
