using UnityEngine;
using System.Collections;

public class csShipType : MonoBehaviour {
private csMainMenu grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
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
