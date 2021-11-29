using UnityEngine;
using System.Collections;

public class csShipDecal : MonoBehaviour {
	private float shipColorRed;
	private float shipColorGreen;
	private float shipColorBlue;
	
	private float decalColorRed;
	private float decalColorGreen;
	private float decalColorBlue;
	
	public Material[] shipMaterial;
		
	// Update is called once per frame
	void Update () {
	
		shipColorRed = PlayerPrefs.GetFloat("ShipMainRed", 0.5f);
		shipColorGreen = PlayerPrefs.GetFloat("ShipMainGreen", 0.5f);
		shipColorBlue = PlayerPrefs.GetFloat("ShipMainBlue", 0.5f);
		
		decalColorRed = PlayerPrefs.GetFloat("ShipAltRed", 0.5f);
		decalColorGreen = PlayerPrefs.GetFloat("ShipAltGreen", 0.5f);
		decalColorBlue = PlayerPrefs.GetFloat("ShipAltBlue", 0.5f);

		GetComponent<Renderer>().sharedMaterial = shipMaterial[PlayerPrefs.GetInt("PlayerDecal", 0)];
		GetComponent<Renderer>().sharedMaterial.color = new Color(shipColorRed, shipColorGreen, shipColorBlue, 1.0f);
		GetComponent<Renderer>().sharedMaterial.SetColor("_ColorDecal", new Color(decalColorRed, decalColorGreen, decalColorBlue, 1.0f));
	}
}
