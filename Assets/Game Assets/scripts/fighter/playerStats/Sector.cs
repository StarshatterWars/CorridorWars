using UnityEngine;
using System.Collections;

public class Sector : MonoBehaviour {

	private RangerWars grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = grGlobals.m_dispSector;
		//gameDir.text = GetDirection(grGlobals.m_travelDirection);
		gameSect.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () 
	{
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = grGlobals.m_dispSector;
		//gameDir.text = GetDirection(grGlobals.m_travelDirection);
		gameSect.color = Color.cyan;
	}
}
