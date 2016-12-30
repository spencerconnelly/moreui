using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryMain : MonoBehaviour {

	public Card[] cards = new Card[18];

	public static float time = 0f;
	public Text scoreField;
	static bool scoreChange = true;
	static public bool winning;
	int num1s,num2s,num3s,num4s,num5s,num6s,num7s,num8s,num9s;
	static int numCards;
	public static int score = 1000;
	public Material[] cardMatsPublic = new Material[9];
	static public Material[] cardMats = new Material[9];

	static Card selected1;
	static Card selected2;

	public static MemoryMain Instance;

	public static AudioSource[] sounds;

	// Use this for initialization
	void Start () {
		Instance = this;
		sounds = GetComponents<AudioSource> ();
		winning = false;
		num1s = 0;
		num2s = 0;
		num3s = 0;
		num4s = 0;
		num5s = 0;
		num6s = 0;
		num7s = 0;
		num8s = 0;
		num9s = 0;
		numCards = 16;
		cardMats = cardMatsPublic;
		fillValues ();

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (scoreChange == true) {
			scoreField.text = "Score: " + score;
			scoreChange = false;
		}
		if (numCards == 0) {
			winning = true;
			gameOver ();
		}
	}

	public static void clicked(GameObject selected)
	{
		Card thisCard = selected.GetComponent<Card> ();
		MemoryMain.sounds [3].Play ();
		if (selected1 == null) {
			selected1 = thisCard;
			thisCard.rotateCard();

		} else if (selected2 == null && selected.GetComponent<Card>() != selected1) {
			selected2 = thisCard;
			thisCard.rotateCard ();
			Instance.StartCoroutine ("Wait");


		}
	}

	IEnumerator Wait()
	{
		// suspend execution for 5 seconds
		yield return new WaitForSeconds(1);
		MemoryMain.compareCards ();
	}

	static void compareCards()
	{
		if (selected1.value == selected2.value) {
			MemoryMain.sounds [1].Play ();
			Destroy (selected1.gameObject);
			Destroy (selected2.gameObject);
			selected1 = null;
			selected2 = null;
			numCards -= 2;
			score = score + 100;
			scoreChange = true;
		} else {
			MemoryMain.sounds [2].Play ();
			flipBack ();
			score -= 40;
			if (score <= 0) {
				winning = false;
				gameOver ();
			}
			scoreChange = true;
		}
	}

	static void flipBack(){
		selected1.rotateCard ();
		selected2.rotateCard ();
		selected1 = null;
		selected2 = null;
	}

	void fillValues()
	{
		for (int i = 0; i < cards.Length; i++) 
		{
			int randValue = Random.Range (1, 10);
			while (true) 
			{
				if (randValue == 1 && num1s<2) {
					num1s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 2 && num2s<2) {
					num2s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 3 && num3s<2) {
					num3s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 4 && num4s<2) {
					num4s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 5 && num5s<2) {
					num5s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 6 && num6s<2) {
					num6s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 7 && num7s<2) {
					num7s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 8 && num8s<2) {
					num8s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} else if (randValue == 9 && num9s<2) {
					num9s++;
					cards [i].value = randValue;
					cards [i].changeFront ();
					break;
				} 
				randValue = Random.Range (1, 10);
			}
		}
	}

	static void gameOver()
	{
		
		SceneManager.LoadScene ("MemoryGameOverScene");	
	}
}
