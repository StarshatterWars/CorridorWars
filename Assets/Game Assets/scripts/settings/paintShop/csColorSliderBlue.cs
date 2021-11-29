using UnityEngine;
using System.Collections;

public class csColorSliderBlue : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		csSettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<csSettingsScreen>();
		UISlider colorSlider = this.gameObject.GetComponent<UISlider>();
		if(grGlobals.m_paintShopButton == 0)
		{	
			colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipMainBlue", 0.5f);
		}
		else
		{
			colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipAltBlue", 0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		csSettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<csSettingsScreen>();
		UISlider colorSlider = this.gameObject.GetComponent<UISlider>();
		if(grGlobals.m_colorButtonChangeB)
		{
			if(grGlobals.m_paintShopButton == 0)
			{	
				colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipMainBlue", 0.5f);
			}
			else
			{
				colorSlider.sliderValue = PlayerPrefs.GetFloat("ShipAltBlue", 0.5f);
			}
			grGlobals.m_colorButtonChangeB = false;
		}
		
		if(grGlobals.m_paintShopButton == 0)
		{
			PlayerPrefs.SetFloat ("ShipMainBlue", colorSlider.sliderValue );
		}
		else
		{
			PlayerPrefs.SetFloat ("ShipAltBlue", colorSlider.sliderValue );
		}
	}
}
