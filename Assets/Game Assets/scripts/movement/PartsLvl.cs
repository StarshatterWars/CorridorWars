using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartsLvl : MonoBehaviour {
	private RangerWars grGlobals;

	public Text txtEnergy;

	// Use this for initialization
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		txtEnergy.text = grGlobals.m_partsCollected.ToString();
		txtEnergy.color = Color.cyan;
	}
}
