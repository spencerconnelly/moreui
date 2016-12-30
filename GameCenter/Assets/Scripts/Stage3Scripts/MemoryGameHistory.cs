using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryGameHistory : MonoBehaviour {

	public Text body; //the body of the menu where the history is printed

	// prints on menu startup
	void Start () {
		printMemoryHistory ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//prints out the current users memoryHistory list
	void printMemoryHistory()
	{
		foreach (string x in SavedData.currentUser.memoryHistory) {
			body.text = body.text + "\n"+ x;
		}
	}
}
