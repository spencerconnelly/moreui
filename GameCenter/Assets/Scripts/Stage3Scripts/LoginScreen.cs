using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour {

	public static bool error, blocked; //booleans to see if there is an error and/or the user is blocked

	public Text errorText; //the location of the error message

	public InputField userInput, passInput; //user and password inputs


	// Adds the admin user and makes sure the user isnt blocked
	void Start () {
		blocked = false;
		SavedData.AddUser ("admin","admin",true);
	}
	
	// Determines if there is an error or not and if there is, the errorMessage or blockedMessage is displayed
	//error is set in the SaveData class
	void Update () {

		if (error == true) {
			if (blocked == false)
				errorMessage ();
			else
				blockedMessage ();
		}
		if (error == false)
			errorText.text = "";

	}

	//Writes the error Message from invalid login
	public void errorMessage()
	{
		errorText.text = "Invalid Username or Password please try again.";

	}

	//Writes the blocked message is the attempted user is blocked
	public void blockedMessage(){
		errorText.text = "You are blocked! Please contact Administrator.";
	}

	//when the login butotn is clicked, the save data class loads the user of that name and password
	void OnMouseDown()
	{
		SavedData.Load (userInput.text, passInput.text);
	}

}
