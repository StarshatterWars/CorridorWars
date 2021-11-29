using UnityEngine;
using System.Collections;

public class csProfileName : MonoBehaviour {
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
		UILabel playerName = this.gameObject.GetComponent<UILabel>();
		playerName.text = grGlobals.m_displayName.ToUpperInvariant();
		playerName.color = Color.cyan;
	}
}
