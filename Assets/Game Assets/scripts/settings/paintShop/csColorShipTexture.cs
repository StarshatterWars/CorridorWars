using UnityEngine;
using System.Collections;

public class csColorShipTexture : MonoBehaviour {
	private Color shipMainColor;
	private float shipColorRed;
	private float shipColorGreen;
	private float shipColorBlue;
	
	// Use this for initialization
	void Start () {
		UISprite shipPic = this.gameObject.GetComponent<UISprite>();
		
		shipColorRed = PlayerPrefs.GetFloat("ShipMainRed", 0.5f);
		shipColorGreen = PlayerPrefs.GetFloat("ShipMainGreen", 0.5f);
		shipColorBlue = PlayerPrefs.GetFloat("ShipMainBlue", 0.5f);
		
		shipMainColor = new Color(shipColorRed, shipColorGreen, shipColorBlue, 1.0f);
		shipPic.color = shipMainColor;
	}
	
	// Update is called once per frame
	void Update () {
		UISprite shipPic = this.gameObject.GetComponent<UISprite>();
		
		shipColorRed = PlayerPrefs.GetFloat("ShipMainRed", 0.5f);
		shipColorGreen = PlayerPrefs.GetFloat("ShipMainGreen", 0.5f);
		shipColorBlue = PlayerPrefs.GetFloat("ShipMainBlue", 0.5f);
		
		shipMainColor = new Color(shipColorRed, shipColorGreen, shipColorBlue, 1.0f);
		
		shipPic.color = shipMainColor;
	}
}
