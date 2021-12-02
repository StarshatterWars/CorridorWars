using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loadout : MonoBehaviour {
	private RangerWars grGlobals;

	public Text shipLoadout;
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		SetMissileText();
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetMissileText();
	}

	void SetMissileText()
    {
        shipLoadout.text = grGlobals.s_shipMissileCount.ToString();
        if (grGlobals.m_playerMissileFire)
            shipLoadout.color = Color.red;
        else
            shipLoadout.color = Color.white;
    }
}
