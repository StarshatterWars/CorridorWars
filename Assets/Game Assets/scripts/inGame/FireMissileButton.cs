using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireMissileButton : MonoBehaviour {
	private RangerWars grGlobals;

	public Button fireMslButton;
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	public void OnFireMissile()
	{
		if(grGlobals.s_shipMissileCount > 0)
		{
			grGlobals.m_playerMissileFire = true;
			fireMslButton.enabled = true;
		}
		else
		{
			fireMslButton.enabled = false;
		}
	}
}
