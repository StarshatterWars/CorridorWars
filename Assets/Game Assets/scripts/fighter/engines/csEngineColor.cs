using UnityEngine;
using System.Collections;

public class csEngineColor : MonoBehaviour {
	private csRangerWars grGlobals;
	private Color engineColor = Color.cyan;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		csRangerWars grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
		engineColor = new Color(0.0f, 1.0f, 1.0f, grGlobals.m_playerVelocity);
		GetComponent<Renderer>().material.color = engineColor;
		GetComponent<Renderer>().material.SetFloat("_SelfIllumination", grGlobals.m_playerVelocity);
	}
}
