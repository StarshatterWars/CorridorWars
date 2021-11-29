using UnityEngine;
using System.Collections;

public class DisableFireButton : MonoBehaviour {
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UIButton fireButton = this.gameObject.GetComponent<UIButton>();
		if(grGlobals.s_energyAvailable > 0.25f)
		{
			fireButton.isEnabled = true;
		}
		else
		{
			fireButton.isEnabled = false;
		}
	}
}
