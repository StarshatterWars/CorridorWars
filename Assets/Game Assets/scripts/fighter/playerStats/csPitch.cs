using UnityEngine;
using System.Collections;

public class csPitch : MonoBehaviour {
	private csRangerWars grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = CalculatePitch(grGlobals.m_displayBank).ToString();
		gameSect.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		UILabel gameSect = this.gameObject.GetComponent<UILabel>();
		gameSect.text = CalculatePitch(grGlobals.m_displayBank).ToString();
		gameSect.color = Color.green;
	}
	
	private string CalculatePitch(float pitchAngle)
	{
		return string.Format("{0:000}",  Mathf.Round(pitchAngle * 100.0f) / 100.0f);
	}
}
