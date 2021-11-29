using UnityEngine;
using System.Collections;

public class csSpeedSlider : MonoBehaviour {
	private float sliderVal;
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Update is called once per frame
	void Update () {
		UISlider shipSpeed = this.gameObject.GetComponent<UISlider>(); 	
		if(grGlobals.m_speedChange)
		{
			shipSpeed.sliderValue = grGlobals.m_playerVelocity / grGlobals.m_engineMultiplier;
			grGlobals.m_speedChange = false;
		}
		grGlobals.m_playerVelocity = shipSpeed.sliderValue  * grGlobals.m_engineMultiplier;
		grGlobals.m_playerSetSpeed = grGlobals.m_playerVelocity;
	}
}
