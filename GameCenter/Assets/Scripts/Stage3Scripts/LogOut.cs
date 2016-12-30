using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//brings the user back to the login screen when the red x is clicked
	void OnMouseDown()
	{
		SceneManager.LoadScene ("LoginScreen");
	}
}
