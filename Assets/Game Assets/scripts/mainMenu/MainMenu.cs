using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;

public class MainMenu : MonoBehaviour {

	public GameObject shipPrefab;
	public GameObject planetPrefab;
	private GameObject m_player;
	public GameObject warpEffectPrefab;
	
	private GameObject BaseStation;
	private GameObject BasePlanet;
	private GameObject BaseWaypoint;
	
	public GameObject LoadingMissionPrefab;
	private GameObject LoadingMissionGUI;
	
	private GameObject P31GameManager;
	private GameObject P31EventHandler;
	
	public GameObject P31Manager;
	public GameObject P31EventListener;
	
	private GameObject MenuGUI;
	public GameObject MenuGUIPrefab;
	
	private GameObject AboutGUI;
	public GameObject AboutGUIPrefab;
	
	private GameObject SettingsGUI;
	public GameObject SettingsGUIPrefab;
	
	private GameObject ProfileScreen;
	public GameObject ProfileGUIPrefab;
	
	private GameObject HangerGUI;
	public GameObject HangerGUIPrefab;
	
	// Alert Colors
	public Color m_dbColorNormal = Color.cyan;
	public Color m_dbColorFail = Color.red;
	public Color m_dbColorTextFail = new Color(1.0f, 0.5f, 0.0f, 1.0f);
	public Color m_dbColorTextPass = new Color(0.0f, 0.75f, 0.75f, 1.0f);
	public Color m_dbColorOK = Color.yellow;
	public Color m_dbColorGood = Color.green;
	public Color m_missionTextColor = Color.cyan; 
	public Color m_missionTitleColor = Color.cyan; 
	public Color m_mBriefTitleColor = Color.green; 
	public Color m_mBriefTextColor = Color.cyan; 
	
	//MainMenu
	public GameObject stationPrefab;
	public GameObject waypointPrefab;
	
	//Player Setup
	public bool m_playerLoggedIn = false;
	public bool m_isConnectedtoInternet = false;
	public int m_playerRank;
	public float m_cameraPosition = 0.0f;
	
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

	
	// Menu Stuff
	public string m_displayName = string.Empty;
	public string m_displayRank = string.Empty;
	public string m_dispSector = string.Empty;
	public string m_missionText = string.Empty; 
	public string m_missionTitle = string.Empty;
	public string m_missionFail = string.Empty; 
	public string m_missionPass = string.Empty; 
	public string m_mBriefTitle = string.Empty;
	public string m_mBriefText = string.Empty;
	
	public bool aboutScreenActive = false;
	public bool settingsScreenActive = false;
	public bool profileScreenActive = false;
	public bool hangerScreenActive = false;
	
	public bool aboutScreenActivate = false;
	public bool settingsScreenActivate = false;
	public bool profileScreenActivate = false;
	public bool hangerScreenActivate = false;
	
	public bool killAboutScreen = false;
	public bool killProfileScreen = false;
	public bool killSettingsScreen = false;
	public bool killHangerScreen = false;
	
	public bool reanimateMenu = false;
	public bool reanimateMissionObj = false;
	
	//Ship Stuff
	public int s_shipClass = 0;
	public string s_shipClassName = null;
	public string s_shipClassType = null;
	
	public bool m_playGame = false;	

	void Awake()
	{
		reanimateMenu = true;
		reanimateMissionObj = true;
	}
	
	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		GameManager();
		ResetCamera();
		LoadPlayerPrefs();
		MakeScreen ();
		
