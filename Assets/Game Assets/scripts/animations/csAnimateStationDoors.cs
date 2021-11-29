using UnityEngine;
using System.Collections;

public class csAnimateStationDoors : MonoBehaviour {
private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<Animation>().Play("close");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(grGlobals.m_distanceRun > 10 && grGlobals.m_animateStationDoors)
		{
			this.gameObject.GetComponent<Animation>()["open"].speed = 1.0f;
			this.gameObject.GetComponent<Animation>().Rewind("open");
			this.gameObject.GetComponent<Animation>().Play("open");
			grGlobals.m_animateStationDoors = false;
			grGlobals.m_inCave = true;
		}
	}
}
