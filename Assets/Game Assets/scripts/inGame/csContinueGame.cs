using UnityEngine;
using System.Collections;

public class csContinueGame : MonoBehaviour {
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
	
	public void OnPlayerContinue()
	{
		grGlobals.m_onContinueGame = true;
	}
}
