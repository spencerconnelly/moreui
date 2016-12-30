using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeleteUser : MonoBehaviour {

	public int associatedUser;


	//Deletes the user associated with the delete button from the list and then updates the list
	void OnMouseDown()
	{
		SavedData.deleteUser (associatedUser);
		DisplayUsers.fillDisplayUserNames ();
	}


}
