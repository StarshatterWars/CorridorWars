using UnityEngine;
using System.Collections;

public class csIncreaseSpeed : MonoBehaviour {
	
	private csRangerWars grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UISprite gameSpeed = this.gameObject.GetComponent<UISprite>();
		
		if(grGlobals.displaySpeed < 32)
		{
			gameSpeed.color = Color.white;
		}
		else if(grGlobals.displaySpeed >= 32 && grGlobals.displaySpeed < 64)
		{
			gameSpeed.color = Color.green;
		}
		else if(grGlobals.displaySpeed >= 64 && grGlobals.displaySpeed < 128)
		{
			gameSpeed.color = Color.yellow;
		}
		else if (grGlobals.displaySpeed >= 128)
		{
			gameSpeed.color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		UISprite gameSpeed = this.gameObject.GetComponent<UISprite>();
		gameSpeed.color = Color.white;
		
		if(grGlobals.displaySpeed < 32)
		{
			gameSpeed.color = Color.white;
		}
		else if(grGlobals.displaySpeed >= 32 && grGlobals.displaySpeed < 64)
		{
			gameSpeed.color = Color.green;
		}
		else if(grGlobals.displaySpeed >= 64 && grGlobals.displaySpeed < 128)
		{
			gameSpeed.color = Color.yellow;
		}
		else if (grGlobals.displaySpeed >= 128)
		{
			gameSpeed.color = Color.red;
		}
	}
}
