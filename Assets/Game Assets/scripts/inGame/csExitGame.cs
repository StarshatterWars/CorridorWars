using UnityEngine;
using System.Collections;

public class csExitGame : MonoBehaviour {
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnPlayerRestart()
	{
		grGlobals.m_onExitGame = true;
	}
}
