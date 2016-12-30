using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RPSGameHistory : MonoBehaviour {

	public Text body;

	// prints the history
	void Start () {
		printRPSHistory ();
	}

	//prints the rpsHistory user list
	void printRPSHistory()
	{
		foreach (string x in SavedData.currentUser.rpsHistory) {
			body.text = body.text + "\n"+ x;
		}
	}

}
