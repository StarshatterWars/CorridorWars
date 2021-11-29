using UnityEngine;
using System.Collections;

public class csHazard3 : MonoBehaviour {
	private csRangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameObj3 = this.gameObject.GetComponent<UILabel>();
		if(grGlobals.m_missionObj3 != string.Empty) 
		{
			gameObj3.text = grGlobals.m_missionObj3.ToString();
			gameObj3.color = Color.cyan;
		}
	}
}
