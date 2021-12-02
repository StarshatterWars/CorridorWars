using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private RangerWars grGlobals;

    public Text gameTimer;

    // Use this for initialization
    void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () 
	{
		gameTimer.text = DisplayTime(grGlobals.m_playerTime);
		gameTimer.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameTimer.text = DisplayTime(grGlobals.m_playerTime);
		gameTimer.color = Color.red;
	}
	
	private string DisplayTime(float timeIn)
	{
		int timeSeconds;
		int timeMinutes;
		int timeData;
		string timeStr, tStrSec, tStrMin;
			
		timeData = Mathf.RoundToInt(timeIn);
		timeSeconds = timeData % 60;
		timeMinutes = timeData / 60;
		
		if(timeSeconds < 10) 
			tStrSec = "0" + timeSeconds.ToString();
		else
			tStrSec = timeSeconds.ToString();
		
		if(timeMinutes < 10) 
			tStrMin = "0" + timeMinutes.ToString();
		else
			tStrMin = timeMinutes.ToString();
		
		timeStr = tStrMin + ":" + tStrSec;
		
		return timeStr;
	}
}
