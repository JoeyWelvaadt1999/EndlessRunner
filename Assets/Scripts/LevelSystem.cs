using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSystem : MonoBehaviour {
	[SerializeField]private GameObject levelBar;
	[SerializeField]private Text levelText;
	[SerializeField]private Text experienceText;
	private float experience = 0;
	private float neededExperience;
	private float level = 1;

	public float Level{
		get{
			return level;
		}set {
			level = value;
		}
	}

	public float Experience{
		get{
			return experience;
		}set {
			experience = value;
		}
	}

	public float NeededExperience{
		get{
			return neededExperience;
		}set {
			neededExperience = value;
		}
	}
	// Use this for initialization
	void Start () {
		neededExperience = Mathf.FloorToInt(75 * (level + (level / 2)));
	}
	
	// Update is called once per frame
	void Update () {
		neededExperience = Mathf.FloorToInt(75 * (level + (level / 2)));
		var tScale = levelBar.transform.localScale;
		tScale.x =  0 + (experience / neededExperience);
		levelBar.transform.localScale = tScale;

		levelText.text = "Level - " + level;
		experienceText.text = experience + "/" + neededExperience;

		if(experience >= neededExperience) {
			experience -= neededExperience;
			level++;
		}
	}
}
