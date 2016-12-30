using UnityEngine;
using System.Collections;

public class UnblockUser : MonoBehaviour {

	public int associatedUser;

	// finds the parent of the text game object
	void Start () {

	}

	//unblocks the user
	void OnMouseDown()
	{
		SavedData.unblockUser (associatedUser);
		DisplayUsers.fillDisplayUserNames ();
	}
}
