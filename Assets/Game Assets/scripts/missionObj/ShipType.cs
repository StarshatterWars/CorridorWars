using UnityEngine;
using System.Collections;

public class ShipType : MonoBehaviour {
private MainMenu grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		UILabel shipType = this.gameObject.GetComponent<UILabel>();
		shipType.text = grGlobals.s_shipClassName + "-Class " + grGlobals.s_shipClassType;
		shipType.color = Color.cyan;
	}
}
