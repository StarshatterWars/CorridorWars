using UnityEngine;
using System.Collections;

public class HangerButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnHangerButton()
	{
		MainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		grGlobals.hangerScreenActivate = true;
	}
}
