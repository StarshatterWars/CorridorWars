using UnityEngine;
using System.Collections;

public class csProfileButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnProfileButton()
	{
		csMainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
		grGlobals.profileScreenActivate = true;
	}
}
