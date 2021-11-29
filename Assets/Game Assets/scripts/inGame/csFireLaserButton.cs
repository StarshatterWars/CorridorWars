using UnityEngine;
using System.Collections;

public class csFireLaserButton : MonoBehaviour {
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	public void OnFireLaser()
	{
		UIButton fireButton = this.gameObject.GetComponent<UIButton>();
		if(grGlobals.s_energyAvailable > 0.25f)
		{
			grGlobals.m_playerLaserFire = true;
			fireButton.isEnabled = true;
		}
		else
		{
			fireButton.isEnabled = false;
		}
	}
}
