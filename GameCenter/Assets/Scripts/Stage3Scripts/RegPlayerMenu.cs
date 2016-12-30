using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegPlayerMenu : MonoBehaviour {

	//This script is attached to the page a regular user loads to

	public Text usernameTitle; //the user's name at the top of the page

	//all the buttons in the page
	GameObject fileButton, changePWordButton, historyButton, quitButton, applePickerButton, appleHistoryButton,
		applePlayButton, rpsButton, rpsHistoryButton, rpsPlayButton, spaceButton, spaceHistoryButton, spaceConfigButton, spaceLevelButton,
		spacePlayButton, memoryButton, memoryHistoryButton, memoryPlayButton, canvasObject, configurationsButton;

	bool fileChanged = false,appleChanged = false,rpsChanged = false,spaceChanged = false,memoryChanged = false;
	AudioSource[] sources; //to determine if the ui button menus are open or closed

	public string dateLoggedIn; 
	public int timeSpent;

	// Use this for initialization
	void Start () {

		//changes the song to match the user's preferred
		sources = GetComponents<AudioSource> ();
		sources [SavedData.currentUser.getSongChoice ()].Play ();


		//changes the background to match the user's preferred
		ConfigurationsMainMenu.changeBG (SavedData.currentUser.getImageChoice());


		//gets all the buttons
		fileButton = GameObject.Find ("FileButton");
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
	

		usernameTitle.text = SavedData.currentUser.getName ();


		//makes sure there are no menus open when the scene is loaded
		GameObject[] menus;
		menus = GameObject.FindGameObjectsWithTag("menuPanel");
		for(int i = 0; i < menus.Length; i++){
			Destroy(menus[i]);
		}

		//opens the new user change password menu if the user hasnt logged in before
		if (SavedData.currentUser.isNewUser () == true) {

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("FirstTimeLoginMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		}

		//all of the button implementations are almost identical to admin menu
		fileButton.GetComponent<Button> ().onClick.AddListener(() => { 
			if(fileChanged == false){

				changePWordButton.GetComponent<Button>().interactable = true;
				configurationsButton.GetComponent<Button>().interactable = true;
				historyButton.GetComponent<Button>().interactable = true;
				quitButton.GetComponent<Button>().interactable = true;

				fileChanged = true;
			}
			else{
				
				changePWordButton.GetComponent<Button>().interactable = false;
				configurationsButton.GetComponent<Button>().interactable = false;
				historyButton.GetComponent<Button>().interactable = false;
				quitButton.GetComponent<Button>().interactable = false;

				fileChanged = false;
			}
		});

		changePWordButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("ChangePasswordMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		configurationsButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("ConfigurationsMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		historyButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("History Menu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		quitButton.GetComponent<Button> ().onClick.AddListener(() => { 
			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			Application.Quit();

		});

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

		spacePlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("_Scene_0");

		});

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

		memoryPlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("MemoryMainMenu");

		});

		rpsPlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("RPSMainMenu");

		});

		applePlayButton.GetComponent<Button> ().onClick.AddListener(() => { 

			SceneManager.LoadScene("ApplePickerScene");

		});

		memoryHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("MemoryHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});


		rpsHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("RPSHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		appleHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("AppleHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		spaceHistoryButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("SpaceHistoryMenu"), new Vector3(0f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

		spaceConfigButton.GetComponent<Button> ().onClick.AddListener(() => { 

			menus = GameObject.FindGameObjectsWithTag("menuPanel");
			for(int i = 0; i < menus.Length; i++){
				Destroy(menus[i]);
			}

			GameObject canvas = GameObject.Find("Canvas");

			GameObject menu = (GameObject)Instantiate(Resources.Load("SpaceConfigs"), new Vector3(-50f, -100f, 0f), Quaternion.identity);

			menu.transform.SetParent(canvas.transform,false);

		});

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
