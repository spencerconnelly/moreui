using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class User {

	//Where each accounts information is stored

	string username, password;
	bool admin, newUser = false, blocked = false;
	int bgChoice = 0;
	int songChoice = 0;
	int consecAttempts = 0;

	public List<string> memoryHistory = new List<string> ();
	public List<string> rpsHistory = new List<string>();
	public List<string> appleHistory = new List<string> ();
	public List<string> spaceHistory = new List<string> ();



	public User(string user, string pass, bool admin){
		username = user;
		password = pass;
		this.admin = admin;
		if (admin == false)
			newUser = true;
		consecAttempts = 0;
	}


	//All getters and setters for the Account

	public string getName(){
		return username;
	}

	public string getPassword(){
		return password;
	}

	public bool isAdmin(){
		return admin;
	}

	public void setPassword(string pWord){
		password = pWord;
	}

	public bool isNewUser()
	{
		return newUser;
	}

	public void changeNewUser(){
		newUser = false;
	}

	public void setImageChoice(int x){
		bgChoice = x;
	}

	public int getImageChoice(){
		return bgChoice;
	}

	public void setSongChoice(int x){
		songChoice = x;
	}

	public int getSongChoice(){
		return songChoice;
	}

	public void unblock(){
		blocked = false;
	}

	public void block(){
		blocked = true;
	}

	public void consecAttemptsIncrease(){
		consecAttempts++;
	}

	public int getConsecAttempts(){
		return consecAttempts;
	}

	public void resetConsecAttempts(){
		consecAttempts = 0;
	}

	public bool isBlocked()
	{
		return blocked;
	}

}
