using UnityEngine;
using System.Collections;

public class PartsCollected : MonoBehaviour {
	
	private RangerWars grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UILabel gameParts = this.gameObject.GetComponent<UILabel>();
		gameParts.text = "Total parts collected this mission: " + grGlobals.m_partsCollected.ToString ();
			
		if(grGlobals.m_playerMissionPass)
		{
			gameParts.color = Color.green;
		}
		else
		{
			gameParts.color = Color.red;
		}
	}
}
