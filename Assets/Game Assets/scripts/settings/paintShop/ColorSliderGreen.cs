using UnityEngine;
using System.Collections;

public class ColorSliderGreen: MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		SettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<SettingsScreen>();
		UISlider colorSlider = this.gameObject.GetComponent<UISlider>();
		if(grGlobals.m_paintShopButton == 0)
		{
			colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipMainGreen", 0.5f);
		}
		else
		{
			colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipAltGreen", 0.5f);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		SettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<SettingsScreen>();
		UISlider colorSlider = this.gameObject.GetComponent<UISlider>();
		if(grGlobals.m_colorButtonChangeG)
		{
			if(grGlobals.m_paintShopButton == 0)
			{
				colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipMainGreen", 0.5f);
			}
			else
			{
				colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipAltGreen", 0.5f);
			}	
			grGlobals.m_colorButtonChangeG = false;
		}
		if(grGlobals.m_paintShopButton == 0)
		{
			PlayerPrefs.SetFloat ("ShipMainGreen", colorSlider.sliderValue );
		}
		else
		{
			PlayerPrefs.SetFloat ("ShipAltGreen", colorSlider.sliderValue );
		}
	}
}
