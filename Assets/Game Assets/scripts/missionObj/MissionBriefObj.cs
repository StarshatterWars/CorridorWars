using UnityEngine;
using System.Collections;

public class MissionBriefObj : MonoBehaviour {
	private MainMenu grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(grGlobals.m_playerLoggedIn)
		{
			UILabel gameSect = this.gameObject.GetComponent<UILabel>();
			gameSect.text = "Mission Length is " + grGlobals.m_missionLength + " meters.";
			gameSect.color = grGlobals.m_dbColorGood;
		}
	}
}
