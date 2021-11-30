using UnityEngine;
using System.Collections;

public class GeldColor : MonoBehaviour {
	private MainMenu grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
	}
	// Use this for initialization
	void Start () {
		UISprite geldColor = this.gameObject.GetComponent<UISprite>();
		geldColor.color = new Color(1.0f, 0.811f, 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		UISprite geldColor = this.gameObject.GetComponent<UISprite>();
		geldColor.color = new Color(1.0f, 0.811f, 0.0f, 1.0f);
	}
}
