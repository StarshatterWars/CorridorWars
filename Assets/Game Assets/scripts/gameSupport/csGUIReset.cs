using UnityEngine;
using System.Collections;

public class csGUIReset : MonoBehaviour {
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(grGlobals.m_missionEnd)
		{
			this.gameObject.GetComponent<Animation>()["MissionFailed"].speed = 1.0f;
			this.gameObject.GetComponent<Animation>().Play("MissionFailed");
		}
	}
}
