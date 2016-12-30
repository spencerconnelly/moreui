using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceLevelsMenu : MonoBehaviour {

	//Reuse of the Space levels script and is attached to the space levels menu

	static public int bDifficulty = 0, sDifficulty = 0, gDifficulty = 0;
	static public int bPtLevelUp = 250, sPtLevelUp = 1000, gPtLevelUp = 2000;
	public Dropdown ddDiff1, ddDiff2, ddDiff3,bptdd,sptdd,gptdd;

	// Use this for initialization
	void Start () {
		ddDiff1.onValueChanged.AddListener (delegate {
			bronzeDiffChange();
		});

		ddDiff1.onValueChanged.AddListener (delegate {
			silverDiffChange();
		});

		ddDiff1.onValueChanged.AddListener (delegate {
			goldDiffChange();
		});

		bptdd.onValueChanged.AddListener (delegate {
			bPtsChange();
		});
		sptdd.onValueChanged.AddListener (delegate {
			sPtsChange();
		});
		gptdd.onValueChanged.AddListener (delegate {
			gPtsChange();
		});
	}
	
	void bronzeDiffChange()
	{
		bDifficulty = ddDiff1.value;
	}

	void silverDiffChange()
	{
		sDifficulty = ddDiff2.value;
	}

	void goldDiffChange()
	{
		gDifficulty = ddDiff3.value;
	}

	void bPtsChange()
	{
		if (bptdd.value == 0)
			bPtLevelUp = 250;
		if (bptdd.value == 1)
			bPtLevelUp = 500;
		if (bptdd.value ==2)
			bPtLevelUp =750;
	}

	void sPtsChange()
	{
		if (sptdd.value == 0)
			sPtLevelUp = 1000;
		if(sptdd.value == 1)
			sPtLevelUp = 1500;
		if(sptdd.value == 2)
			sPtLevelUp = 1750;
	}

	void gPtsChange()
	{
		if (gptdd.value == 0)
			gPtLevelUp = 2000;
		if(gptdd.value == 1)
			gPtLevelUp = 2500;
		if(gptdd.value == 2)
			gPtLevelUp = 3000;
	}
}
