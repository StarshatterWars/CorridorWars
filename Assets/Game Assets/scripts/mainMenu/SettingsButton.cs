using UnityEngine;
using System.Collections;

public class SettingsButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnSettingsButton()
	{
		MainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		grGlobals.settingsScreenActivate = true;
	}
}
