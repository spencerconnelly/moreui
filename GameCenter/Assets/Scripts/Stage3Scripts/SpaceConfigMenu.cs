using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceConfigMenu : MonoBehaviour {

	//Reuse of the code from Stage 2 and is attached to the config menu
	//All the savable variables are listed and can be used in the game

	public AudioClip[] sounds;

	public Dropdown bgSongChoices, winSongChoices, weaponSounds, color0, 
	color1, color2, color3, color4, imageChoices;

	public static int enemy0Score = 100, enemy1Score = 100, enemy2Score = 100, enemy3Score = 100, enemy4Score = 100, 
	bgSongChoice=3, winSongChoice=1, weaponSound = 0;

	public Material mat0,mat1,mat2,mat3,mat4,bgmat;

	public Text text0,text1,text2,text3,text4;

	public Image preview;

	float scroll0, scroll1, scroll2, scroll3, scroll4;

	public Button submit;

	Sprite x,y,z;
	int imageChoice = 0;

	void Awake()
	{
		sounds = Resources.LoadAll<AudioClip> ("sound");
		x = Resources.Load<Sprite> ("Space 1");
		y = Resources.Load<Sprite>("galaxy 1");
		z = Resources.Load<Sprite> ("blackhole 1");
	}

	// Use this for initialization
	void Start () {
	
		color0.onValueChanged.AddListener (delegate {
			color0Change ();
		});

		color1.onValueChanged.AddListener (delegate {
			color1Change ();
		});

		color2.onValueChanged.AddListener (delegate {
			color2Change ();
		});

		color3.onValueChanged.AddListener (delegate {
			color3Change ();
		});

		color4.onValueChanged.AddListener (delegate {
			color4Change ();
		});

		bgSongChoices.onValueChanged.AddListener (delegate {
			bgSongChange ();

		});

		winSongChoices.onValueChanged.AddListener (delegate {
			winSongChange ();

		});

		weaponSounds.onValueChanged.AddListener (delegate {
			weaponSoundChange ();

		});

		imageChoices.onValueChanged.AddListener (delegate {
			pictureUIChange ();
		});

		submit.onClick.AddListener(() => { 
			confirmBGChange();
		});


	}

	void Update(){
		scroll0 = GameObject.Find ("Enemy 0 Slider").GetComponent<Slider>().value;
		scroll1 = GameObject.Find ("Enemy 1 Slider").GetComponent<Slider>().value;
		scroll2 = GameObject.Find ("Enemy 2 Slider").GetComponent<Slider>().value;
		scroll3 = GameObject.Find ("Enemy 3 Slider").GetComponent<Slider>().value;
		scroll4 = GameObject.Find ("Enemy 4 Slider").GetComponent<Slider>().value;

		enemy0Score = Mathf.FloorToInt(scroll0 * 100);
		enemy1Score = Mathf.FloorToInt(scroll1 * 100);
		enemy2Score = Mathf.FloorToInt(scroll2 * 100);
		enemy3Score = Mathf.FloorToInt(scroll3 * 100);
		enemy4Score = Mathf.FloorToInt(scroll4 * 100);

		text0.text = ""+enemy0Score;
		text1.text = ""+enemy1Score;
		text2.text = ""+enemy2Score;
		text3.text = ""+enemy3Score;
		text4.text = ""+enemy4Score;
	}

	void bgSongChange()
	{
		if (bgSongChoices.value == 0) {
			bgSongChoice = 3;
		} else if (bgSongChoices.value == 1) {
			bgSongChoice = 6;
		} else {
			bgSongChoice = 0;
		}
	}

	void winSongChange()
	{
		if (winSongChoices.value == 0) {
			winSongChoice = 3;
		} else {
			winSongChoice = 4;
		} 
	}

	void weaponSoundChange()
	{
		if (weaponSounds.value == 0) {
			weaponSound = 0;;
		} else {
			weaponSound = 1;
		} 
	}

	void color0Change()
	{
		if (color0.value == 0) {
			mat0.SetColor ("_Color", Color.white);
		} else if (color0.value == 1) {
			mat0.SetColor ("_Color", Color.green);
		} else if (color0.value == 2) {
			mat0.SetColor ("_Color", Color.blue);
		} else if (color0.value == 3) {
			mat0.SetColor ("_Color", Color.red);
		}
	}
	void color1Change ()
	{
		if (color1.value == 0) {
			mat1.SetColor ("_Color", Color.white);
		} else if (color1.value == 1) {
			mat1.SetColor ("_Color", Color.green);
		} else if (color1.value == 2) {
			mat1.SetColor ("_Color", Color.blue);
		} else if (color1.value == 3) {
			mat1.SetColor ("_Color", Color.red);
		}
	}
	void color2Change ()
	{
		if (color2.value == 0) {
			mat2.SetColor ("_Color", Color.white);
		} else if (color2.value == 1) {
			mat2.SetColor ("_Color", Color.green);
		} else if (color2.value == 2) {
			mat2.SetColor ("_Color", Color.blue);
		} else if (color2.value == 3) {
			mat2.SetColor ("_Color", Color.red);
		}
	}
	void color3Change ()
	{
		if (color3.value == 0) {
			mat3.SetColor ("_Color", Color.white);
		} else if (color3.value == 1) {
			mat3.SetColor ("_Color", Color.green);
		} else if (color3.value == 2) {
			mat3.SetColor ("_Color", Color.blue);
		} else if (color3.value == 3) {
			mat3.SetColor ("_Color", Color.red);
		}
	}
	void color4Change ()
	{
		if (color4.value == 0) {
			mat4.SetColor ("_Color", Color.white);
		} else if (color4.value == 1) {
			mat4.SetColor ("_Color", Color.green);
		} else if (color4.value == 2) {
			mat4.SetColor ("_Color", Color.blue);
		} else if (color4.value == 3) {
			mat4.SetColor ("_Color", Color.red);
		}
	}

	void pictureUIChange()
	{
		if (imageChoices.value == 0) {
			imageChoice = 0;
			preview.overrideSprite =  x;
		} else if (imageChoices.value == 1) {
			imageChoice = 1;
			preview.overrideSprite = y;
		} else {
			imageChoice = 2;
			preview.overrideSprite = z;
		}
	}
		
	void confirmBGChange(){
		if (imageChoice == 0) {
			bgmat.SetTexture("_MainTex",Resources.Load<Texture>("Space_Transparent"));
		}
		else if (imageChoice == 1) {
			bgmat.SetTexture("_MainTex",Resources.Load<Texture>("galaxy"));
		}
		else if (imageChoice == 2) {
			bgmat.SetTexture("_MainTex",Resources.Load<Texture>("blackhole"));
		}
	}

}
