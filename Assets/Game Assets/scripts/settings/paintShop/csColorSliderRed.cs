using UnityEngine;
using System.Collections;

public class csColorSliderRed : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		csSettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<csSettingsScreen>();
		UISlider colorSlider = this.gameObject.GetComponent<UISlider>();
		if(grGlobals.m_paintShopButton == 0)
		{
			colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipMainRed", 0.5f);
		}
		else
		{
			colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipAltRed", 0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		csSettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<csSettingsScreen>();
		UISlider colorSlider = this.gameObject.GetComponent<UISlider>();
		if(grGlobals.m_colorButtonChangeR)
		{
			if(grGlobals.m_paintShopButton == 0)
			{
				colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipMainRed", 0.5f);
			}
			else
			{
				colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipAltRed", 0.5f);
			}
			grGlobals.m_colorButtonChangeR = false;
		}
		if(grGlobals.m_paintShopButton == 0)
		{
			PlayerPrefs.SetFloat ("ShipMainRed", colorSlider.sliderValue );
		}
		else
		{
			PlayerPrefs.SetFloat ("ShipAltRed", colorSlider.sliderValue );
		}

	}
}
