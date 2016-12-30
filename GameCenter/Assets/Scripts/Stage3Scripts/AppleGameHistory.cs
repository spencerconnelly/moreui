using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppleGameHistory : MonoBehaviour {

	public Text body;

	// Prints the history when the menu is start up
	void Start () {
		printAppleHistory ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Prints out the user's appleHistory list
	void printAppleHistory()
	{
		foreach (string x in SavedData.currentUser.appleHistory) {
			body.text = body.text + "\n"+ x;
		}
	}

}
