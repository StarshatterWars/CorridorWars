using UnityEngine;
using System.Collections;

public class Loadout : MonoBehaviour {
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		UILabel shipLoadout = this.gameObject.GetComponent<UILabel>();
		shipLoadout.text = grGlobals.s_shipMissileCount.ToString();
		if(grGlobals.m_playerMissileFire)
			shipLoadout.color = Color.red;
		else
			shipLoadout.color = Color.white;
	}
}
