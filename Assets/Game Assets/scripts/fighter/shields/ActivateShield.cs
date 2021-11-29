using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour {
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag != "gameCollider" )
		{
			grGlobals.m_activateShield = true;
			//Debug.LogError(other.gameObject.name);
		}
	}
	
}