using UnityEngine;
using System.Collections;

public class csPartsLvl : MonoBehaviour {
	private csRangerWars grGlobals;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		UILabel gameEnergy = this.gameObject.GetComponent<UILabel>();
		gameEnergy.text = grGlobals.m_partsCollected.ToString();
		gameEnergy.color = Color.cyan;
	}
}
