using UnityEngine;
using System.Collections;

public class csFireMissileButton : MonoBehaviour {
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
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
