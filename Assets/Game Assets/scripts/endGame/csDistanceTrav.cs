using UnityEngine;
using System.Collections;

public class DistanceTrav : MonoBehaviour {
	private RangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = "Distance: " + grGlobals.displayDist.ToString () + " out of " + grGlobals.m_missionLength.ToString () + " m."
									 + "\nBest Dist: " + grGlobals.m_distanceRunBest.ToString ();
		if(grGlobals.m_playerMissionPass) gameSect.color = Color.green;
		else gameSect.color = Color.red;
	}
}
