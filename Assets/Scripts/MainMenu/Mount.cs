using UnityEngine;
using System.Collections;

public class Mount : MonoBehaviour {
	[SerializeField]private Transform currentMount;
	private float speed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, currentMount.position, speed);
		transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speed);
	}

	[SerializeField]void SetMount(Transform newMount) {
		currentMount = newMount;
	}
}
