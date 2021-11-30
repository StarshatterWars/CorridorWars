using UnityEngine;
using System.Collections;

public class MissionsComplete : MonoBehaviour {
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
		UILabel playerMissions = this.gameObject.GetComponent<UILabel>();
		playerMissions.text = grGlobals.m_playerMissions.ToString();
		playerMissions.color = Color.green;
	}
}
