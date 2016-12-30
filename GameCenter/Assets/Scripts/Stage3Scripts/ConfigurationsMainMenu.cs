using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfigurationsMainMenu : MonoBehaviour {

	static AudioSource[] sources; 

	public Dropdown songChoices, bgChoices; //dropdown menus for songs

	int imageChoice = 0, songChoice = 0; //index for song and bg choices

	Sprite blueBG,camoBG,trumpBG,eagleBG; //for the imagepreview

	public Button submitButton; //submit button in the menu

	public static Material bgMat = Resources.Load<Material>("MainMenu_Mat"); //background mat for the space game

	public Image preview; //preview square

	// Use this for initialization
	void Awake () {
		sources = GameObject.Find ("Main Camera").GetComponents<AudioSource> ();
		blueBG = Resources.Load<Sprite> ("blue");
		camoBG = Resources.Load<Sprite> ("camo");
		trumpBG = Resources.Load<Sprite> ("TRUMP");
		eagleBG = Resources.Load<Sprite> ("eagle-02");


	}

	void Start(){
		sources = GameObject.Find("Main Camera").GetComponents<AudioSource> ();


		bgChoices.onValueChanged.AddListener (delegate {
			pictureUIChange ();
		});

		songChoices.onValueChanged.AddListener (delegate {
			songUIChange();
		});

		submitButton.onClick.AddListener(() => { 
			changeBG(imageChoice);
			changeSong(songChoice);
		});

	}

	void pictureUIChange(){
		if (bgChoices.value == 0) {
			imageChoice = 0;
			preview.overrideSprite = blueBG;
		} else if (bgChoices.value == 1) {
			imageChoice = 1;
			preview.overrideSprite = camoBG;
		} else if (bgChoices.value == 2) {
			imageChoice = 2;
			preview.overrideSprite = trumpBG;
		} else {
			imageChoice = 3;
			preview.overrideSprite = eagleBG;
		}
	}

	//when the submit button is clicked this updates the material
	public static void changeBG(int choice){
		if(choice == 0){
			bgMat.SetTexture("_MainTex",Resources.Load<Texture>("blue 1"));
		} else if(choice == 1){
			bgMat.SetTexture("_MainTex",Resources.Load<Texture>("camo 1"));
		} else if(choice == 2){
			bgMat.SetTexture("_MainTex",Resources.Load<Texture>("TRUMP 1"));
		} else {
			bgMat.SetTexture("_MainTex",Resources.Load<Texture>("eagle-03"));
		}

		SavedData.saveChangeBackgroundChoice (SavedData.currentUser.getName (), SavedData.currentUser.getPassword (), choice);
	}

	//changes the song choice index
	public void songUIChange(){
		if (songChoices.value == 0) {
			songChoice = 0;
		} else if (songChoices.value == 1) {
			songChoice = 1;
		} else if (songChoices.value == 2) {
			songChoice = 2;
		} else if (songChoices.value == 3) {
			songChoice = 3;
		}
	}

	//change the song, other classes can use this when the configurations menu is not active
	public static void changeSong(int choice){
			ConfigurationsMainMenu.stopMusic ();
			sources [choice].Play ();
			SavedData.saveSongChoice (SavedData.currentUser.getName (), SavedData.currentUser.getPassword (), choice);
	}

	//stops all the other music
	public static void stopMusic(){
		for (int i = 0; i < sources.Length; i++) {
			sources [i].Stop ();
		}
	}

}
