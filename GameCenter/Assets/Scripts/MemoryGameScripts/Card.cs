using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public int value = 0;
	Renderer[] childmats = new Renderer[2];


	// Use this for initialization
	void Awake () {
		childmats = GetComponentsInChildren<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		MemoryMain.clicked (this.gameObject);
	}

	public void rotateCard()
	{
		this.gameObject.transform.Rotate (0, this.gameObject.transform.rotation.y+180, 0);
	}

	public void changeFront()
	{
		if (value == 1)
			childmats [1].material = MemoryMain.cardMats [0];
		if (value == 2) 
			childmats [1].material = MemoryMain.cardMats [1];
		if (value ==3)
			childmats [1].material = MemoryMain.cardMats [2];
		if (value ==4)
			childmats [1].material = MemoryMain.cardMats [3];
		if (value == 5)
			childmats [1].material = MemoryMain.cardMats [4];
		if (value ==6)
			childmats [1].material = MemoryMain.cardMats [5];
		if (value == 7)
			childmats [1].material = MemoryMain.cardMats [6];
		if (value == 8)
			childmats [1].material = MemoryMain.cardMats [7];
		if (value == 9)
			childmats [1].material = MemoryMain.cardMats [8];

	}

}
