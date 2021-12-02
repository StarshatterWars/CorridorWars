using UnityEngine;
using System.Collections;

public class SpeedSlider : MonoBehaviour {
	private float sliderVal;
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Update is called once per frame
	void Update () {
		UISlider shipSpeed = this.gameObject.GetComponent<UISlider>(); 	
		if(grGlobals.m_speedChange)
		{
			shipSpeed.value = grGlobals.m_playerVelocity / grGlobals.m_engineMultiplier;
			grGlobals.m_speedChange = false;
		}
		grGlobals.m_playerVelocity = shipSpeed.value  * grGlobals.m_engineMultiplier;
		grGlobals.m_playerSetSpeed = grGlobals.m_playerVelocity;
	}
}
