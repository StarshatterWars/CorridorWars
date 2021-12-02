using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireLaserButton : MonoBehaviour {
	private RangerWars grGlobals;

	public Button fireButton;

	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	public void OnFireLaser()
	{ 
		if(grGlobals.s_energyAvailable > 0.25f)
		{
			grGlobals.m_playerLaserFire = true;
			fireButton.enabled = true;
		}
		else
		{
			fireButton.enabled = false;
		}
	}
}
