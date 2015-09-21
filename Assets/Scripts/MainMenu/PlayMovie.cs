using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {
	MovieTexture mtex;
	bool playing = true;
	// Use this for initialization
	void Start () {
		
		mtex = GetComponent<Renderer>().material.mainTexture as MovieTexture;
//		#if (!UNITY_EDITOR)
			mtex.Play();
//		#endif
	}
	
	// Update is called once per frame
	void Update () {
		if(mtex.isPlaying)
		{

		} else {
			AutoFade.LoadLevel(1,0,1,Color.black);
		}
	}
}
