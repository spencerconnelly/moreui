using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceGameHistory : MonoBehaviour {

	public Text body;

	void Start () {
		printSpaceHistory ();
	}

	//prints the space game user history to the menu 
	void printSpaceHistory()
	{
		foreach (string x in SavedData.currentUser.spaceHistory) {
			body.text = body.text + "\n"+ x;
		}
	}
}
