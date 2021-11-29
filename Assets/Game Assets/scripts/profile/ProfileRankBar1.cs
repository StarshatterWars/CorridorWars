using UnityEngine;
using System.Collections;

public class csProfileRankBar1 : MonoBehaviour {
	private csMainMenu grGlobals;
	// Use this for initialization
	private string[] rankName = new string[13] { "MSHP", "ENS", "LTJG", " LT", "LCDR", "CDR", "CPT", "CDRE", "RADM", "VADM", "ADM", "SADM", "FADM" };
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UILabel playerRank = this.gameObject.GetComponent<UILabel>();
		playerRank.text = rankName[grGlobals.m_playerRank];
		playerRank.color = Color.cyan;
	}
}
