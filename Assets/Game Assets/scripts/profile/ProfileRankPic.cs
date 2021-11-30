using UnityEngine;
using System.Collections;

public class ProfileRankPic : MonoBehaviour {
	private MainMenu grGlobals;
	// Use this for initialization
	private string[] rankPic = new string[13] { "RankMidshipman", "RankEnsign", "RankLtJR", "RankLt", "RankLtCommander", "RankCommander", "RankCaptain", "RankCommodore", "RankViceAdmiral", "RankRearAdmiral", "RankAdmiral", "RankAdmiral", "RankFleetAdmiral" };
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
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
