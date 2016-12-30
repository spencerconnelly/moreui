using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//quits the application when clicked
	void OnMouseDown(){
		Application.Quit ();
	}
}
