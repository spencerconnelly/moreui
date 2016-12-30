using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Colors : MonoBehaviour {
	public Dropdown colors;
	public Material background;
	// Use this for initialization
	void Start () {

		colors.onValueChanged.AddListener (delegate {
			changeColor ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeColor(){
		if (colors.value == 0) {
			background.SetColor("_Color",Color.yellow);
		} else if (colors.value == 1) {
			background.SetColor("_Color",Color.blue);
		} else {
			background.SetColor("_Color",Color.red);
		}
	}
} 
