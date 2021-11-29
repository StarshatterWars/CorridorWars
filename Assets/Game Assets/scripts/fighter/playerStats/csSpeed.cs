using UnityEngine;
using System.Collections;

public class csSpeed : MonoBehaviour {
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UILabel gameSpeed = this.gameObject.GetComponent<UILabel>();
		
		gameSpeed.text = (grGlobals.displaySpeed * 10).ToString();
		if(grGlobals.displaySpeed < 32)
		{
			gameSpeed.color = Color.white;
			//gameSpeed.height = 36;
		}
		else if(grGlobals.displaySpeed >= 32 && grGlobals.displaySpeed < 64)
		{
			gameSpeed.color = Color.green;
			//gameSpeed.height = 36;
		}
		else if(grGlobals.displaySpeed >= 64 && grGlobals.displaySpeed < 128)
		{
			gameSpeed.color = Color.yellow;
			//gameSpeed.height = 36;
		}
		else if (grGlobals.displaySpeed >= 128)
		{
			gameSpeed.color = Color.red;
			//gameSpeed.height = 36;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		UILabel gameSpeed = this.gameObject.GetComponent<UILabel>();
		
		gameSpeed.text = (grGlobals.displaySpeed * 10).ToString();
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
