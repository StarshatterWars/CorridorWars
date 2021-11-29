using UnityEngine;
using System.Collections;

public class csFBButtonStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UISprite fbButton = this.gameObject.GetComponent<UISprite>();
		if(PlayerPrefs.GetInt("FacebookLogin", 0) == 0) fbButton.color = Color.gray;
		else if(PlayerPrefs.GetInt("FacebookLogin", 0) == 1) fbButton.color = Color.blue;
		else if(PlayerPrefs.GetInt("FacebookLogin", 0) == 2) fbButton.color = Color.green;
	}
}
