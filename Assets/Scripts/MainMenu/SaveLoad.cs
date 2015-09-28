using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[Serializable]
public class SaveLoad : MonoBehaviour {
	void Start () {
		Load ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Save() {
		BinaryFormatter binary = new BinaryFormatter();
		FileStream fstream = File.Create(Application.persistentDataPath + "/Game.dat");
		SaveGame sg = new SaveGame();
		GameObject lsContainer = GameObject.FindWithTag("LevelSystem");
		LevelSystem ls = lsContainer.GetComponent<LevelSystem>();
		sg.level = ls.Level;
		sg.experience = ls.Experience;
		sg.neededExperience = ls.NeededExperience;
		
		
		binary.Serialize(fstream, sg);
		fstream.Close();

	}

	void Load() {
		if(File.Exists(Application.persistentDataPath + "/Game" + ".dat")) {
			BinaryFormatter binary = new BinaryFormatter();
			FileStream fstream = File.Open(Application.persistentDataPath + "/Game.dat", FileMode.Open);
			SaveGame sg = (SaveGame)binary.Deserialize(fstream);
			GameObject lsContainer = GameObject.FindWithTag("LevelSystem");
			LevelSystem ls = lsContainer.GetComponent<LevelSystem>();
			fstream.Close();
			ls.NeededExperience = sg.neededExperience;
			ls.Experience = sg.experience;
			ls.Level = sg.level;
			Debug.Log(ls.Level + " " + ls.NeededExperience + " " + ls.Experience);



		}
	}
}
[Serializable]
class SaveGame {
	public float level;
	public float experience;
	public float neededExperience;
}
