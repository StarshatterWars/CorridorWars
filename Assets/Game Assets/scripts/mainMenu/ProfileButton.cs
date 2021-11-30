using UnityEngine;
using System.Collections;

public class ProfileButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnProfileButton()
	{
		MainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		grGlobals.profileScreenActivate = true;
	}
}
