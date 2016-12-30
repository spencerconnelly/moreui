using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;
	public GUIText scoreGT;

	void Start () {
		basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO ); // 3
		}
	}

	void Update()
	{
		if (Input.GetKeyDown ("escape")) {
			SceneManager.LoadScene ("RegPlayerMenu");
		}
	}

	public void AppleDestroyed() {
		//// Destroy all of the falling Apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag( "Apple" );
		foreach ( GameObject tGO in tAppleArray ) {
			Destroy( tGO );
		}
		//// Destroy one of the Baskets
		// Get the index of the last Basket in basketList
		int basketIndex = basketList.Count-1;
		// Get a reference to that Basket GameObject
		GameObject tBasketGO = basketList[basketIndex];
		// Remove the Basket from the List and destroy the GameObject
		basketList.RemoveAt( basketIndex );
		Destroy( tBasketGO );

		// Restart the game, which doesn't affect HighScore.Score
		if ( basketList.Count == 0 ) {
			markAppleScore (Basket.score);
			SceneManager.LoadScene ("ApplePickerScene");
		}
	}

	public static void markAppleScore(int score){
		string historyAddition = System.DateTime.Now.ToString ("yyyy/MM/dd hh:mm:ss") + "                             " + score;
		SavedData.saveAppleHistory (SavedData.currentUser.getName (), SavedData.currentUser.getPassword (), historyAddition);
	}

}
