using UnityEngine;
using System.Collections;

public class Hazard2 : MonoBehaviour {
	private RangerWars grGlobals;
	
	// Use this for initialization
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameObj2 = this.gameObject.GetComponent<UILabel>();
		if(grGlobals.m_missionObj2 != string.Empty) 
		{
			gameObj2.text = grGlobals.m_missionObj2.ToString();
			gameObj2.color = Color.cyan;
		}
	}
}
