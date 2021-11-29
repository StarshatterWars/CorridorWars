using UnityEngine;
using System.Collections;

public class csAnimateBay : MonoBehaviour {
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
		if(grGlobals.m_distanceRun > 20 && grGlobals.m_animateBay)
		{
			this.gameObject.GetComponent<Animation>()["open"].speed = 1.0f;
			this.gameObject.GetComponent<Animation>().Rewind("open");
			this.gameObject.GetComponent<Animation>().Play("open");
			grGlobals.m_animateBay = false;
			grGlobals.m_inCave = true;
		}
	}
}
