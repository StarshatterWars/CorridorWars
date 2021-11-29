using UnityEngine;
using System.Collections;

public class Hazard1 : MonoBehaviour {
	private RangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameObj1 = this.gameObject.GetComponent<UILabel>();
		if(grGlobals.m_missionObj1 != string.Empty) 
		{
			gameObj1.text = grGlobals.m_missionObj1.ToString();
			gameObj1.color = Color.cyan;
		}
	}
}
