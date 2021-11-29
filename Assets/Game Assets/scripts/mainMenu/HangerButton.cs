using UnityEngine;
using System.Collections;

public class csHangerButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnHangerButton()
	{
		csMainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
		grGlobals.hangerScreenActivate = true;
	}
}
