using UnityEngine;
using System.Collections;

public class csShieldsLvl: MonoBehaviour {
	private csRangerWars grGlobals;

	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UISprite gameShields = this.gameObject.GetComponent<UISprite>();
		gameShields.color = GetShieldColor(grGlobals.s_primaryShield);
	}
	
	// Update is called once per frame
	void Update ()
	{
		UISprite gameShields = this.gameObject.GetComponent<UISprite>();
		gameShields.color = GetShieldColor(grGlobals.s_primaryShield);
	}
	
	private Color GetShieldColor(float damageLevel)
	{
		Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		if(damageLevel <= 0.0f) damageLevel = 0.0f;
		if (damageLevel > 0.50f && damageLevel <= 0.95f)
		{
			color = new Color((1 - damageLevel) * 2, 1.0f, 0.0f, 0.50f );
		}

		if (damageLevel <= 0.50f)
		{
			color = new Color( 1.0f, (damageLevel * 2), 0.0f, 0.50f ); 
		}

		if (damageLevel <= 0.05f)
		{
			color = new Color(0.2f, 0.2f, 0.2f, 0.20f );
		}
		return color;
	}
}
