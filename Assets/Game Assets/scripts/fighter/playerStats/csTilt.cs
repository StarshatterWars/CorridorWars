using UnityEngine;
using System.Collections;

public class csTilt : MonoBehaviour {
	private csRangerWars grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = CalculateTilt(grGlobals.m_displayTilt).ToString();
		gameSect.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = CalculateTilt(grGlobals.m_displayTilt).ToString();
		gameSect.color = Color.green;
	}
	
	private string CalculateTilt(float tiltAngle)
	{
		return string.Format("{0:0.000}",  Mathf.Round(tiltAngle * 100.0f) / 100.0f);
	}
}
