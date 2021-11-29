using UnityEngine;
using System.Collections;

public class csMissionObj : MonoBehaviour {
	private csRangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.lineWidth = 300;
			
		if(grGlobals.m_playerMissionPass)
		{	
			gameSect.text = "Congratulations, you have travelled the mission distance of\n " + grGlobals.m_missionLength + " meters.";
			gameSect.color = Color.green;
		}
		else
		{	
			gameSect.text = "You have travelled " + grGlobals.m_distanceRun + " out of\n" + grGlobals.m_missionLength + " meters.";
			gameSect.color = Color.red;
		}
	}
}
