using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
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
