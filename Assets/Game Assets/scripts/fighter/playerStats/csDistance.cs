using UnityEngine;
using System.Collections;

public class csDistance : MonoBehaviour {
private csRangerWars grGlobals;
private float calcDistPercent;
private float calcDist;	
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		UILabel gameDist = this.gameObject.GetComponent<UILabel>();
		
		calcDist = grGlobals.m_missionLength - grGlobals.displayDist;
		if (calcDist <= 0) calcDist = 0;
		gameDist.text = Mathf.RoundToInt(calcDist).ToString();
		calcDistPercent = (grGlobals.m_missionLength - grGlobals.displayDist)/ grGlobals.m_missionLength;
		
		if(calcDistPercent > 0.66f) gameDist.color = Color.red;
		else if(calcDistPercent > 0.33f && calcDistPercent <= 0.66f) gameDist.color = Color.yellow;
		else gameDist.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () 
	{
		UILabel gameDist = this.gameObject.GetComponent<UILabel>();
		calcDist = grGlobals.m_missionLength - grGlobals.displayDist;
		if (calcDist <= 0) calcDist = 0;
		gameDist.text = Mathf.RoundToInt(calcDist).ToString();
		
		calcDistPercent = (grGlobals.m_missionLength - grGlobals.displayDist)/ grGlobals.m_missionLength;
		
		if(calcDistPercent > 0.66f) gameDist.color = Color.red;
		else if(calcDistPercent > 0.33f && calcDistPercent <= 0.66f) gameDist.color = Color.yellow;
		else gameDist.color = Color.green;
	}
}
