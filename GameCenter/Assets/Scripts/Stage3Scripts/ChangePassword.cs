using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePassword : MonoBehaviour {

	public InputField oldPWord, newPWord;
	public Button submitButton;
	public Text success;


	void Start () {

		//action listener for the submit button in the change password menu
		submitButton.onClick.AddListener(() => { 

			// makes sure the two passwords arent the same and makes sure the user inputted the correct old password
			if(oldPWord.text == SavedData.currentUser.getPassword() && oldPWord.text != newPWord.text){
				SavedData.changePassword(SavedData.currentUser.getName(),oldPWord.text,newPWord.text);
				success.text = "Success!";
			}
			else if(oldPWord.text != SavedData.currentUser.getPassword()){ //if the old password is not correct
				success.text = "That is not your old password!";
			}
			else if(oldPWord.text == newPWord.text){ //makes sure the old and new passwords arent the same
				success.text = "Your new password cannot be the same as your old password!";
			}
		}); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
