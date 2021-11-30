using UnityEngine;
using System.Collections;

public class ProfileSector : MonoBehaviour {
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
		UILabel playerSector = this.gameObject.GetComponent<UILabel>();
		playerSector.text = grGlobals.m_dispSector.ToUpperInvariant() + " sector";
		playerSector.color = Color.cyan;
	}
}
