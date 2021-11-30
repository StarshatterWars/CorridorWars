using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;

public class ProfileScreen : MonoBehaviour {
	public GameObject[] medalScreen;	
	public GameObject GameCenterSubPanel;
	public GameObject profileShipPrefab;
	private GameObject ProfileShip;
	
	//Game Center Setup
	private List<GameCenterLeaderboard> leaderboards;
	private List<GameCenterAchievementMetadata> achievementMetadata;
	private List<GameCenterAchievement> achievement;
	public float[] gc_Achievement = new float[10];
	public int[] gc_medalAwarded;
	public bool gc_loggedIn = false;
	
	//Ship Stuff
	public int s_shipClass = 0;
	public string s_shipClassName = null;
	public string s_shipClassType = null;
	
	//Player Stuff
	public int m_playerSex;
	public int m_playerRank;
	
	// Mission Parameters
	public float m_missionLength = 0f;
	public float m_missionPercent;
	public float m_playerRankComplete; 
	public int m_distanceRunBest = 0;	
	public int m_playerTotalParts = 0;
	public int m_playerTotalKills = 0;
	public int m_playerTotalDist = 0;
	public int m_playerMissions = 0;
	public int m_playerKills = 0;
	public float m_playerTimeBest = 0.0f;
	
	public string m_displayName = string.Empty;
	public string m_displayRank = string.Empty;
	public string m_dispSector = string.Empty;
	public int d_rankDisplay = 0;
	
	// Sound Setup
	public float m_soundVolume = 1.0f;
	public float m_musicVolume = 1.0f;
	
	//Input
	public int i_inputType = 0; 
	public float i_sensitivity = 0.5f;
	
	//Medal Types
	public string[] medalPicType = new string[8] { "InactiveRookie", "InactiveSenior", "InactiveVeteran", "InactiveElite", "MedalRookie", "MedalSenior", "MedalVeteran", "MedalElite" };
	
	//Colors
	public Color m_dbColorGood = Color.green;
	
	void Awake()
	{
		d_rankDisplay = 1;
		gc_medalAwarded = new int[10];
	}
	
	// Use this for initialization
	void Start () 
	{
		InitialzeGameCenter();
		LoadProfileShip();
		LoadPlayerPrefs();
		OnSetScreen(0);
	}
	
	// Update is called once per frame
	void Update () {

		GameCenterSubPanel.SetActive(GameCenterBinding.isPlayerAuthenticated());
	}
	
