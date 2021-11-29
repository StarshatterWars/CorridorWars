using UnityEngine;
using System.Collections;

public class csCredits : MonoBehaviour {
	private csMainMenu grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
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
