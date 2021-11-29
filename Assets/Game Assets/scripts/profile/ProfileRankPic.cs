using UnityEngine;
using System.Collections;

public class csProfileRankPic : MonoBehaviour {
	private csMainMenu grGlobals;
	// Use this for initialization
	private string[] rankPic = new string[13] { "RankMidshipman", "RankEnsign", "RankLtJR", "RankLt", "RankLtCommander", "RankCommander", "RankCaptain", "RankCommodore", "RankViceAdmiral", "RankRearAdmiral", "RankAdmiral", "RankAdmiral", "RankFleetAdmiral" };
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
	}
	
	// Use this for initialization
	void Start () {
		UISprite playerRankPic = this.gameObject.GetComponent<UISprite>();
		playerRankPic.spriteName = rankPic[grGlobals.m_playerRank];
	}
	
	// Update is called once per frame
	void Update () {
		UISprite playerRankPic = this.gameObject.GetComponent<UISprite>();
		playerRankPic.spriteName = rankPic[grGlobals.m_playerRank];
	}
}