	private void LoadPlayerPrefs()
	{
		GetPlayerAchievements();
		CalculateMissionUpgrade();
		s_shipClass = PlayerPrefs.GetInt("PlayerClass", 0);
		m_dispSector = PlayerPrefs.GetString("PlayerSector", "Antares");
		m_playerSex = PlayerPrefs.GetInt("PlayerSex", 0);	
		m_playerRankComplete = PlayerPrefs.GetFloat ("MissionPercent", 0.0f);
		m_playerTotalParts = PlayerPrefs.GetInt("PlayerCoins", 0);	
		m_playerRank = PlayerPrefs.GetInt("PlayerRankType", 0);	
		m_playerKills = PlayerPrefs.GetInt("PlayerKills", 0);	
		m_musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);	
		m_soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
		m_playerTimeBest = PlayerPrefs.GetFloat("BestTime", 1.0f);
		m_distanceRunBest = PlayerPrefs.GetInt("BestDist", 0);
		m_playerTotalDist = PlayerPrefs.GetInt("PlayerDist", 0);
		m_playerMissions = PlayerPrefs.GetInt("PlayerMissions", 0);
		s_shipClassName = PlayerPrefs.GetString("ShipName", "Sentri");
		s_shipClassType = PlayerPrefs.GetString("ShipType", "Fighter");	
		m_displayName = PlayerPrefs.GetString("PlayerName", "Redshirt");
		m_displayRank = PlayerPrefs.GetString("PlayerRank", "Midshipman");
		i_inputType = PlayerPrefs.GetInt("InputType", 0);
		i_sensitivity  = PlayerPrefs.GetFloat("InputSensitivity", 0.50f);
		gc_Achievement[0] = PlayerPrefs.GetFloat("BigSpender", 0);
		m_missionLength = (m_playerRank + 1) * 200.0f  + (m_playerRankComplete * (m_playerRank + 1) * 2.0f);
	}
	
	public void OnSetScreen(int medalType)
	{
		for (int i = 0; i <=3; i++)
		{
			medalScreen[i].SetActive(false);
		}
		medalScreen[medalType].SetActive(true);
	}
	
	public void OnSetRookie()
	{
		d_rankDisplay = 1;
		OnSetScreen(0);
	}
	
	public void OnSetSenior()
	{
		d_rankDisplay = 2;
		OnSetScreen (1);
	}
	
	public void OnSetVeteran()
	{
		d_rankDisplay = 3;
		OnSetScreen (2);
	}
	
	public void OnSetElite()
	{
		d_rankDisplay = 4;
		OnSetScreen (3);
	}
	
		
	private void GetPlayerAchievements()
	{
		string medalName = string.Empty;
		
		for (int i = 0; i <=9; i++)
		{	
			medalName = "Medal" + i.ToString();
			gc_medalAwarded[i] = PlayerPrefs.GetInt(medalName , 0);
		}
	}
	
	public void LoadProfileShip()
	{
		ProfileShip = (GameObject)Instantiate(profileShipPrefab, new Vector3(0.50f, -0.40f, 2.0f), Quaternion.identity);
		ProfileShip.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);
		ProfileShip.name = "ProfileShip";
	}
	
	public void UnloadProfileShip()
	{
		Destroy(ProfileShip);
	}
	
		
	private void MenuRotate()
	{
		if(ProfileShip != null)
		{
			ProfileShip.transform.Rotate(0, Time.deltaTime * 30.0f, 0);
		}
	}
	#region //Game Center
	
	private void  GameCenterLoginPlayer ()
	{
		GameCenterBinding.authenticateLocalPlayer();
	}
	
	private void GameCenterGetAchievements()
	{
		GameCenterBinding.getAchievements();	
	}
	
	private void InitialzeGameCenter()
	{
		if(GameCenterBinding.isGameCenterAvailable())
		{
			// Initialize GameCenter
			GameCenterBinding.authenticateLocalPlayer();
			GameCenterGetData();
		}
	}
	
	public void GameCenterGetData()
	{
		if (GameCenterBinding.isPlayerAuthenticated()) 
		{
			GameCenterManager.categoriesLoaded += delegate( List<GameCenterLeaderboard> leaderboards )
			{
				this.leaderboards = leaderboards;
			};
			
			GameCenterManager.achievementMetadataLoaded += delegate( List<GameCenterAchievementMetadata> achievementMetadata )
			{
				this.achievementMetadata = achievementMetadata;
			};
			
			GameCenterManager.achievementsLoaded += delegate( List<GameCenterAchievement> achievement )
			{
				this.achievement = achievement;
			};
		}
	}
	
	public void GCResetAchievements()
	{
		GameCenterBinding.resetAchievements();	
	}
	
	private void CalculateMissionUpgrade()
	{
		m_missionPercent = Mathf.Pow(2, -m_playerRank) * 10.0f; 
	}
		
	public void OnGCAchievements()
	{
		if (GameCenterBinding.isPlayerAuthenticated()) 
		{
			GameCenterManager.achievementMetadataLoaded += delegate( List<GameCenterAchievementMetadata> achievementMetadata )
			{
				this.achievementMetadata = achievementMetadata;
			};
				
			GameCenterManager.achievementsLoaded += delegate( List<GameCenterAchievement> achievement )
			{
				this.achievement = achievement;
			};
			GameCenterBinding.showAchievements();
		}
	}
	
	public void OnGCLeaderboard()
	{
		GameCenterBinding.showLeaderboardWithTimeScopeAndLeaderboard(GameCenterLeaderboardTimeScope.AllTime, "bestDist" );
	}
	
	public void OnGCResetEverything()
	{
		GameCenterBinding.resetAchievements();	
		GameCenterBinding.reportScore(0, "bestDist");
		GameCenterBinding.reportScore(0, "bestTime");
		GameCenterBinding.reportScore(0, "numberMissions");
		GameCenterBinding.reportScore(0, "numParts");
		GameCenterBinding.reportScore(0, "totalDist");
		PlayerPrefs.DeleteAll();
	}
	# endregion
	
	public void UnloadProfileScreen()
	{
		if(GameObject.Find("ProfileScreen")) 
		{
			GameObject PScreenGO = GameObject.Find("ProfileScreen");
			Destroy(PScreenGO);
		}
		
		if(GameObject.Find("ProfileShip")) 
		{
			GameObject PShipGO = GameObject.Find("ProfileShip");
			Destroy(PShipGO);
		}
		
		if(GameObject.Find("TitleGUI")) 
		{
			GameObject titleGUIMM = GameObject.Find("TitleGUI");
			titleGUIMM.transform.localPosition = new Vector3(-120.0f, 280.0f, 0.0f);
		}
		
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			missobjGUIMM.transform.localPosition = new Vector3(100.0f, 160.0f, 0.0f);
		}
		
		if(GameObject.Find("PlayButtonGUI")) 
		{
			GameObject playButton = GameObject.Find("PlayButtonGUI");
			playButton.transform.localPosition = new Vector3(187.5f, -285.0f, 0.0f);
		}
		
		if(GameObject.Find("SettingsButton")) 
		{
			GameObject menuButtonA = GameObject.Find("SettingsButton");
			menuButtonA.transform.localPosition = new Vector3(200.0f, -150.0f, 0.0f);
		}
		
		if(GameObject.Find("AboutButton")) 
		{
			GameObject menuButtonB = GameObject.Find("AboutButton");
			menuButtonB.transform.localPosition = new Vector3(200.0f, 30.0f, 0.0f);
		}
		
		if(GameObject.Find("ProfileButton")) 
		{
			GameObject menuButtonB = GameObject.Find("ProfileButton");
			menuButtonB.transform.localPosition = new Vector3(200.0f, -90.0f, 0.0f);
		}
		
		if(GameObject.Find("HangerButton")) 
		{
			GameObject menuButtonC = GameObject.Find("HangerButton");
			menuButtonC.transform.localPosition = new Vector3(200.0f, -30.0f, 0.0f);
		}
	}
}
