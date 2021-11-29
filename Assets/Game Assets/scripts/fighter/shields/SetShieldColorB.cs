using UnityEngine;
using System.Collections;

public class SetShieldColorB : MonoBehaviour {
	private RangerWars grGlobals;
	public Color shieldColor; 
	private Color baseColor = Color.clear;
	private float shieldTimer = 0.0f;
	private float alphaFader;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		shieldColor = GetShieldColor(grGlobals.s_primaryShield);
	}
	
	// Update is called once per frame
	void Update () {
		if(grGlobals.m_activateShield)
		{
			shieldColor = GetShieldColor(grGlobals.s_primaryShield);
			grGlobals.m_activateShield = false;
			shieldTimer = Time.time + 5.0f;
			alphaFader = 1.0f;
		}
		
		alphaFader = alphaFader - 0.2f * Time.deltaTime;
		
		if (alphaFader <= 0.0f) 
		{
			alphaFader = 0.0f;
		}
		
		if(Time.time > shieldTimer)
		{
			shieldColor = baseColor;	
		}
		GetComponent<Renderer>().material.SetColor("_TintColor", new Color(shieldColor.r, shieldColor.g, shieldColor.b, alphaFader));
	}
	
	private Color GetShieldColor(float damageLevel)
	{
		Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		if(damageLevel <= 0.0f) damageLevel = 0.0f;
		if (damageLevel > 0.50f && damageLevel <= 0.95f)
		{
			color = new Color((1 - damageLevel) * 2, 0.75f, 0.25f, 0.50f );
		}

		if (damageLevel <= 0.50f)
		{
			color = new Color( 0.75f, (damageLevel * 2), 0.25f, 0.50f ); 
		}

		if (damageLevel <= 0.05f)
		{
			color = new Color(0.2f, 0.2f, 0.2f, 0.20f );
		}
		return color;
	}
}
