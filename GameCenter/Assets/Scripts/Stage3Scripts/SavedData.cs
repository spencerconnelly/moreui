using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SavedData {

	//This script is where all the data is saved to a file and the users list is held
	//every function opens and closes the file because I had issues saving before that was implemented

	static FileStream file; //the file object where the users are stored
	static BinaryFormatter bf;

	public static List<User> users = new List<User>(); //list of users

	public static User currentUser = null; //this is used to determine the user currently logged in and helps save data

	public static User checkedUser; //helps with the blocking feature

	//Adds a user to the list if the username is not in use
	//If there is no saved file, this function creates one
	public static void AddUser( string user, string pass, bool admin)
	{
			if (File.Exists (Application.persistentDataPath + "/users.gd")) {
				openFile ();
				if (checkUserName (user) == true) {
					users.Add (new User (user, pass, admin));
					closeFile ();
					Debug.Log ("opened file and added user");
				} else
					Debug.Log ("username already exists in users");
			}
			else {
				users.Add (new User (user, pass, admin));
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Create (Application.persistentDataPath + "/users.gd");
				bf.Serialize (file, SavedData.users);
				file.Close ();
				Debug.Log ("created file and added user");
			}

	}

	//loads the user into the package, if the username/password isnt valid, tells login screen to print
	//the error message
	public static void Load(string user, string pass){
		if (File.Exists (Application.persistentDataPath + "/users.gd")) {
			openFile ();
			if (loadUser (user, pass) == true  && currentUser.isBlocked() == false) {
				currentUser.resetConsecAttempts ();
				LoginScreen.error = false;
				if (SavedData.currentUser.isAdmin () == true)
					SceneManager.LoadScene ("AdminMenu");
				else
					SceneManager.LoadScene ("RegPlayerMenu");
			}
			else {

				if (checkUserName (user) == false) {
					wrongPasswordUser (user);
				}
					

				LoginScreen.error = true;
			}

		}
	}

	//sets the current user when sent the username and password
	static bool loadUser(string user, string pass){
		foreach(User x in users){
			if (x.getName () == user && x.getPassword () == pass) {
				currentUser = x;
				return true;
			}
		}
		return false;
	}

	//helps count the number of times a user logged in incorrectly before blocking the user
	static void wrongPasswordUser(string user){
		openFile ();
		foreach(User x in users){
			if (x.getName () == user) {
				x.consecAttemptsIncrease ();
				if (x.getConsecAttempts() >= 3) {
					x.block ();
					LoginScreen.blocked = true;
				}
			}
		}
		closeFile ();
	}

	//returns false if the username is in use
	public static bool checkUserName(string user)
	{
		openFile ();


		foreach (User x in users) {
			if (x.getName () == user) {
				checkedUser = x;
				return false;
			}

		}
		return true;
	}

	//saves the password change to the user in the file
	public static void changePassword(string user, string oldPWord, string newPWord){
		openFile ();

		loadUser (user, oldPWord);
		currentUser.setPassword (newPWord);

		closeFile ();
	}

	//saves the removal of a user from the list
	public static void deleteUser(int x){
		
		openFile ();

		users.RemoveAt(x);

		closeFile ();
	}

	//unblocks a user from the list
	public static void unblockUser(int x){

		openFile ();
		users [x].unblock ();
		closeFile ();

	}

	//makes the user a 'new user' and saves it to the file
	public static void saveChangeNewUser(string user, string password){
		openFile ();

		loadUser (user, password);
		currentUser.changeNewUser ();

		closeFile ();
	}

	//saves the users preferred background
	public static void saveChangeBackgroundChoice(string user, string password, int choice){
		openFile ();

		loadUser (user, password);
		currentUser.setImageChoice (choice);

		closeFile ();
	}

	//saves the users preferred song choice
	public static void saveSongChoice(string user, string password, int choice){
		openFile ();

		loadUser (user, password);
		currentUser.setSongChoice (choice);

		closeFile ();
	}

	//saves the users memory game scores
	public static void saveMemoryHistory(string user, string password,string history){
		openFile ();

		loadUser (user, password);
		currentUser.memoryHistory.Add(history);

		closeFile ();
	}

	//saves the users RPS game scores
	public static void saveRPSHistory(string user, string password,string history){
		openFile ();

		loadUser (user, password);
		currentUser.rpsHistory.Add(history);

		closeFile ();
	}

	//saves the users apple picker game scores
	public static void saveAppleHistory(string user, string password, string history){

		openFile ();

		loadUser (user, password);
		currentUser.appleHistory.Add (history);

		closeFile ();
	}

	//saves the users space shooter game scores
	public static void saveSpaceHistory(string user, string password, string history){

		openFile ();

		loadUser (user, password);
		currentUser.spaceHistory.Add (history);

		closeFile ();
	}

	//deletes all the users if need be
	public static void deleteAll(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/users.gd");
		bf.Serialize (file, SavedData.users);
		file.Close ();
	}

	//reusable function to open the serialized file
	static void openFile()
	{
		file = File.Open (Application.persistentDataPath + "/users.gd", FileMode.Open);
		bf = new BinaryFormatter ();
		SavedData.users = (List<User>)bf.Deserialize (file);
		file.Close ();
	}

	//reusable function to close and serialize the file
	static void closeFile(){
		file = File.Open (Application.persistentDataPath + "/users.gd", FileMode.Open);
		bf.Serialize (file, SavedData.users);
		file.Close ();
	}

}
