using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryGameOver : MonoBehaviour {

	public Text winText, watchText;
	AudioSource[] sounds = new AudioSource[2];

	string historyAddition;

	// Use this for initialization
	void Start () {

		historyAddition = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")+"                             "+MemoryMain.score;
		SavedData.saveMemoryHistory (SavedData.currentUser.getName(),SavedData.currentUser.getPassword(),historyAddition);

		sounds = GetComponents<AudioSource> ();
		watchText.text = ""+MemoryMain.time + "seconds";
		if (MemoryMain.winning == true) {
			winText.text = "YOU WIN!";
			sounds [0].Play();
		} else {
			winText.text = "YOU LOSE! \n PLEASE TRY AGAIN!";
			sounds [1].Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
