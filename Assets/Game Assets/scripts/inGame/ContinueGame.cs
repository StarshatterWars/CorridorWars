using UnityEngine;
using System.Collections;

public class ContinueGame : MonoBehaviour {
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
	
	public void OnPlayerContinue()
	{
		grGlobals.m_onContinueGame = true;
	}
}
