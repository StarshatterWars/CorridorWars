using UnityEngine;
using System.Collections;

public class csProfileBar : MonoBehaviour {
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
		UISprite playerRankStatus = this.gameObject.GetComponent<UISprite>();
		
		if(grGlobals.m_playerRankComplete > 0)
		{
			playerRankStatus.color = GetBarColor(grGlobals.m_playerRankComplete/100.0f);
			playerRankStatus.transform.localScale = new Vector3(260.0f * grGlobals.m_playerRankComplete/100.0f, 10.0f, 1.0f);
		}
		else
		{
			playerRankStatus.color = Color.clear;
		}
	}
	
	private Color GetBarColor(float barLevel)
	{
		Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		if(barLevel <= 0.0f) barLevel = 0.0f;
		if (barLevel >= 0.50f && barLevel <= 1.00f)
		{
			color = new Color((1 - barLevel) * 2, 1.0f, 0.0f, 0.75f );
		}

		if (barLevel >= 0.0f && barLevel < 0.50f)
		{
			color = new Color( 1.0f, (barLevel * 2), 0.0f, 0.75f ); 
		}
		
		return color;
	}
}
