using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RPSGameOver : MonoBehaviour {

	GUIStyle label = new GUIStyle(); //Style for the label that declares who won

	string historyAddition;

	// Use this for initialization
	void Start () {
		historyAddition = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")+"                             "+RPSMain.wins;
		SavedData.saveRPSHistory (SavedData.currentUser.getName (), SavedData.currentUser.getPassword (),historyAddition);

		label.fontSize = 70; 



	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			SceneManager.LoadScene("RPSMainMenu"); //Loads the Main Menu when the space bar is pressed
		}
		if (Input.GetKeyDown ("r")) {
			SceneManager.LoadScene("RPSMainGame"); //Plays the Main Game when the R key is pressed
		}
		if(Input.GetKeyDown("escape")){
			SceneManager.LoadScene("RegPlayerMenu");
		}
	}

	void OnGUI()
	{ //Determines if player won or lost based on the the static variables in the Main script
		if (RPSMain.wins > RPSMain.loss) {
			GUI.Label(new Rect(Screen.width/2-200,Screen.height/2-100,400,30), "YOU WIN!",label);
		} else if (RPSMain.loss > RPSMain.wins) {
			GUI.Label(new Rect(Screen.width/2-200,Screen.height/2-100,400,30), "YOU LOSE!",label);
		} else {
			GUI.Label(new Rect(Screen.width/2-200,Screen.height/2-100,400,30), "IT'S A DRAW!",label);
		}
	}
}
