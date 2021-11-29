using UnityEngine;
using System.Collections;

public class csMissionsComplete : MonoBehaviour {
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
		UILabel playerMissions = this.gameObject.GetComponent<UILabel>();
		playerMissions.text = grGlobals.m_playerMissions.ToString();
		playerMissions.color = Color.green;
	}
}
