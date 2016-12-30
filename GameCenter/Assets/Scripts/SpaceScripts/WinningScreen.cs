using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class WinningScreen : MonoBehaviour {

	AudioSource[] sources;
	AudioClip[] sounds;
	string historyAddition;



	void Start () {

		historyAddition = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")+"                             "+Main.score;
		SavedData.saveSpaceHistory (SavedData.currentUser.getName(),SavedData.currentUser.getPassword(),historyAddition);

		sounds = Resources.LoadAll<AudioClip> ("sound");
		sources = (AudioSource[]) GetComponents<AudioSource> ();
		AudioListener.volume = Configurations.volumeVal;
		sources [1].clip = sounds [Configurations.winSongChoice];
		sources [1].Play ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width/2 - 150, Screen.height - 95, 300, 35), "PLAY AGAIN")) {
			sources [0].Play ();
			StartCoroutine ("restart");
		}
		if (GUI.Button (new Rect (Screen.width/2 - 150, Screen.height - 55, 300, 35), "EXIT GAME")) {
			sources [0].Play ();
			StartCoroutine ("exit");
		}
	}

	IEnumerator restart()
	{
		yield return new WaitForSeconds(.5f);
		SceneManager.LoadScene ("_Scene_0");
	}

	IEnumerator exit()
	{
		yield return new WaitForSeconds(.5f);
		if (SavedData.currentUser.isAdmin() == false)
			SceneManager.LoadScene ("RegPlayerMenu");
		else
			SceneManager.LoadScene ("AdminMenu");
	}


}