		// Plugin Initialize 	
		InitialzeGameCenter();
	}
	
	private void MakeScreen()
	{
		BasePlanet = (GameObject)Instantiate(planetPrefab, new Vector3(30.0f, 30.0f, -120.0f), Quaternion.identity);
		BasePlanet.transform.localScale = new Vector3(2000.0f, 2000.0f, 2000.0f);
		BasePlanet.name = "Planet";
		BaseStation = (GameObject)Instantiate(stationPrefab, new Vector3(10.0f, 20.0f, -70.0f), Quaternion.identity);
		BaseStation.name = "Station";
		BaseStation.transform.localScale = new Vector3(0.60f, 0.60f, 0.60f);
		BaseWaypoint = (GameObject)Instantiate(waypointPrefab, new Vector3(-40.0f, 20.0f, -20.0f), Quaternion.identity);
		BaseWaypoint.name = "Waypoint1";
	}
	
	// Update is called once per frame
	void Update () {
		
		CheckNetworkConnection();
		
		if(GameCenterBinding.isPlayerAuthenticated())
		{
			m_playerLoggedIn = true;
	       	m_displayName = GameCenterBinding.playerAlias();
			PlayerPrefs.SetString("PlayerName", m_displayName);
			
			m_mBriefTitle = "Mission Briefing - \n" + m_dispSector + " sector";
			m_mBriefTextColor = m_dbColorGood;	
			m_mBriefText = "\nWelcome, " + m_displayRank + " " + m_displayName.ToUpperInvariant();
			PlayerPrefs.SetString("PlayerName", m_displayName.ToUpperInvariant());
			m_mBriefTextColor = Color.cyan;	
		}
		
		if(!hangerScreenActive && !settingsScreenActive && !profileScreenActive && !aboutScreenActive)
		{
			if(GameObject.Find("MissionObjectivesGUI")) 
			{
					GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
					missobjGUIMM.transform.localPosition = new Vector3(100.0f, 160.0f, 0.0f);
			}
		}
		
		if(!AboutGUI)
		{
			aboutScreenActive = false;
		}
		
		if(aboutScreenActivate)
		{
			DisplayAboutScreen();
		}
		
		if(settingsScreenActivate)
		{
			HideMainMenu();
			DisplaySettingsScreen();
		}
		
		if(profileScreenActivate)
		{
			HideMainMenu();
			DisplayProfileScreen();
		}
		
		if(hangerScreenActivate)
		{
			HideMainMenu();
			DisplayHangerScreen();
		}
		
		if(killAboutScreen && AboutGUI == null)
		{
			
			killAboutScreen = false;
		}
		
		if(killProfileScreen)
		{
			Destroy(ProfileScreen);
			UnhideMainMenu();
			killProfileScreen = false;
		}
		
		if(killHangerScreen)
		{
			Destroy(HangerGUI);
			UnhideMainMenu();
			killHangerScreen = false;
		}	
		
		if(killSettingsScreen)
		{
			Destroy(SettingsGUI);
			UnhideMainMenu();
			killSettingsScreen = false;
		}	
	}
	
	private void GameManager()
	{
		m_playerLoggedIn = false;
		
		if(!GameObject.Find("P31GameManager")) 
		{
			P31GameManager = (GameObject)Instantiate(P31Manager, Vector3.zero, Quaternion.identity);
			P31GameManager.name = "P31GameManager";
		}
		if(!GameObject.Find("P31EventListener"))
		{
			P31EventHandler = (GameObject)Instantiate(P31EventListener, Vector3.zero, Quaternion.identity);
			P31EventHandler.name = "P31EventListener";
		}
		
		if(!GameObject.Find("MenuGUI"))
		{
			MenuGUI = (GameObject)Instantiate(MenuGUIPrefab, Vector3.zero, Quaternion.identity);
			MenuGUI.name = "MenuGUI";
		}
	}
	
	private void HideMainMenu()
	{
		if(GameObject.Find("TitleGUI")) 
		{
			GameObject titleGUIMM = GameObject.Find("TitleGUI");
			titleGUIMM.transform.localPosition = new Vector3(0.0f, 0.0f, -600.0f);
		}
		
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			missobjGUIMM.transform.localPosition = new Vector3(0.0f, 0.0f, -600.0f);
		}
		
		if(GameObject.Find("PlayButtonGUI")) 
		{
			GameObject playButton = GameObject.Find("PlayButtonGUI");
			playButton.transform.localPosition = new Vector3(0.0f, 0.0f, -600.0f);
		}
		
		if(GameObject.Find("SettingsButton")) 
		{
			GameObject menuButtonA = GameObject.Find("SettingsButton");
			menuButtonA.transform.localPosition = new Vector3(200.0f, -150.0f, -600.0f);
		}
		
		if(GameObject.Find("AboutButton")) 
		{
			GameObject menuButtonB = GameObject.Find("AboutButton");
			menuButtonB.transform.localPosition = new Vector3(200.0f, 30.0f, -600.0f);
		}
		
		if(GameObject.Find("ProfileButton")) 
		{
			GameObject menuButtonB = GameObject.Find("ProfileButton");
			menuButtonB.transform.localPosition = new Vector3(200.0f, -90.0f, -600.0f);
		}
		
		if(GameObject.Find("HangerButton")) 
		{
			GameObject menuButtonC = GameObject.Find("HangerButton");
			menuButtonC.transform.localPosition = new Vector3(200.0f, -30.0f, -600.0f);
		}
	}
	
	private void UnhideMainMenu()
	{
		if(GameObject.Find("TitleGUI")) 
		{
			GameObject titleGUIMM = GameObject.Find("TitleGUI");
			titleGUIMM.transform.localPosition = new Vector3(0.0f, 0.0f, 650.0f);
		}
		
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			missobjGUIMM.transform.localPosition = new Vector3(0.0f, 0.0f, 650.0f);
		}
		
		if(GameObject.Find("PlayButtonGUI")) 
		{
			GameObject playButton = GameObject.Find("PlayButtonGUI");
			playButton.transform.localPosition = new Vector3(0.0f, 0.0f, 650.0f);
		}
	}
	
	public void DisplayLoadingMissionScreen()
	{
		LoadingMissionGUI = (GameObject)Instantiate(LoadingMissionPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
		LoadingMissionGUI.name = "LoadingMissionScreen";
	}
	
	public void CreateAboutScreen()
	{
		aboutScreenActivate = true;
	}
	
	public void CreateSettingsScreen()
	{
		settingsScreenActivate = true;
	}
	
	public void CreateProfileScreen()
	{
		profileScreenActivate = true;
	}
	
	public void CreateHangerScreen()
	{
		hangerScreenActivate = true;
	}
	
	private void DisplayAboutScreen()
	{
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			missobjGUIMM.transform.localPosition = new Vector3(0.0f, 0.0f, -600.0f);
		}
		
		AboutGUI = (GameObject)Instantiate(AboutGUIPrefab, Vector3.zero, Quaternion.identity);
		AboutGUI.name = "AboutScreen";
		aboutScreenActivate = false;
		aboutScreenActive = true;
		hangerScreenActive = false;
		settingsScreenActive = false;
		profileScreenActive = false;
		killAboutScreen = true;
		Destroy(AboutGUI, 18);
	}
	
	private void DisplaySettingsScreen()
	{
		settingsScreenActive = true;
		UnloadAboutScreen();
		SettingsGUI = (GameObject)Instantiate(SettingsGUIPrefab, Vector3.zero, Quaternion.identity);
		SettingsGUI.name = "SettingsScreen";
		settingsScreenActivate = false;
		hangerScreenActive = false;
		profileScreenActive = false;
	}
		
	private void DisplayProfileScreen()
	{
		profileScreenActive = true;
		UnloadAboutScreen();
		ProfileScreen = (GameObject)Instantiate(ProfileGUIPrefab, Vector3.zero, Quaternion.identity);
		ProfileScreen.name = "ProfileScreen";
		profileScreenActivate = false;
		hangerScreenActive = false;
		settingsScreenActive = false;
	}
	
	private void DisplayHangerScreen()
	{
		hangerScreenActive = true;
		UnloadAboutScreen();
		HangerGUI = (GameObject)Instantiate(HangerGUIPrefab, Vector3.zero, Quaternion.identity);
		HangerGUI.name = "HangerScreen";
		hangerScreenActivate = false;
		settingsScreenActive = false;
		profileScreenActive = false;
	}
		
	private void UnloadAboutScreen()
	{
		if(aboutScreenActive) 
		{
			if(GameObject.Find("AboutScreen")) 
			{
				GameObject AScreenGO = GameObject.Find("AboutScreen");
				Destroy(AScreenGO);
			}
			aboutScreenActive = false;
		}
	}
	
	public void UnloadSubscreens()
	{
		UnloadAboutScreen();
		
		if(profileScreenActive) 
		{
			profileScreenActive = false;
			if(GameObject.Find("ProfileScreen")) 
			{
				GameObject PScreenGO = GameObject.Find("ProfileScreen");
				Destroy(PScreenGO);
				GameObject PShipGO = GameObject.Find("ProfileShip");
				Destroy(PShipGO);
			}
		}
		else if(settingsScreenActive)
		{
			settingsScreenActive = false;
			if(GameObject.Find("SettingsScreen")) 
			{
				GameObject SScreenGO = GameObject.Find("SettingsScreen");
				Destroy(SScreenGO);
			}
		}
		
		else if(hangerScreenActive)
		{
			hangerScreenActive = false;
			if(GameObject.Find("HangerScreen")) 
			{
				GameObject HScreenGO = GameObject.Find("HangerScreen");
				Destroy(HScreenGO);
			}
		}
	}
	
	private void LoadPlayerPrefs()
	{
		s_shipClass = PlayerPrefs.GetInt("PlayerClass", 0);
		m_dispSector = PlayerPrefs.GetString("PlayerSector", "Antares");
		m_playerRankComplete = PlayerPrefs.GetFloat ("MissionPercent", 0.0f);
		m_playerTotalParts = PlayerPrefs.GetInt("PlayerCoins", 0);	
		m_playerRank = PlayerPrefs.GetInt("PlayerRankType", 0);	
		m_playerKills = PlayerPrefs.GetInt("PlayerKills", 0);	
		m_playerTimeBest = PlayerPrefs.GetFloat("BestTime", 1.0f);
		m_distanceRunBest = PlayerPrefs.GetInt("BestDist", 0);
		m_playerTotalDist = PlayerPrefs.GetInt("PlayerDist", 0);
		m_playerMissions = PlayerPrefs.GetInt("PlayerMissions", 0);
		s_shipClassName = PlayerPrefs.GetString("ShipName", "Sentri");
		s_shipClassType = PlayerPrefs.GetString("ShipType", "Fighter");	
		m_displayName = PlayerPrefs.GetString("PlayerName", "Redshirt");
		m_displayRank = PlayerPrefs.GetString("PlayerRank", "Midshipman");
		m_missionLength = (m_playerRank + 1) * 200.0f  + (m_playerRankComplete * (m_playerRank + 1) * 2.0f);
	}
	
	private void CheckNetworkConnection()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
   		{
        	m_isConnectedtoInternet = false;
   		}
		else
		{
			m_isConnectedtoInternet = true;
		}
	}

	public void ResetCamera()
	{
		Camera.main.transform.position = new Vector3(0.0f, 1.0f, -10.0f);
		Camera.main.transform.rotation =  Quaternion.Euler(340, 180, 0);
	}
	
	private void InitialzeGameCenter()
	{
		if(GameCenterBinding.isGameCenterAvailable())
		{
			// Initialize GameCenter
			GameCenterBinding.authenticateLocalPlayer();
		}
	}
}


