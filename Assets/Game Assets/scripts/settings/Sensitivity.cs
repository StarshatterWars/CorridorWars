using UnityEngine;
using System.Collections;

public class Sensitivity : MonoBehaviour {
	private float sliderVal;
	
	// Use this for initialization
	void Start () {
		UISlider sensitivity = this.gameObject.GetComponent<UISlider>();
		sliderVal = PlayerPrefs.GetFloat("InputSensitivity", 0.5f); 
		sensitivity.sliderValue = (sliderVal - 0.25f)  * 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		UISlider sensitivity = this.gameObject.GetComponent<UISlider>();
		sliderVal = sensitivity.sliderValue * 0.50f + 0.25f;
		PlayerPrefs.SetFloat("InputSensitivity", sliderVal); 
	}
}
