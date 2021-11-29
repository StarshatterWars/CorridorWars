using UnityEngine;
using System.Collections;

public class FireMissileButton : MonoBehaviour {
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	public void OnFireMissile()
	{
		UIButton fireMslButton = this.gameObject.GetComponent<UIButton>();
		if(grGlobals.s_shipMissileCount > 0)
		{
			grGlobals.m_playerMissileFire = true;
			fireMslButton.isEnabled = true;
		}
		else
		{
			fireMslButton.isEnabled = false;
		}
	}
}
