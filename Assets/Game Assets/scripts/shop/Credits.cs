using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	private MainMenu grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameCredits = this.gameObject.GetComponent<UILabel>();
		gameCredits.text = grGlobals.m_playerTotalParts.ToString() + " Credits";
		gameCredits.color = Color.green;
	}
}
