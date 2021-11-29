using UnityEngine;
using System.Collections;

public class csSettingsButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnSettingsButton()
	{
		csMainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
		grGlobals.settingsScreenActivate = true;
	}
}
