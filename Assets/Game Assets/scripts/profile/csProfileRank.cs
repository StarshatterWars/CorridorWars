using UnityEngine;
using System.Collections;

public class csProfileRank : MonoBehaviour {
	private csMainMenu grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
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
