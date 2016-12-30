using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayUsers : MonoBehaviour {
	public GameObject textStart; //where the prefabbed text begins

	//displays the name on start of the menu
	void Start () {
		fillDisplayUserNames ();
	}
		
	//Displays all the users on the display users panel
	public static void fillDisplayUserNames(){

		destroyUserText ();

		float numUsers = 0;

		int index=0;
		foreach (User x in SavedData.users) { //goes through the whole user list to print out text prefabs in the panel
			
			GameObject canvas = GameObject.Find("Canvas");
			GameObject textStart = GameObject.Find ("TextStart");


			GameObject textPrefab = (GameObject)Instantiate(Resources.Load("userTextPrefab"), new Vector3(textStart.transform.position.x, textStart.transform.position.y + numUsers*-15f, 0f), Quaternion.identity);

			textPrefab.transform.SetParent(canvas.transform,false);

			textPrefab.GetComponent<Text> ().text = x.getName ();

			if (x.isAdmin () == false) { //users can only be deleted if the user is not an admin
				GameObject deletePrefab = (GameObject)Instantiate (Resources.Load ("DeleteButton"), new Vector3 (0, .8f - .27f*numUsers, 0f), Quaternion.identity);
				deletePrefab.transform.SetParent (textPrefab.transform);
				DeleteUser thisDelete = deletePrefab.GetComponent<DeleteUser> ();
				thisDelete.associatedUser = index;
				if (x.isBlocked () == true) { //if the user is blocked, the unblockPrefab will be instantiated the same way the delete prefab is
					GameObject unblockPrefab = (GameObject)Instantiate (Resources.Load ("UnblockButton"), new Vector3 (1, .8f - .27f*numUsers, 0f), Quaternion.identity);
					unblockPrefab.transform.SetParent (textPrefab.transform);
					UnblockUser thisUnblock = unblockPrefab.GetComponent<UnblockUser> ();
					thisUnblock.associatedUser = index;
				}
			}

			index++;
			numUsers++;
		}
	}

	//this is used during the update function to delete the previous outputs
	public static void destroyUserText(){
		GameObject[] oldUserTexts;

		oldUserTexts = GameObject.FindGameObjectsWithTag ("userText");

		for (int i = 0; i < oldUserTexts.Length; i++) { //destroys the user names that were previously listed
			Destroy (oldUserTexts [i]);
		}
	}
}
