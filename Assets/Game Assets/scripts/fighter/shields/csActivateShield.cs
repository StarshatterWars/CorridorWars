using UnityEngine;
using System.Collections;

public class csActivateShield : MonoBehaviour {
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
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