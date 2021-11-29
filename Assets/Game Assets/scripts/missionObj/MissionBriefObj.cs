using UnityEngine;
using System.Collections;

public class csMissionBriefObj : MonoBehaviour {
	private csMainMenu grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
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
