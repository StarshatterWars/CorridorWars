using UnityEngine;
using System.Collections;

public class csMissionBriefParts : MonoBehaviour {
	
	private csMainMenu grGlobals;
	// Use this for initialization
	
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
			UILabel gameParts = this.gameObject.GetComponent<UILabel>();
			gameParts.text = "Total parts collected: " + grGlobals.m_playerTotalParts.ToString ();
			gameParts.color = grGlobals.m_dbColorGood;
		}
	}
}
