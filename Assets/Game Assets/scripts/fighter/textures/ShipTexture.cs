using UnityEngine;
using System.Collections;

public class ShipTexture : MonoBehaviour {
	private float shipColorRed;
	private float shipColorGreen;
	private float shipColorBlue;
	
	private float decalColorRed;
	private float decalColorGreen;
	private float decalColorBlue;
	
	// Update is called once per frame
	void Update () {
	
		shipColorRed = PlayerPrefs.GetFloat("ShipMainRed", 0.5f);
		shipColorGreen = PlayerPrefs.GetFloat("ShipMainGreen", 0.5f);
		shipColorBlue = PlayerPrefs.GetFloat("ShipMainBlue", 0.5f);
		
		decalColorRed = PlayerPrefs.GetFloat("ShipAltRed", 0.5f);
		decalColorGreen = PlayerPrefs.GetFloat("ShipAltGreen", 0.5f);
		decalColorBlue = PlayerPrefs.GetFloat("ShipAltBlue", 0.5f);

		GetComponent<Renderer>().material.color = new Color(shipColorRed, shipColorGreen, shipColorBlue, 1.0f);
		GetComponent<Renderer>().material.SetColor("_ColorDecal", new Color(decalColorRed, decalColorGreen, decalColorBlue, 1.0f));
	}
}
