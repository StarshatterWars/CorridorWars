using UnityEngine;
using System.Collections;

public class DisableMslButton : MonoBehaviour {
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
		UIButton fireMslButton = this.gameObject.GetComponent<UIButton>();
		if(grGlobals.s_shipMissileCount > 0)
		{
			fireMslButton.isEnabled = true;
		}
		else
		{
			fireMslButton.isEnabled = false;
		}
	}
}
