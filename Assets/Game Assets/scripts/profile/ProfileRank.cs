using UnityEngine;
using System.Collections;

public class ProfileRank : MonoBehaviour {
	private MainMenu grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UILabel playerRank = this.gameObject.GetComponent<UILabel>();
		playerRank.text = grGlobals.m_displayRank.ToUpperInvariant();
		playerRank.color = Color.cyan;
	}
}
