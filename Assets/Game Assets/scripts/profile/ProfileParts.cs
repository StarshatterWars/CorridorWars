using UnityEngine;
using System.Collections;

public class ProfileParts : MonoBehaviour {
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
		UILabel profileParts = this.gameObject.GetComponent<UILabel>();
		profileParts.text = grGlobals.m_playerTotalParts.ToString();
		profileParts.color = Color.green;
	}
}
