using UnityEngine;
using System.Collections;

public class csCompassN : MonoBehaviour {
	private csRangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		UISprite gameCompass = this.gameObject.GetComponent<UISprite>();
		
		if(grGlobals.m_displayDirection == 0)
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
		
		if(grGlobals.m_displayDirection == 0)
		{
			gameCompass.color = Color.blue;
		}
		else
		{
			gameCompass.color = Color.white;
		}
	}
}
