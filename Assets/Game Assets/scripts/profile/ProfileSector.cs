using UnityEngine;
using System.Collections;

public class csProfileSector : MonoBehaviour {
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
		UILabel playerSector = this.gameObject.GetComponent<UILabel>();
		playerSector.text = grGlobals.m_dispSector.ToUpperInvariant() + " sector";
		playerSector.color = Color.cyan;
	}
}
