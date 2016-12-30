using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewUserLoginMenu : MonoBehaviour {

	public InputField newPWordInput;
	public Button submitButton;
	public Text success;


	// this is called when a user is logged in for the first time
	void Start () {

		submitButton.onClick.AddListener(() => { 

			//new password is not the same as the default password
			if(newPWordInput.text != SavedData.currentUser.getPassword()){
				
				SavedData.changePassword(SavedData.currentUser.getName(),SavedData.currentUser.getPassword(),newPWordInput.text);
				success.text = "Success!";

				SavedData.saveChangeNewUser(SavedData.currentUser.getName(),newPWordInput.text);

				StartCoroutine(destroyMenus());

			}
			else if(newPWordInput.text == SavedData.currentUser.getPassword()){
				success.text = "Your new password must be different!";
			}
		}); 
	}

	//a couroutine is used after there is a success to delay the dissapearence of the menu
	IEnumerator destroyMenus() {
		yield return new WaitForSeconds(2);
		GameObject[] menus;
		menus = GameObject.FindGameObjectsWithTag("menuPanel");
		for(int i = 0; i < menus.Length; i++){
			Destroy(menus[i]);
		}

	}
	

}
