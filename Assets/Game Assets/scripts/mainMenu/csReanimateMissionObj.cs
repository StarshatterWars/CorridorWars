using UnityEngine;
using System.Collections;

public class csReanimateMissionObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		csMainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
		if(grGlobals.reanimateMissionObj)
		{
			this.gameObject.GetComponent<Animation>()["CustomScreenOpen"].speed = 1.0f;
			this.gameObject.GetComponent<Animation>().Play("CustomScreenOpen");
			grGlobals.reanimateMissionObj = false;
		}
	}
}
