using UnityEngine;
using System.Collections;

public class CompassE : MonoBehaviour {

	private RangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		UISprite gameCompass = this.gameObject.GetComponent<UISprite>();
		
		if(grGlobals.m_displayDirection == 2)
		{
			gameCompass.color = Color.blue;
		}
		else
		{
			gameCompass.color = Color.white;
		}
	}
	
	// Update is called once per frame
	void Update () {
		UISprite gameCompass = this.gameObject.GetComponent<UISprite>();
		
		if(grGlobals.m_displayDirection == 2)
		{
			gameCompass.color = Color.blue;
		}
		else
		{
			gameCompass.color = Color.white;
		}
	}
}

