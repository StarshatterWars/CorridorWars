using UnityEngine;
using System.Collections;

public class EnergyLvl5 : MonoBehaviour {
	private RangerWars grGlobals;
	
	// Use this for initialization
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UISprite gameShields = this.gameObject.GetComponent<UISprite>();
		gameShields.color = GetShieldColor(grGlobals.s_energyAvailable);
	}
	
	// Update is called once per frame
	void Update ()
	{
		UISprite gameShields = this.gameObject.GetComponent<UISprite>();
		gameShields.color = GetShieldColor(grGlobals.s_energyAvailable);
	}
	
	private Color GetShieldColor(float damageLevel)
	{
		Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		if(damageLevel <= 0.0f) damageLevel = 0.0f;
		if (damageLevel >= 0.75f && damageLevel <= 1.00f)
		{
			color = new Color((1 - damageLevel) * 2, 1.0f, 0.0f, 0.50f );
		}

		if (damageLevel < 0.75f)
		{
			color = new Color(0.2f, 0.2f, 0.2f, 0.20f );
		}
		return color;
	}
}
