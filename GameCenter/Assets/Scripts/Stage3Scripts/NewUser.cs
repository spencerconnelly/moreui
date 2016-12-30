using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Admins use this to add users to the database
public class NewUser : MonoBehaviour {

	public InputField newUserInput;
	public Dropdown adminDropdown;
	public Button submitButton;
	public Text successMessage;


	bool admin = false; //default for new user is not being an admin


	void Start () {


		submitButton.onClick.AddListener(() => {
			//if there is no user name with the input
			if(SavedData.checkUserName(newUserInput.text) == true){
				SavedData.AddUser(newUserInput.text,newUserInput.text,admin);
				successMessage.text = "Success!";   
			}
			else
				successMessage.text = "That username already exists!";
		}); 
	}
	

	//determines if the new user will be an admin or not
	void Update () {
		if (adminDropdown.value == 0)
			admin = false;
		else if (adminDropdown.value == 1)
			admin = false;
		else
			admin = true;
	}
		
}
