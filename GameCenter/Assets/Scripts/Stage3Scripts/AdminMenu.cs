using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdminMenu : MonoBehaviour {

	public Text usernameTitle;

	//All the ui butotns
	GameObject fileButton, addUserButton, viewUsersButton, changePWordButton, historyButton,
	rpsButton, spaceButton, memoryButton,canvasObjecthistoryButton, quitButton, applePickerButton, appleHistoryButton,
	applePlayButton, rpsHistoryButton, rpsPlayButton, spaceHistoryButton, spaceConfigButton, spaceLevelButton,
	spacePlayButton, memoryHistoryButton, memoryPlayButton, canvasObject, configurationsButton;
	Canvas canvas;

	AudioSource[] sources; // audio sources to play music


	//Booleans to help turn the menus on and off
	bool fileChanged = false,appleChanged = false,rpsChanged = false,spaceChanged = false,memoryChanged = false;

	// Use this for initialization
	void Start () {

		// all the audio sources to play the user favored music
		sources = GetComponents<AudioSource> ();
		sources [SavedData.currentUser.getSongChoice ()].Play ();

		//changes the background to the user's preferred choice
		ConfigurationsMainMenu.changeBG (SavedData.currentUser.getImageChoice());

		//The username of the user is displayed at the top of the page
		usernameTitle.text = SavedData.currentUser.getName ();

		//getting all the buttons
		fileButton = GameObject.Find ("FileButton");
		addUserButton = GameObject.Find ("AddUserButton");
		viewUsersButton = GameObject.Find ("ViewUsersButton");
		changePWordButton = GameObject.Find ("ChangePasswordButton");
		applePickerButton = GameObject.Find ("AppleButton");
		rpsButton = GameObject.Find ("RPSButton");
		spaceButton = GameObject.Find ("SpaceButton");
		memoryButton = GameObject.Find ("MemoryGameButton");
		configurationsButton = GameObject.Find ("ConfigurationsButton");
		historyButton = GameObject.Find ("Historybutton");
		quitButton = GameObject.Find ("QuitButton");
		appleHistoryButton = GameObject.Find ("ApplePickerHistoryButton");
		applePlayButton = GameObject.Find ("ApplePickerPlayButton");
		rpsHistoryButton = GameObject.Find ("RPSHistoryButton");
		rpsPlayButton = GameObject.Find ("RPSPlayButton");
		spaceHistoryButton = GameObject.Find ("SpaceHistoryButton");
		spacePlayButton = GameObject.Find ("SpacePlayButton");
		memoryHistoryButton = GameObject.Find ("MemoryHistoryButton");
		memoryPlayButton = GameObject.Find ("MemoryPlayButton");
		spaceConfigButton = GameObject.Find ("SpaceConfigButton");
		spaceLevelButton = GameObject.Find ("SpaceLevelsButton");

		//destroys all the previously instantiated submenus just in case
		GameObject[] menus;
		menus = GameObject.FindGameObjectsWithTag("menuPanel");
		for(int i = 0; i < menus.Length; i++){
			Destroy(menus[i]);
		}

		//button declaration for file. Makes the buttons interactable when clicked
		fileButton.GetComponent<Button> ().onClick.AddListener(() => { 

			if(fileChanged == false){
				
				addUserButton.GetComponent<Button>().interactable = true;
				viewUsersButton.GetComponent<Button>().interactable = true;
				changePWordButton.GetComponent<Button>().interactable = true;
				configurationsButton.GetComponent<Button>().interactable = true;
				historyButton.GetComponent<Button>().interactable = true;
				quitButton.GetComponent<Button>().interactable = true;

				fileChanged = true;
			}
			else{
				addUserButton.GetComponent<Button>().interactable = false;
				viewUsersButton.GetComponent<Button>().interactable = false;
				changePWordButton.GetComponent<Button>().interactable = false;
				configurationsButton.GetComponent<Button>().interactable = false;
				historyButton.GetComponent<Button>().interactable = false;
				quitButton.GetComponent<Button>().interactable = false;

				fileChanged = false;
			}
		});

		//displays the addusermenu when clicked
		addUserButton.GetComponent<Button> ().onClick.AddListener(() => { 
			DisplayUsers.destroyUserText();
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}


			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("AddUserMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//displays the displayusersmenu when clicked
		viewUsersButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("DisplayUsersMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//displays the change password menu when clicked
		changePWordButton.GetComponent<Button> ().onClick.AddListener(() => {
			DisplayUsers.destroyUserText();
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("ChangePasswordMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});
			
		//Displays the configurations menu when clicked
		configurationsButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("ConfigurationsMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});
			
		//quits the application when clicked
		quitButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			Application.Quit();

		});

		//similar to the file button but activates the apple picker functions
		applePickerButton.GetComponent<Button> ().onClick.AddListener(() => {
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}
			if(appleChanged == false){

				appleHistoryButton.GetComponent<Button>().interactable = true;
				applePlayButton.GetComponent<Button>().interactable = true;

				appleChanged = true;
			}
			else{

				appleHistoryButton.GetComponent<Button>().interactable = false;
				applePlayButton.GetComponent<Button>().interactable = false;

				appleChanged = false;
			}
		});

		//similar to apple picker button
		rpsButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}
			if(rpsChanged == false){

				rpsHistoryButton.GetComponent<Button>().interactable = true;
				rpsPlayButton.GetComponent<Button>().interactable = true;

				rpsChanged = true;
			}
			else{

				rpsHistoryButton.GetComponent<Button>().interactable = false;
				rpsPlayButton.GetComponent<Button>().interactable = false;

				rpsChanged = false;
			}
		});

		//similar to the apple picker button
		spaceButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}
			if(spaceChanged == false){

				spaceHistoryButton.GetComponent<Button>().interactable = true;
				spacePlayButton.GetComponent<Button>().interactable = true;
				spaceConfigButton.GetComponent<Button>().interactable = true;
				spaceLevelButton.GetComponent<Button>().interactable = true;

				spaceChanged = true;
			}
			else{

				spaceHistoryButton.GetComponent<Button>().interactable = false;
				spacePlayButton.GetComponent<Button>().interactable = false;
				spaceConfigButton.GetComponent<Button>().interactable = false;
				spaceLevelButton.GetComponent<Button>().interactable = false;

				spaceChanged = false;
			}
		});

		//Plays the space schup game when clicked
		spacePlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("_Scene_0");

		});

		//similar to the apple picker button
		memoryButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}
			if(memoryChanged == false){

				memoryHistoryButton.GetComponent<Button>().interactable = true;
				memoryPlayButton.GetComponent<Button>().interactable = true;

				memoryChanged = true;
			}
			else{

				memoryHistoryButton.GetComponent<Button>().interactable = false;
				memoryPlayButton.GetComponent<Button>().interactable = false;

				memoryChanged = false;
			}
		});

		//plays the memory game when clicked
		memoryPlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("MemoryMainMenu");

		});


		//plays rock paper scissors when clicked
		rpsPlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("RPSMainMenu");

		});

		//play applepicker when clicked
		applePlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("ApplePickerScene");

		});

		//shows the user's highscores and the date and times achieved for the memory game
		memoryHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("MemoryHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//similar to memoryHistoryButton but with rockpaperscissors
		rpsHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("RPSHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//similar to memoryHistoryButton but with applepicker
		appleHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("AppleHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//similar to memoryHistoryButton but with space shup
		spaceHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("SpaceHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//displays the configuration submenu for the space game
		spaceConfigButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("SpaceConfigs"), new Vector3(-50f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		//displays the levels subment for the space game
		spaceLevelButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("SpaceLevelsMenu"), new Vector3(-50f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
