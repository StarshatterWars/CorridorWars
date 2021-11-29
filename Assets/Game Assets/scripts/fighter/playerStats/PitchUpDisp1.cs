using UnityEngine;
using System.Collections;

public class PitchUpDisp1 : MonoBehaviour {

private RangerWars grGlobals;

	// Use this for initialization
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UISprite gamePitchLvl = this.gameObject.GetComponent<UISprite>();
		gamePitchLvl.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		UISprite gamePitchLvl = this.gameObject.GetComponent<UISprite>();
		if(grGlobals.m_displayTilt <= 0.05f) gamePitchLvl.color = Color.white;
		else gamePitchLvl.color = Color.green;	
	}
}
