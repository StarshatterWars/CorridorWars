using UnityEngine;
using System.Collections;

public class CompassPitch : MonoBehaviour {
	private RangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		UISprite gameCompass = this.gameObject.GetComponent<UISprite>();
		 this.transform.rotation = Quaternion.Euler(0, 0, grGlobals.m_displayBank);
	}
	
	// Update is called once per frame
	void Update () {
		UISprite gameCompass = this.gameObject.GetComponent<UISprite>();
		this.transform.rotation = Quaternion.Euler(0, 0, grGlobals.m_displayBank);
	}
}
