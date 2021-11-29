using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using System.Text;
using Prime31;
using PathologicalGames;

//using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class csRangerWars: MonoBehaviour 
{
	#region Enums

		// Determines direction of cells (track pieces) and the player
		public enum enCellDir
		{
			North,
			East,
			West,
			South,
			NorthSouth,
			EastWest,
			Up,
			Down,	
			UpDown,
		};
		
		// Determines the type of cell (track piece)
		public enum enCellType
		{
			StandardTrack,
			JumpGap,	
			JumpObstacle,
			DuckObstacle,
			NarrowObstacle,
			NarrowLow,
			NarrowHigh,
			LedgeLeft,
			LedgeRight,
			TurnTrackL,
			TurnTrackR,
		};
		
		public enum enCellClass
		{	
			SingleTrack,
			DoubleTrack,
			CrossoverTrack,
			WyeInTrack,
			WyeOutTrack,
			OpenTrack,
			TurnTrackL,
			TurnTrackR,
			TurnTrackU,
			TurnTrackD,
			StationEntrance,
			FighterBay,
			SingleDoor,
			DoubleDoor,
		};
		
		public enum enCellSize
		{
			Single,
			Double,
		};
	
		public enum pwrType
		{
			Energy,
			Life,
			Parts,
		};
	
	#endregion

	#region Cell Data
	
		// Class to hold information about an individual cell (piece)
		public class stCell
		{
			// Basic cell information
			public Vector3      CellPosition;		
			public enCellDir    CellDirection;
			public enCellType   CellType;
		    public enCellSize   CellSize;
			public enCellClass  CellClass;
			public GameObject   CellModel;
			
			// Indices of neighbouring cells
			public stCell NeighbourN;
			public stCell NeighbourNW;
			public stCell NeighbourW;
			public stCell NeighbourSW;
			public stCell NeighbourS;
			public stCell NeighbourSE;
			public stCell NeighbourE;
			public stCell NeighbourNE;
			
			public stCell NeighbourU;
			public stCell NeighbourD;
		
			// Collectable Coins
			public List<GameObject> m_coins = new List<GameObject>();
		
			// Energy Mines
			public List<GameObject> m_EnergyMine = new List<GameObject>();
		
			// Energy Walls 
			public List<GameObject> m_EnergyWall = new List<GameObject>();
		
			// Has the player visited this cell?  
			// This is used to remove old cells
			public bool Visited = false;		
			
		
			// CTOR
			public stCell
				(Vector3    cellPosition,
				 enCellDir  cellDirection,
				 enCellType cellType,
				 enCellSize cellSize,
				 enCellClass cellClass
				)
			{
				this.CellPosition  = cellPosition;
				this.CellDirection = cellDirection;
				this.CellType 	= cellType;
			    this.CellSize 	= cellSize;
			 	this.CellClass 	= cellClass;
				
				this.NeighbourN = null;
				this.NeighbourNW = null;
				this.NeighbourW = null;
				this.NeighbourSW = null;
				this.NeighbourS = null;
				this.NeighbourSE = null;
				this.NeighbourE = null;
				this.NeighbourNE = null;
				this.NeighbourU = null;
				this.NeighbourD = null;
			}
		}	
		
	#endregion
	
	#region Public Members
	
		// These are the prefabs used by the system.
		
		// Game Center Integration
		private List<GameCenterLeaderboard> leaderboards;
		private List<GameCenterAchievementMetadata> achievementMetadata;
		private List<GameCenterAchievement> achievement;
	
		public GameObject m_damagePrefab;
		public GameObject m_playerPrefab;
	
		public GameObject m_SingleOpen; 
		public GameObject m_SingleEntrance;
		public GameObject m_FighterBay;
	
		public GameObject[] m_SingleTrack; // basic tracks
		public GameObject[] m_DoubleTrack;
	
	    public GameObject m_SplitTrack;
	    public GameObject m_SplitTrackRev;
		public GameObject m_CrossoverTrack;
	
		public GameObject[] m_SingleJump;
		public GameObject[] m_DoubleJump;
	
		public GameObject[] m_SingleDuck;
		public GameObject[] m_DoubleDuck;
	
		public GameObject m_SingleHalfBroken;
		public GameObject m_DoubleHalfBroken;
		
		public GameObject m_SingleNarrow;
		public GameObject m_DoubleNarrow;
	
		public GameObject m_SingleNarrowLow;
		public GameObject m_DoubleNarrowLow;
	
		public GameObject m_SingleNarrowHigh;
		public GameObject m_DoubleNarrowHigh;
	
		public GameObject m_SingleLHTrack;
		public GameObject m_DoubleLHTrack;
		
		public GameObject m_SingleLVTrack;
		public GameObject m_DoubleLVTrack;
	
		public GameObject m_SingleTTrack;
		public GameObject m_DoubleTTrack;
	
		public GameObject m_SingleObstacleDuck;
		public GameObject m_DoubleObstacleDuck;
	
		public GameObject m_Single_ObstacleJump;
		public GameObject m_Double_ObstacleJump;

		public GameObject m_EnergyMine;
		public GameObject m_ShieldWall;
		public GameObject m_Explosion;
		public GameObject ExplosionPrefab;
		private GameObject CorridorPrefab = null;
		
		public GameObject PowerupPrefab = null;
		public GameObject InGameGUIPrefab = null;
		public GameObject VCListenerPrefab = null;

		public int displaySpeed;
		public int displayDist;
		public int displayCoins;

		// IngameGUI	
	
		public GameObject InGameGIUPrefab;
		private GameObject InGameGIU;
		
		public GameObject MissionHintsPrefab;
		private GameObject MissionHintsGUI;
	
		public GameObject NextLevelButtonPrefab;
		private GameObject NextLevelButton;
	
		public GameObject ExitButtonPrefab;
		private GameObject ExitButton;
		
		public GameObject RetryButtonPrefab;
		private GameObject RetryButton;
	
		public GameObject MissionReportPrefab;
		private GameObject MissionReport;
	
		public GameObject JoystickPrefab;
		private GameObject Joystick;
		
		public GameObject FireButtonPrefab;
		private GameObject FireButton;
	
		public GameObject MissileButtonPrefab;
		private GameObject MissileButton;
	
		public GameObject SpeedControlPrefab;
		private GameObject SpeedControl;
	
		//InGameGUI
		private GameObject VCListener;
		private GameObject InGameGUI;
	
		public AudioSource gameMusic; 
		public AudioSource gameSounds; 
		public Color ambientLight; 
		public Material cave;
		public Material outside;
		public int m_playerSex;
		public string strDirection = string.Empty;
	
		// Matrix Stuff
		public Vector3 tempRotation = Vector3.zero;
		public Vector3 tempPosition = Vector3.zero;	
		public Matrix4x4 calibrationMatrix;
	
		// GameCenter Setup
		public float[] gc_Achievement = new float[10];
	
	#endregion

	#region Private Members
	
		// Instantiated player
		private GameObject m_player;

		// The cells (track pieces)
		private List<stCell> m_cells = new List<stCell>();	
		
		// which cell is the player currently in?
		private stCell m_playerCell = null;
		
		// "loop" timer, used to move a player across a cell
		private float m_playerTimer = 0.0f;
	    
		// Player swipe
		private float m_playerDir = 0.0f;
		
		// current direction of travel
		private enCellDir m_playerDirection = enCellDir.North;
		
		// next direction of travel (from input)
		private enCellDir m_playerNextDirection = enCellDir.North;
		
		// direction of previous cell
		private enCellDir m_previousCellDirection = enCellDir.North;
	
		// current trackside
		private enCellClass m_playerClass = enCellClass.SingleTrack;
	
		// Corridor Information 
		private int m_maxCells = 4;
		private float m_lastTurnHDir = -0.5f; 		// used to make track turn left and then right alternately
		private float m_lastTurnVDir = -0.5f; 	    // used to make track turn up and then down alternately
		private float m_cellSpacing = 6.0f;    		// track scaling / spacing
		private float m_tileBaseHeight = -0.2f;  	// modifier applied to Y axis when placing cells
		private float m_powerupHeight = 0.85f; 	 	// Height at which to place coins
		private float m_powerupRandomHeight = 0.0f;
		private float m_playerBaseHeight = 0.85f; 	// modifier applied to Y axis when updating the player position
		private float m_shieldDamageAmount = 0.25f;	
		private float m_wallDamage = 0.05f;
		private int m_trackObstacleCount = 0;
		private int m_trackDoorCount = 0;
		private int m_trackTurnCount = 0;
		public bool m_narrowCorridor = false;

		private float m_showMissionPopupTime;
		private float m_maxTilt = 1.0f;
		private float m_maxHeight = 0.10f;
		private float m_minActionDist = 0.05f;
		private float m_maxActionDist = 0.95f;
	
		public int m_displayDirection = 0;
		public float m_displayBank = 0.0f;
		public float m_displayPitch = 0.0f;
		public float m_displayTilt = 0.0f;
		public float m_cameraPosition = 0.0f;
	
		private Vector3 m_maxOffset = new Vector3(0.5f, 0.5f, 0.5f);
		private Vector3 m_maxOffsetWide = new Vector3(0.70f, 0.5f, 0.7f);
		private Vector3 m_maxOffsetWall;
		private float m_turnObstacleDist = 100;
	
		private Vector3 m_cellOffset = Vector3.zero;
	
		// Used to strafe the player from one side of the track to the other.
		// On a phone, this would be the tilt of the phone.
		public float m_tilt = 0.0f;	
		public float m_pitch = 0.0f;	
		public float m_height = 0.0f;	
		private float m_rotHeight = 0.0f;
		private float m_rotPitch = 0.0f;
		private float m_tiltOK = 0.20f;
		private float m_HeightOK = 0.25f;
		public float m_engineMultiplier = 1.0f;
		public bool m_speedChange = false;
		public int m_missileType = 0;
		public int m_shieldType = 0;
		public int m_cargoType = 0;
		public int m_gunType = 0;
	
		public bool m_onContinueGame = false;
		public bool m_onExitGame = false;
		public bool m_onRetryGame = false;
	
		// Sets current number of rails
		private int m_nrRails = 7;
	
		// LTile track
		private GameObject m_LHTile; 
		private GameObject m_LVTile; 
		private GameObject m_THTile;
		private GameObject m_TVTile;
	
		// Coins
		private int m_powerUpType = 0; // 0 = energy, 1 = item, 2 = life 
		public GameObject[] m_powerUp;
	
		private float m_cornerSlowdown = 0.01f;
		public bool m_inCave = false;

		public bool m_missionEnd = false;
		public bool m_targetLocked = false;
		
		public Vector3 m_rotation = Vector3.zero;
		private Quaternion m_originalRotation;
		public Vector3 dispRotation = Vector3.zero;	
		
		// Mission Parameters
		public float m_missionLength = 0f;
		public bool m_playerMissionPass;
	
		// Player Movement
		private bool m_swipeLeft = false;
		private bool m_swipeRight = false;
		private	bool m_playerMoveLeft = false;
		private bool m_playerMoveRight = false;
		public bool m_playerMadeTurn = false;
		public bool m_activateShield = false;
	
		// High Scores
		public float m_playerTimeBest = 0.0f;
		public float m_playerTime = 0.0f;
		private float m_playerStartTime = 0.0f;
		public int m_playerMissions = 0;
		public int m_playerTotalKills = 0;
		public int m_playerKills = 0;
		public int m_playerTotalDist = 0;
	
		public int[] m_medalAwarded;
		
		public int m_distanceRun = 0;  	// How far have we travelled for players benefit)
		public int m_distanceRunBest = 0;	// What was our best run distance? 
		
		// Menu Stuff
		public string m_displayName = string.Empty;
		public string m_displayRank = string.Empty;
		public string m_dispSector = string.Empty;
		public string m_missionText = string.Empty; 
		public string m_missionTitle = string.Empty;
		public string m_missionFail = string.Empty; 
		public string m_missionPass = string.Empty; 
		
		public Color m_missionTextColor = Color.cyan; 
		public Color m_missionTitleColor = Color.cyan; 
	
		public bool m_missionReportSet;
		public string m_missionObj1 = string.Empty;
		public string m_missionObj2 = string.Empty;
		public string m_missionObj3 = string.Empty;
		public int m_medalLevel = 0;
	
		// Alert Colors
		public Color m_dbColorNormal = Color.cyan;
		public Color m_dbColorFail = Color.red;
		private Color m_dbColorTextFail = new Color(1.0f, 0.5f, 0.0f, 1.0f);
		private Color m_dbColorTextPass = new Color(0.0f, 0.75f, 0.75f, 1.0f);
		public Color m_dbColorOK = Color.yellow;
		public Color m_dbColorGood = Color.green;
	
		// Fighter Set-up
		public int s_shipClass = 0;
		public float s_primaryShield; 
		public float s_fwdShield;
		public float s_aftShield;
		public float s_prtShield;
		public float s_stbShield; 
		public float s_energy = 100.0f;
		public string s_shipClassName = null;
		public string s_shipClassType = null;
		public float s_energyAvailable = 1.0f;
	
		// Sound Setup
		public float m_soundVolume = 1.0f;
		public float m_musicVolume = 1.0f;
	
		// Crosshair
		public Color m_xhColorNormal = Color.cyan;
		public Color m_xhColorEnemy = Color.red;
		public Color m_xhColorAllied = Color.green;
		public Color m_xhColorNeutral = Color.yellow;
		
		// Animate Doors
		public bool m_animateDoors = false;
		public bool m_animateStationDoors = false;
		public bool m_animateBay = false;
	
		// Ipad stuff
		public float i_sensitivity = 0.5f;
		private float i_deadZone = 0.05f;
		private Vector3 i_inputAccelTilt = Vector3.zero;
		private Vector3 i_inputAcceleration = Vector3.zero;
		public float i_maxAngle = 0.5f;
		public int i_inputType = 0; 			
		public bool i_landscapeMode = false;
	
		// Powerups
		public int m_partsCollected = 0;
		public string[] m_coinsCollectedName = new string[3];
		public int m_playerTotalParts = 0;
	
		// Player Setup
		private float m_playerVelocityStart = 0.50f; // How fast is the player moving when game starts	
		public float  m_playerVelocity = 0.5f; // How fast is the player actually moving
		private float m_playerMinSpeed = 0.000f;
		private float m_playerMaxSpeed = 2.0f;
		private float m_playerSpeedInc = 0.0025f;
		private float m_playerMoveSpeed = 0.25f;
		public bool m_playerLoggedIn = false;
		public int m_playerRank;
		public float m_missionPercent;
		public float m_playerRankComplete; 
		private Vector3 m_playerOffset = Vector3.zero;
		public float m_playerSetSpeed = 0.5f;
		public int m_playerDecal = 0;
	
		public string[] m_rankName = new string[13] { "Midshipman", "Ensign", "Lieutenant, JG", "Lieutenant", "LT Commanader", "Commander", "Captain", "Commmodore", "Rear Admiral", "Vice Admiral", "Admiral", "Sector Admiral", "Admiral of the Fleet" };
	
		// Player Weapons
		public bool m_playerLaserFire = false;
		public bool m_playerMissileFire = false;
		public int s_shipMissileCount = 12; 
		public bool debugMode = false;
		public bool demoMode = false;
	
	#endregion

	#region Audio Clips
	
		public AudioClip m_splatAudio;
		public AudioClip m_fallAudio;		
		public AudioClip m_turnAudio;
		public AudioClip m_jumpAudio;
		public AudioClip m_chingAudio;
		public AudioClip m_explodeAudio;
		public AudioClip m_ambientSound;
		public AudioClip m_ambientMusic;
		public AudioClip m_fireButtonSound;
		public AudioClip m_missionSuccessAudio; 

	#endregion		

	#region Core Functions
	
	void Awake()
	{
		m_medalAwarded = new int[10];
		CreateJoystick();
	}
	
	void Start () 
	{			
		Application.runInBackground = true;
		CreateInGameGUI();
		RenderSettings.skybox = outside;
		RenderSettings.ambientLight = new Color(0.50f, 0.50f, 0.50f, 1.0f);
		LoadPlayerPrefs();
		InitializeGame();
		//GameManager();
		GetMissionObjectives();

		if(GameObject.Find("warpfield")) 
		{
			GameObject warpfield = GameObject.Find("warpfield");
			Destroy(warpfield);
		}
		
		if(GameObject.Find("1")) 
		{
			GameObject transPlayer = GameObject.Find("1");
			Destroy (transPlayer);
		}
		
		if(GameObject.Find("LoadingMissionScreen")) 
		{
			GameObject transMission = GameObject.Find("LoadingMissionScreen");
			Destroy (transMission);
		}
	}	
	
	void Update () 
	{	
		PlayMusic();
		UpdatePlayer();
		DisplayMissionPopupScreen();
		
		if(!Application.genuine)
		{
			
		}
		
		if (!m_missionEnd)
		{
			// Make the camera follow the player (if active)
			csSmoothFollow sF = (csSmoothFollow)Camera.main.GetComponent(typeof(csSmoothFollow));
			sF.target = m_player.transform;			
			
			// Check for collisions with interactive objects
			UpdateCoins();
			UpdateEnergyMines();
			
			// Dynamically update the track
			CreateNewCellsIfNeeded(false);
		}
		else
		{
			OnMissionEnd();
		}
		
		if(m_onContinueGame)
		{
			OnPlayerContinue();	
		}
		
		if(m_onExitGame)
		{
			OnPlayerRestart();	
		}
		
		
		if(m_onRetryGame)
		{
			OnPlayerRetry();	
		}
	}
				
	private void SetEndMissionParameters(bool success, string message)
	{
		if(!m_missionReportSet)
		{
			m_missionReportSet = true;		
			m_playerMissionPass = success;
			m_missionEnd = true;
			
			if(success)
			{
				m_playerMissions++;
				m_playerRankComplete += m_missionPercent;
				
				if(m_playerRankComplete >= 100.00f)
				{
					message = "You have completed the mission objectives and have been promoted to the rank of " + m_rankName[m_playerRank + 1];
					GameCenterReportAchievement(m_playerRank + 1, m_playerRankComplete);
					m_playerRankComplete = 0.0f;
					m_playerRank += 1;
					if(m_playerRank >= 12) m_playerRank = 12;	
					PlayerPrefs.SetInt("PlayerRankType", m_playerRank);
					PlayerPrefs.SetString("PlayerRank", m_rankName[m_playerRank]);
				}
				else
				{	
					if(m_playerRank <= 11)  
					{
						message = "You have completed the mission objectives and " + m_playerRankComplete.ToString() + "% toward the next rank of " + m_rankName[m_playerRank + 1];
					}
					else
					{
						message = "You have completed the mission objectives\nYou are already " + m_rankName[12];
					}
					GameCenterReportAchievement(m_playerRank + 1, m_playerRankComplete);
				}	
				
				PlayerPrefs.SetInt("PlayerMissions", m_playerMissions);
				PlayerPrefs.SetFloat ("MissionPercent", m_playerRankComplete);
					
				if(m_playerTime < m_playerTimeBest)
				{
					PlayerPrefs.SetInt("BestTime", Mathf.RoundToInt(m_playerTimeBest));
				}
				
				m_missionTitle = "\nMission Passed";
				m_missionTitleColor =  m_dbColorGood;
				m_missionTextColor =  m_dbColorTextPass;
				m_missionText = message;
				//OnFBPostMessage(m_missionText);
				
				AudioSource.PlayClipAtPoint(m_missionSuccessAudio, m_player.transform.position);	
			}
			else
			{
				m_missionTitle = "\nMission Failed";
				m_missionTitleColor = m_dbColorFail;
				m_missionTextColor =  m_dbColorTextFail;
				m_missionText = message;
				OnExplosion(m_explodeAudio); 
			}	
			
			m_playerTotalKills += m_playerKills;
			m_playerTotalParts += m_partsCollected;
			m_playerTotalDist += displayDist;
		}
		
		
		displayDist = Mathf.FloorToInt( m_distanceRun + (m_playerTimer * 10));
		
		if(displayDist > m_distanceRunBest)
		{	
			m_distanceRunBest = displayDist;
			PlayerPrefs.SetInt("BestDist", m_distanceRunBest);
			GameCenterReportScore(1);
		}
		
		PlayerPrefs.SetInt("PlayerDist", m_playerTotalDist);	
		PlayerPrefs.SetInt("PlayerCoins", m_playerTotalParts);
		PlayerPrefs.SetInt("PlayerKills", m_playerTotalKills);
		
		GameCenterReportScore(2);
		GameCenterReportScore(3);
		GameCenterReportScore(4);
		SetPlayerAchievement();
		//if (Debug.isDebugBuild) {
		//	Debug.LogError(message);
		//}
	}
	
	private void GameManager()
	{
		if(GameObject.Find("VCListener")) 
		{
			VCListener = GameObject.Find("VCListener");
			Destroy(VCListener);
			VCListener = (GameObject)Instantiate(VCListenerPrefab, Vector3.zero, Quaternion.identity);
			VCListener.name = "VCListener";
		}
	}
	
	private void SetPlayerAchievement()
	{
		SetMissionAchievement(m_playerMissions);
		SetDistanceAchievement(m_playerTotalDist);
		SetKillsAchievement(m_playerTotalKills);
		SetCollectorAchievement(m_playerTotalParts);
		SetPlayerMedals();
	}
	
	private void SetMissionAchievement(int numMissions)
	{
		if (numMissions < 30) 
		{
			m_medalAwarded[2] = 0;
		}
		else if(numMissions >= 30 && numMissions < 120) 
		{
			m_medalAwarded[2] = 1;
		}
		else if (numMissions >= 120 && numMissions < 360)
		{
			m_medalAwarded[2] = 2;
		}
		else if (numMissions >=  360)
		{
			m_medalAwarded[2] = 3;
		}
	}
	
	private void SetDistanceAchievement(int distance)
	{
		if (distance < 5000) 
		{
			m_medalAwarded[1] = 0;
		}
		else if(distance >= 5000 && distance < 25000) 
		{
			m_medalAwarded[1] = 1;
		}
		else if (distance >= 25000 && distance < 125000)
		{
			m_medalAwarded[1] = 2;
		}
		else if (distance >=  125000)
		{
			m_medalAwarded[1] = 3;
		}
	}
	
	private void SetKillsAchievement(int numKills)
	{
	
	}
	
	private void SetCollectorAchievement(int numParts)
	{
		if (numParts < 1000) 
		{
			m_medalAwarded[0] = 0;
		}
		else if(numParts >= 1000 && numParts < 5000) 
		{
			m_medalAwarded[0] = 1;
		}
		else if (numParts >= 5000 && numParts < 25000)
		{
			m_medalAwarded[0] = 2;
		}
		else if (numParts >=  25000)
		{
			m_medalAwarded[0] = 3;
		}
	}
	
	private void InitializeGame()
	{
		m_missionEnd = false;
		OnCalibrateAccelerometer();
		m_playerStartTime = Time.timeSinceLevelLoad;
		m_showMissionPopupTime = Time.time + 5.0f;
		CreateCells();	
		CreatePlayer();	
	}
	
	private void InitializePlayer()
	{
		m_playerMissionPass = false;
		m_missionEnd = false;
		m_cameraPosition = 0.0f;
		
		if(!demoMode)
		{
			m_missionLength = (m_playerRank + 1) * 200.0f  + (m_playerRankComplete * (m_playerRank + 1) * 2.0f);
		}
		else
		{
			m_missionLength = 200000;
		}
		m_playerVelocity = m_playerVelocityStart;
		m_playerOffset = Vector3.zero;
		m_missionReportSet = false;
		m_distanceRun = 0;
		m_playerTime = 0.0f;
		m_partsCollected = 0;
		m_powerUpType = 0;
		m_playerKills = 0;
		m_displayDirection = 0;
		m_speedChange = false;
		m_playerStartTime = Time.timeSinceLevelLoad;
		m_onContinueGame = false;
		m_onRetryGame = false;
		m_onExitGame = false;
		m_activateShield = false;
		CreateMissionHintsGUI();
		if(Joystick != null) Joystick.SetActive(true);
		CreateFireButton();
		CreateMissileButton();
		CreateSpeedControl();
	}
	
	private void LoadPlayerPrefs()
	{
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
		m_playerDecal = PlayerPrefs.GetInt("PlayerDecal", 0);
		m_engineMultiplier = PlayerPrefs.GetFloat("PlayerEngine", 1.0f);
		m_gunType = PlayerPrefs.GetInt ("PlayerGun", 0);
		m_cargoType = PlayerPrefs.GetInt ("PlayerCargo", 0);
		m_missileType = PlayerPrefs.GetInt ("PlayerMissile", 0);
		m_shieldType = PlayerPrefs.GetInt ("PlayerShield", 0);
		
		//m_playerRank = 2; // test
		GetPlayerAchievements();
	}
	
	private void GetPlayerAchievements()
	{
		string medalName = string.Empty;
		
		for (int i = 0; i <=9; i++)
		{	
			medalName = "Medal" + i.ToString();
			m_medalAwarded[i] = PlayerPrefs.GetInt(medalName , 0);
		}
	}
	
	private void SetPlayerMedals()
	{
		string medalName = string.Empty;
		
		for (int i = 0; i <=9; i++)
		{	
			medalName = "Medal" + i.ToString();
			PlayerPrefs.SetInt(medalName , m_medalAwarded[i]);
		}
	}
	
	private void OnMissionEnd()
	{
		CreateExitButton();
		CreateMissionReport();
		Destroy(FireButton);
		Destroy (MissileButton);
		Destroy(SpeedControl);
		if(Joystick != null) Joystick.SetActive(false);
		
		if(!m_playerMissionPass)
		{
			CreateRetryButton();
		}
		else
		{
			CreateNextLevelButton();
			m_playerVelocity = 0.0f;
		}
	}
	
	
	public void OnPlayerContinue()
	{
		m_onContinueGame = false;
		OnCalibrateAccelerometer();
		Destroy (ExitButton);
		Destroy (NextLevelButton);
		Destroy (MissionReport);
		InitializePlayer();
	}
	
	public void OnPauseGame()
	{
		m_playerVelocity = 0.0f;
	}
	
	public void OnPlayerRetry() // restart player
	{
		m_onRetryGame = false;
		Destroy (ExitButton);
		Destroy (RetryButton);
		Destroy (MissionReport);
		DestroyAllCells();
		OnCalibrateAccelerometer();
		m_playerStartTime = Time.timeSinceLevelLoad;
		m_showMissionPopupTime = Time.time + 5.0f;;
		CreateCells();	
		CreatePlayer();	
	}

	public void OnPlayerRestart() // go back to main menu
	{
		m_onExitGame = false;
		SetPlayerData();
		Destroy(InGameGUI);
		Destroy (ExitButton);
		Destroy (MissionReport);
		if(Joystick != null)
		{
			Destroy (Joystick);
		}
		DestroyAllCells();
		if(RetryButton != null) Destroy (RetryButton);
		if(NextLevelButton != null) Destroy (NextLevelButton);
		
		Application.LoadLevel("returnMenu");
	}
	
	#endregion

	#region Private Functions
			
	private void DisplayMissionPopupScreen()
	{
		if(GameObject.Find("MissionHints")) 
		{
			GameObject missionHints = GameObject.Find("MissionHints");
			if(Time.time > m_showMissionPopupTime)
			{
				Destroy (missionHints);
			}
		}	
	}
	
	private void OnDamage()
	{
		
	}
	
	private void OnExplosion(AudioClip clip)
	{
		m_Explosion = (GameObject)Instantiate(ExplosionPrefab, m_player.transform.position, Quaternion.identity);	
		Destroy(m_player);
		AudioSource.PlayClipAtPoint(clip, m_player.transform.position);	
	}
		
	private void PlayMusic()
	{
		gameSounds.clip = m_ambientSound;
		//gameSounds.gameObject.SetActiveRecursively(true);
		if(!gameSounds.isPlaying) 
		{
			gameSounds.volume = m_musicVolume;
			gameSounds.Play();
		}
		gameMusic.clip = m_ambientMusic;
		//gameMusic.gameObject.SetActiveRecursively(true);
		if(!gameMusic.isPlaying) 
		{
			gameMusic.volume = m_musicVolume;
			gameMusic.Play();
		}
	}
	
	private void CreateNewCellsIfNeeded(bool ForceCreate)
	{
		// If player is halfway along the track, we should create new segments and remove old ones
		if ((m_cells.IndexOf(m_playerCell) >= m_cells.Count / 2 && m_playerTimer > 0.5f) || ForceCreate)
		{
			int startFrom = m_cells.Count;

			// This is a recursive call.  Creates [m_maxCells] segments
			CreateNextCell(m_cells[m_cells.Count-1], 0);			
			
			// Create scenery, change segments into obstacles, place 3d Models, etc.
			for (int k = startFrom; k< m_cells.Count; k++)
			{
				//CreateScenery(m_cells[k]);
				if(m_distanceRun >= 100 && m_trackObstacleCount <= 0) CreateObstacle(m_cells[k]);
				CreateCellModel(m_cells[k]);
				if(m_playerRank > 1 && m_distanceRun >= 100) CreateEnergyMine(m_cells[k]);
				if(m_inCave && m_distanceRun >= 50) CreateCoins(m_cells[k]);
			}			
			
			// Cleanup old segments (remove them)
			if (!ForceCreate)
			{
				for (int k = m_cells.IndexOf(m_playerCell); k>= 0; k--)
				{
					if (m_cells[k].Visited == true && m_playerCell != m_cells[k])
					{
						for (int l = m_cells[k].m_coins.Count-1; l >= 0; l--)
						{
							PoolManager.Pools["Powerup"].Despawn(m_cells[k].m_coins[l].transform);
							//Destroy(m_cells[k].m_coins[l]);
						}

						m_cells[k].m_coins.Clear();
						m_cells[k].m_coins.TrimExcess();	
						
						for (int l = m_cells[k].m_EnergyMine.Count-1; l >= 0; l--)
						{
							Destroy(m_cells[k].m_EnergyMine[l]);
						}

						m_cells[k].m_EnergyMine.Clear();
						m_cells[k].m_EnergyMine.TrimExcess();	
	
						//Destroy(m_cells[k].CellModel);
						PoolManager.Pools["Corridor"].Despawn(m_cells[k].CellModel.transform);
						m_cells.RemoveAt(k);
					}
				}
			}	
		}
	}

	/// <summary>
	/// Checks to see if the player has collided with gold coins
	/// </summary>
	private void UpdateCoins()
	{
		if (m_player == null)
			return;
		
		for (int c = 0; c < m_cells.Count; c++)
		{	
			for (int k=m_cells[c].m_coins.Count - 1; k >= 0 ; k--)
			{
				if (Vector3.Distance(m_cells[c].m_coins[k].transform.position, m_player.transform.position) < 0.5f)
				{				
					AudioSource.PlayClipAtPoint(m_chingAudio, m_player.transform.position);	
					if(m_cells[c].m_coins[k].name == "life") 
					{
						s_primaryShield += 0.05f;
						if(s_primaryShield >= 1.00f) s_primaryShield = 1.0f;
					}
					else if(m_cells[c].m_coins[k].name == "energy") 
					{
						s_energyAvailable += 0.10f;
						if(s_energyAvailable >= 1.0f) s_energyAvailable = 1.0f;
					}
					else if(m_cells[c].m_coins[k].name == "parts")
					{
						m_partsCollected++; 
					}
					PoolManager.Pools["Powerup"].Despawn(m_cells[c].m_coins[k].transform);
					//Destroy(m_cells[c].m_coins[k]);
					m_cells[c].m_coins.RemoveAt(k);
				}
			}
		}
	}

	/// <summary>
	/// Checks to see if the player has collided with energy mines
	/// </summary>
	private void UpdateEnergyMines()
	{
		if (m_player == null)
			return;		
		
		for (int c = 0; c < m_cells.Count; c++)
		{
			for (int k = m_cells[c].m_EnergyMine.Count - 1; k >= 0; k--)
			{
				if (Vector3.Distance(m_cells[c].m_EnergyMine[k].transform.position, m_player.transform.position) < 0.25f)
				{	
					Instantiate(m_Explosion, m_cells[c].m_EnergyMine[k].transform.position, Quaternion.identity);						
					m_cells[c].m_EnergyMine.RemoveAt(k);
					if(m_cells[c].m_EnergyMine[k] != null) Destroy(m_cells[c].m_EnergyMine[k]);
					s_primaryShield -= 0.20f;
					if(s_primaryShield <= 0.0f)	
					{
						SetEndMissionParameters(false, "It's all fun and games until you get blown-up.  (Avoid energy mines!)");
						return;
					}
				}
			}
		}
	}

	// Set / reset the player at the start of each run.
	private void CreatePlayer()
	{
		m_player = (GameObject)Instantiate(m_playerPrefab, new Vector3(0.0f, 0.95f, -1.5f), Quaternion.identity);
		m_player.name = "PlayerFighter";

		m_playerCell            = m_cells[0];
		m_playerDirection       = enCellDir.North;
		m_playerNextDirection   = enCellDir.North;
		m_previousCellDirection = enCellDir.North;
	
		m_playerClass = enCellClass.OpenTrack;
		m_playerCell.CellSize = enCellSize.Single;
		m_trackDoorCount = 0;
		
		m_inCave = false;
		s_energyAvailable = 1.00f;
		s_primaryShield = 1.00f;
		s_shipMissileCount = 12;
		InitializePlayer();
		LoadPlayerPrefs();
	}
	
	// Logic for the player. 
	private void UpdatePlayer()
	{
		// if the player is dead (replaced with ragdoll) then exit since none of this code should fire.
		if (m_player == null) 
		{
			return;		
		}
		
		// AUTO PLAYER FOR TESTING
		// Allows the AI to control the player.  Used for debugging mainly.

		if(debugMode) m_playerNextDirection = m_playerCell.CellDirection;
	
		m_playerTime = Time.time - m_playerStartTime;
		
		// Increase the players progress across the current cell, taking into accound current run speed and stumbling
		m_playerTimer += Time.deltaTime * m_playerVelocity;
		
		if(m_playerVelocity <= m_playerSetSpeed && m_playerMadeTurn) 
		{
			m_speedChange = true;
			m_playerVelocity += 0.0002f;
			m_playerMadeTurn = false;
		}
		
		// If we reach the end of a cell, we need to move to the next one (or possibly die!)
		if (m_playerTimer >= 1.0f)
		{
			m_distanceRun += 10;
			m_playerTimer = 0.0f;
			m_playerDir = 0.0f;
			
			
			OnEnergyUse();
			
			m_previousCellDirection = m_playerCell.CellDirection;

			// Determine which cell to move the player to.
			switch (m_playerCell.CellDirection)
			{
				case enCellDir.North:
					m_playerCell = m_playerCell.NeighbourN;
					m_displayDirection = 0;
					break;

				case enCellDir.South:
					m_playerCell = m_playerCell.NeighbourS;
					m_displayDirection = 1;
					break;

				case enCellDir.East:
					m_playerCell = m_playerCell.NeighbourE;
					m_displayDirection = 3;
					break;

				case enCellDir.West:
					m_playerCell = m_playerCell.NeighbourW;
					m_displayDirection = 2;
					break;
				
				case enCellDir.Up:
					m_playerCell = m_playerCell.NeighbourU;
					break;
				
				case enCellDir.Down:
					m_playerCell = m_playerCell.NeighbourD;
					break;
			}
			
			if(m_playerCell.CellClass == enCellClass.SingleDoor || m_playerCell.CellClass == enCellClass.DoubleDoor)
			{
				m_animateDoors = true;
			}
			else
			{
				m_animateDoors = false;
			}	
		}
		
		// Tell the current cell it's been visited, so it can be removed later.
		m_playerCell.Visited = true;		

		// If current cell is unspecified (usually on first run) then reset some stuff.
		if (m_playerCell == null)
		{
			m_playerCell            = m_cells[0];
			m_playerDirection       = enCellDir.North;
			m_playerNextDirection   = enCellDir.North;
			m_previousCellDirection = enCellDir.North;
		}
	
		if(m_playerCell.CellClass == enCellClass.TurnTrackL)		 
		{
			if(m_tilt <= -m_tiltOK) 
			{
				if(m_playerDir > -2.0f) m_playerDir = -1.0f;
				m_swipeLeft = true;
			}
		}
		
		if(m_playerCell.CellClass == enCellClass.TurnTrackR)		 
		{
			if(m_tilt >= m_tiltOK) 
			{
				if(m_playerDir < 2.0f) m_playerDir = 1.0f;
				m_swipeRight = true;
			}
		}
		
		if(m_playerCell.CellType == enCellType.NarrowObstacle)
		{
			m_narrowCorridor = true;
		}
		else
		{
			m_narrowCorridor = false;
		}
		
		if(m_playerCell.CellClass == enCellClass.StationEntrance)
		{
			GameObject gate = GameObject.Find("gate");
			if(gate != null && m_distanceRun >= 10) 
			{
				gate.GetComponent<Animation>()["open"].speed = 1.5f;
				gate.GetComponent<Animation>().Play("open");
			}
		}
		
		if(m_playerCell.CellClass == enCellClass.FighterBay)
		{
			GameObject elevator = GameObject.Find("elevator");
			if(elevator != null && m_distanceRun >= 20) 
			{
				elevator.GetComponent<Animation>()["down"].speed = 1.5f;
				elevator.GetComponent<Animation>().Play("down");
			}
		}
		
		// Change Player Direction if we are on a turn cell
		if (m_playerTimer >= 0.5f && m_previousCellDirection != m_playerCell.CellDirection)
		{			
			// If we haven't already
			if (m_playerDirection != m_playerNextDirection )
			{
				if(m_playerVelocity > 0.25f)
				{
					m_playerSetSpeed = m_playerVelocity;
					m_playerVelocity -= m_cornerSlowdown; // corner slowdown
					m_playerMadeTurn = true;
					m_speedChange = true;
					if(m_playerVelocity <= 0.05f) m_playerVelocity = 0.05f;
				}
				// Set player direction to player next direction (from input)
				m_playerDirection = m_playerNextDirection;			
				AudioSource.PlayClipAtPoint(m_turnAudio, m_player.transform.position);
			}
		}
	
		if(m_distanceRun >= m_missionLength)
		{
			SetEndMissionParameters(true, "");	
		}
		
		UpdateObstacles();
		UpdateMovement();	
	}

	private void UpdateObstacles()
	{	
		if (m_player == null)
			return;	
		
		// If player is not travelling in the correct direction, then we destroy player and create ragdoll
		if (m_playerDirection !=  m_playerCell.CellDirection)
		{
			if(m_playerTimer >= 0.5f && m_playerTimer <= 0.8f)  
			{
				DamageAmount("Ship crashed into corridor wall.  You forgot to turn.", 0.3f);
				return;
			}
		}
			
		else if(m_playerCell.CellType == enCellType.TurnTrackL || m_playerCell.CellType == enCellType.TurnTrackR)
		{
			if(m_playerVelocity > 1.285f)
			{
				DamageAmount("Inertial Dampeners failed. Your craft is going too fast! Slow down!", 0.1f);
				return;
			}
		}
		
		// Is the current cell an obstacle that should be ducked under?
		else if (m_playerCell.CellType == enCellType.DuckObstacle)
		{			
			if (m_playerOffset.y > -m_HeightOK)
			{		
				CheckDamageAmount("Ship crashed into closed corridor ceiling.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		}
		
		// Is the current cell an obstacle that should be jumped (boxes in this case)?
		else if (m_playerCell.CellType == enCellType.JumpObstacle)
		{
			if(m_playerOffset.y < m_HeightOK)		
			{
				CheckDamageAmount("Ship Crashed.  Thrusted right into cargo containers.\n  You have died", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		}
		
		// Should we be jumping over a gap?
		else if (m_playerCell.CellType == enCellType.JumpGap)
		{
			if(m_playerOffset.y < m_HeightOK)
			{
				CheckDamageAmount("Ship crashed into closed corridor floor.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		}
		
		// Should we be jumping over a gap?
		else if (m_playerCell.CellType == enCellType.NarrowObstacle)
		{
			if (m_playerOffset.y < -m_HeightOK)
			{
				CheckDamageAmount("Ship crashed into narrow corridor floor.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		
			if(m_playerOffset.y > m_HeightOK)
			{
				CheckDamageAmount("Ship crashed into narrow corridor ceiling.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		}
		
		// Should we be jumping over a gap?
		else if (m_playerCell.CellType == enCellType.NarrowLow)
		{
			if (m_playerOffset.y < -m_HeightOK)
			{
				CheckDamageAmount("Ship crashed into narrow corridor floor.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		}
		
		else if (m_playerCell.CellType == enCellType.NarrowHigh)
		{
			if(m_playerOffset.y > m_HeightOK)
			{
				CheckDamageAmount("Ship crashed into narrow corridor ceiling.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
				return;
			}
		}
		
		// Should we be jumping over a door?
		else if (m_playerCell.CellClass == enCellClass.SingleDoor || m_playerCell.CellClass == enCellClass.DoubleDoor)
		{
			if (m_playerTimer >= 0.45f && m_playerTimer <= 0.55f && m_playerOffset.y < -0.4f || m_playerOffset.y > 0.4f)
			{
				DamageAmount("Ship crashed into door frame.\n  You have died.", m_shieldDamageAmount * Mathf.Abs(m_playerOffset.y));
			}
		}
		
		else if(m_playerCell.CellType == enCellType.LedgeLeft)
		{
			if(m_playerCell.CellSize == enCellSize.Single)   
			{
				GetLeftSideDamage(0.25f); // 0.10
			}
			else if(m_playerCell.CellSize == enCellSize.Double)
			{
				GetLeftSideDamage(-0.10f); // -0.10
			}
		}
		
		else if(m_playerCell.CellType == enCellType.LedgeRight)
		{
			if(m_playerCell.CellSize == enCellSize.Single)   
			{
				GetRightSideDamage(-0.25f); // -0.10, 0.10
			}
			else if(m_playerCell.CellSize == enCellSize.Double)
			{
				GetRightSideDamage(0.10f); // 0.10, -0.10
			}
		}
		
		else if(m_playerCell.CellClass != enCellClass.OpenTrack)
		{
			if(m_height > 0.50f)
			{
				DamageAmount("Ceiling Scraper...\n You have died.", m_wallDamage * Mathf.Abs(m_height));
				return;
			}
			
			if(m_height < -0.50f)
			{
				DamageAmount("Scraping the floor...\n You have died.", m_wallDamage * Mathf.Abs(m_height));
				return;
			}
			
			if (m_playerCell.CellSize == enCellSize.Single)
			{
				m_cellOffset = m_maxOffset;
			}
			else
			{
				m_cellOffset = m_maxOffsetWide;
			}
			
			if(m_playerCell.CellDirection == enCellDir.North || m_playerCell.CellDirection == enCellDir.South)
			{
				if(m_playerOffset.x > m_maxOffsetWall.x || -m_playerOffset.x < -m_maxOffsetWall.x)
				{
					DamageAmount("Running into corridor walls is a killer.\n You have died.", m_wallDamage * Mathf.Abs(m_playerOffset.x));
					return;
				}
			}
			else
			{
				if(m_playerOffset.z > m_maxOffsetWall.z || -m_playerOffset.z < -m_maxOffsetWall.z)
				{
					DamageAmount("Running into corridor walls is a killer.\n You have died.", m_wallDamage * Mathf.Abs(m_playerOffset.z));
					return;
				}
			}
		}
	}
	
	private void GetLeftSideDamage(float posOK)
	{
		if(!debugMode) 
		{
			if(m_playerCell.CellDirection == enCellDir.North && (m_playerOffset.x < posOK)) //ok
			{
				CheckDamageAmount("Ship crashed into closed LN corridor wall.", Mathf.Abs(m_playerOffset.x) + 0.3f);
				//Debug.LogError("LN: " + m_playerOffset);
			}	
			else if(m_playerCell.CellDirection == enCellDir.South && (m_playerOffset.x > -posOK))
			{
				CheckDamageAmount("Ship crashed into closed LS corridor wall.", Mathf.Abs(m_playerOffset.x) + 0.3f);
				//Debug.LogError("LS: " + m_playerOffset);
			}
			else if(m_playerCell.CellDirection == enCellDir.West && (m_playerOffset.z < posOK)) //OK
			{
				CheckDamageAmount("Ship crashed into closed LW corridor wall.", Mathf.Abs(m_playerOffset.z) + 0.3f);
				//Debug.LogError("LW: " + m_playerOffset);
			}
			else if(m_playerCell.CellDirection == enCellDir.East &&  (m_playerOffset.z > -posOK))
			{
				CheckDamageAmount("Ship crashed into closed LE corridor wall.", Mathf.Abs(m_playerOffset.z) + 0.3f);
				//Debug.LogError("LE: " + m_playerOffset);
			}	
		}
	}
	
	private void GetRightSideDamage(float posOK)
	{
		if(!debugMode) 
		{
			if(m_playerCell.CellDirection == enCellDir.North && (m_playerOffset.x > posOK)) //OK
			{
				if(debugMode) m_playerNextDirection = m_playerCell.CellDirection;
				//Debug.LogError("RN: " + m_playerOffset);
			}
			else if(m_playerCell.CellDirection == enCellDir.South && (m_playerOffset.x < -posOK)) 
			{
				CheckDamageAmount("Ship crashed into RS closed corridor wall.", Mathf.Abs(m_playerOffset.x) + 0.3f);
				//Debug.LogError("RS: " + m_playerOffset);
			}
			else if(m_playerCell.CellDirection == enCellDir.West && (m_playerOffset.z > posOK)) //OK
			{
				CheckDamageAmount("Ship crashed into RW closed corridor wall.", Mathf.Abs(m_playerOffset.z) + 0.3f);
				//Debug.LogError("RW: " + m_playerOffset);
			}
			else if(m_playerCell.CellDirection == enCellDir.East && (m_playerOffset.z < -posOK))
			{
				CheckDamageAmount("Ship crashed into RE closed corridor wall.", Mathf.Abs(m_playerOffset.z) + 0.3f);
				//Debug.LogError("RE: " + m_playerOffset);
			}
		}
	}
	
	private void CheckDamageAmount(string damageText, float damageAmt)
	{
		if(m_playerTimer >= m_minActionDist && m_playerTimer <= m_maxActionDist)
		{	
			DamageAmount(damageText, damageAmt);
		}
	}
	
	private void DamageAmount(string damageText, float damageAmt)
	{
		s_primaryShield -= m_playerVelocity * damageAmt;
		m_activateShield = true;
		if(s_primaryShield <= 0.0f)	
		{
			SetEndMissionParameters(false, damageText);
		}
	}
	
	private void GetMovement()
	{
		
	}
	
	private void UpdateMovement()
	{
		if (m_player == null)
			return;	
		
		// Update player position
		Vector3 pos = m_playerCell.CellPosition;
		
		float offset = (m_playerTimer * m_cellSpacing) - (m_cellSpacing / 2.0f);
		
		if(i_inputType == 0)
		{
			i_inputAccelTilt = GetAccelerometer(Input.acceleration);
			i_inputAcceleration = Input.acceleration;
			
		}
		else
		{
			VCAnalogJoystickBase joy = VCAnalogJoystickBase.GetInstance("magicstick");
			if (joy != null)
			{
				i_inputAcceleration.x  = joy.AxisX;
				i_inputAccelTilt.y = -joy.AxisY;
			}
		}
		
		if(i_inputAcceleration.sqrMagnitude > 1) {
			i_inputAcceleration.Normalize();
		}
		
		if(i_inputAccelTilt.sqrMagnitude > 1) {
			i_inputAccelTilt.Normalize();
		}
		
		i_inputAcceleration *= i_sensitivity;
		i_inputAccelTilt *= i_sensitivity;
		
		if(!i_landscapeMode)
		{
			if(i_inputAcceleration.x > i_deadZone || i_inputAcceleration.x < -i_deadZone) {
				m_rotation.x = -i_inputAcceleration.x/ 4.0f;
				m_rotPitch = -i_inputAcceleration.x;
			}
			else {
				m_rotation.x = 0.0f;
				m_rotPitch = 0.0f;
			}
			
			if(i_inputAccelTilt.y > i_deadZone || i_inputAccelTilt.y < -i_deadZone) {
				m_rotation.y = i_inputAccelTilt.y / 4.0f;
				m_rotHeight = i_inputAccelTilt.y;
			}
			else {
				m_rotation.y = 0.0f;
				m_rotHeight = 0.0f;
			}
			
			if(i_inputAccelTilt.y > 0) m_rotation.y = 0.0f;
		}
		else
		{
			if(i_inputAcceleration.x > i_deadZone || i_inputAcceleration.x < -i_deadZone) {
				m_rotPitch = -i_inputAcceleration.y;
				m_rotation.x = -i_inputAcceleration.y;
			}
			else {
				m_rotation.x = 0.0f;
				m_rotPitch = 0.0f;
			}
			
			if(i_inputAccelTilt.x > i_deadZone || i_inputAccelTilt.x < -i_deadZone) {
				m_rotation.z = i_inputAccelTilt.x;
				m_rotPitch = i_inputAccelTilt.x;
			}
			else {
				m_rotation.z = 0.0f;
				m_rotHeight = 0.0f;
			}
			
			if(i_inputAccelTilt.x > 0) m_rotation.z = 0.0f;
		}
		
		switch (m_playerDirection)
		{
			case enCellDir.North:
				tempRotation = new Vector3(0, 0, 0);
				pos.x += m_playerOffset.x;
				pos.y += m_playerOffset.y + m_playerBaseHeight;
				pos.z += offset + m_playerOffset.z;
				break;

			case enCellDir.South:
				tempRotation = new Vector3(0, 180, 0);
				pos.x += m_playerOffset.x;
				pos.y += m_playerOffset.y + m_playerBaseHeight;
				pos.z -= offset + m_playerOffset.z;
				break;

			case enCellDir.East:
				tempRotation = new Vector3(0, 90, 0);
				pos.x += offset + m_playerOffset.x;
				pos.y += m_playerOffset.y + m_playerBaseHeight;
				pos.z += m_playerOffset.z;
				break;

			case enCellDir.West:
				tempRotation = new Vector3(0, 270, 0);
				pos.x -= offset + m_playerOffset.x;
				pos.y += m_playerOffset.y + m_playerBaseHeight;
				pos.z += m_playerOffset.z;
			break;
			
			case enCellDir.Up:
				pos.y -= offset + m_playerBaseHeight;
				break;
			
			case enCellDir.Down:
				pos.y += offset + m_playerBaseHeight;
				break;
		}
		
		// Add left-right offset code here //
		
		m_tilt = -(Mathf.Clamp(m_rotPitch, -1.0f, 1.0f)) * 4.0f;	
		m_height = -(Mathf.Clamp(m_rotHeight, -1.0f, 1.0f) * 4.0f);
		
		MovePlayerHorizontal(m_tilt / 4.0f);
		
		m_player.transform.right = -MoveAverage(m_rotation.normalized);
		m_player.transform.up = -MoveAverage(m_rotation.normalized);
		
		m_playerOffset.y += (m_playerMoveSpeed * m_height / 4.0f);  
		
		if (m_playerCell.CellSize == enCellSize.Single)
		{
			m_maxOffsetWall = m_maxOffset;
			m_cellOffset = m_maxOffset;
			if(m_playerCell.CellDirection == enCellDir.North || m_playerCell.CellDirection == enCellDir.South)
			{
				m_maxOffsetWall.x -= (Mathf.Abs(m_playerOffset.y * 0.1f));
			}
			else
			{
				m_maxOffsetWall.z -= (Mathf.Abs(m_playerOffset.y * 0.1f));
			}
		}
		else
		{
			m_maxOffsetWall = m_maxOffsetWide;
			m_maxOffset = m_maxOffsetWide;
			if(m_playerCell.CellDirection == enCellDir.North || m_playerCell.CellDirection == enCellDir.South)
			{
				m_maxOffsetWall.x -= (Mathf.Abs(m_playerOffset.y * 0.10f));
			}
			else
			{
				m_maxOffsetWall.z -= (Mathf.Abs(m_playerOffset.y * 0.10f));
			}
		}
		
		m_playerOffset.x = Mathf.Clamp(m_playerOffset.x, -m_cellOffset.x, m_cellOffset.x);
		m_playerOffset.y = Mathf.Clamp(m_playerOffset.y, -m_cellOffset.y, m_cellOffset.y);
		m_playerOffset.z = Mathf.Clamp(m_playerOffset.z, -m_cellOffset.z, m_cellOffset.z);
		
		// Set the player's position taking everything above into account.
		m_player.transform.position = pos;	
		
		// ROTATION CODE
		
		tempRotation +=  m_player.transform.localEulerAngles;
		if(tempRotation.z > 45.0f && tempRotation.z < 180.0f) tempRotation.z = 45.0f;
		else if(tempRotation.z < 315.0f && tempRotation.z > 180.0f) tempRotation.z = 315.0f;
		
		m_displayBank = tempRotation.z;
		m_displayTilt = m_playerOffset.y;
		
		m_player.transform.rotation = Quaternion.Euler(tempRotation);
		
		m_playerVelocity += Time.deltaTime * m_playerSpeedInc; // Gradually increase the players' running speed
		m_playerVelocity = Mathf.Clamp(m_playerVelocity, m_playerMinSpeed, m_playerMaxSpeed);
		
		if(m_swipeLeft) OnTurnLeft();
		if(m_swipeRight) OnTurnRight();
		
		m_cameraPosition = -m_playerOffset.y;
		displaySpeed = Mathf.FloorToInt(m_playerVelocity * 100);
		displayDist = Mathf.FloorToInt( m_distanceRun + (m_playerTimer * 10));
	}
	
	public void OnCalibrateAccelerometer() {

    	Vector3 wantedDeadZone = Input.acceleration;
    	Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), wantedDeadZone);

    	//create identity matrix ... rotate our matrix to match up with down vector
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));

   		//get the inverse of the matrix
    	this.calibrationMatrix = matrix.inverse;

	}
	
	//Whenever you need an accelerator value from the user
	//call this function to get the 'calibrated' value

	public Vector3 GetAccelerometer(Vector3 accelerator) 
	{
    	Vector3 accel = this.calibrationMatrix.MultiplyVector(accelerator);
    	return accel;
	}
	
	private void MovePlayerHorizontal(float moveSpeed)
	{		
		if (m_playerCell.CellDirection == enCellDir.North)
		{
			m_playerOffset.x += moveSpeed;
		}
		else if(m_playerCell.CellDirection == enCellDir.South)
		{
			m_playerOffset.x -= moveSpeed;
		}
		else if(m_playerCell.CellDirection == enCellDir.West)
		{
			m_playerOffset.z += moveSpeed;
		}
		else if(m_playerCell.CellDirection == enCellDir.East)
		{
			m_playerOffset.z -= moveSpeed;
		}
	}
	
	public Vector3 MoveAverage(Vector3 sample)
	{
	    int sizeFilter  = 30;
		Vector3[] filter = new Vector3[30];
		Vector3 filterSum = Vector3.zero;
		int posFilter = 0;
		int qSamples = 0;
		
	    filterSum += sample - filter[posFilter];
	    filter[posFilter++] = sample;
	    if (posFilter > qSamples) qSamples = posFilter;
	    posFilter = posFilter % sizeFilter;
	    return filterSum / qSamples;
	}
	
	public void OnEnergyUse()
	{
		if(m_playerVelocity > 0.51) // Drain only if moving fast
		{
			s_energyAvailable -= m_playerVelocity / 25.0f;
			if(s_energyAvailable <= 0.0f)
			{
				s_energyAvailable = 0.0f;
				SetEndMissionParameters(false, "Player fighter out of energy");
				Destroy(m_player);
			}
		}
	}
	
	public void OnSwipeLeft()
	{
		m_swipeLeft = true;
		m_playerDir = -1.0f;
		Debug.LogError("left Swipe");		
	}
	
	public void OnSwipeRight()
	{
		m_swipeRight = true;
		m_playerDir = 1.0f;
		Debug.LogError("right Swipe");		
	}
	
	public void OnTurnLeft()
	{		
		if(m_playerCell.CellClass == enCellClass.TurnTrackL)
		{
			if(m_playerDir == -1.0f && m_swipeLeft)
			{
				m_playerDir = -2.0f;
				m_swipeLeft = false;
				m_swipeRight = false;
				
				if (m_playerDirection == enCellDir.North) 
				{
					m_playerNextDirection = enCellDir.West;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.z = m_playerOffset.x;
						m_playerOffset.x = 0.0f;
					}
				}	
				else if (m_playerDirection == enCellDir.East ) 
				{
					m_playerNextDirection = enCellDir.North;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.x = -m_playerOffset.z;
						m_playerOffset.z = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.South) 
				{
					m_playerNextDirection = enCellDir.East;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.z = m_playerOffset.x;
						m_playerOffset.x = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.West ) 
				{
					m_playerNextDirection = enCellDir.South;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.x = -m_playerOffset.z;
						m_playerOffset.z = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.Up ) 
				{
					m_playerNextDirection = enCellDir.West;	
				}
				else if (m_playerDirection == enCellDir.Down ) 
				{
					m_playerNextDirection = enCellDir.East;	
				}
			}
		}
	}
	
	public void OnTurnRight()
	{
		if(m_playerCell.CellClass == enCellClass.TurnTrackR)
		{
			if(m_playerDir == 1.0f && m_swipeRight)
			{
				m_playerDir = 2.0f;
				m_swipeLeft = false;
				m_swipeRight = false;
				
				if (m_playerDirection == enCellDir.North) 
				{
					m_playerNextDirection = enCellDir.East;	
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.z = -m_playerOffset.x;
						m_playerOffset.x = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.East )
				{
					m_playerNextDirection = enCellDir.South;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.x = m_playerOffset.z;
						m_playerOffset.z = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.South) 
				{
					m_playerNextDirection = enCellDir.West;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.z = -m_playerOffset.x;
						m_playerOffset.x = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.West )
				{
					m_playerNextDirection = enCellDir.North;
					if(m_playerTimer >= 0.5f)
					{
						m_playerOffset.x = m_playerOffset.z;
						m_playerOffset.z = 0.0f;
					}
				}
				else if (m_playerDirection == enCellDir.Up ) 
				{
					m_playerNextDirection = enCellDir.East;	
				}
				else if (m_playerDirection == enCellDir.Down ) 
				{
					m_playerNextDirection = enCellDir.West;	
				}
			}
		}
	}
	
	// Does exactly what it says on the tin.
	// Used to clean-up before creating a new track.
	private void DestroyAllCells()
	{
		// Destroy EVERYTHING
		for (int k = m_cells.Count - 1; k >= 0; k--)
		{			
			if (m_cells[k].m_coins.Count > 0)
			{
				for (int l = m_cells[k].m_coins.Count - 1; l >= 0; l--)
				{
					PoolManager.Pools["Powerup"].Despawn(m_cells[k].m_coins[l].transform);		
					//Destroy(m_cells[k].m_coins[l]);
				}

				m_cells[k].m_coins.Clear();
				m_cells[k].m_coins.TrimExcess();

			}
			
			if (m_cells[k].m_EnergyMine.Count > 0)
			{			
				for (int l=m_cells[k].m_EnergyMine.Count - 1; l >= 0; l--)
				{
					Destroy(m_cells[k].m_EnergyMine[l]);
				}
	
				m_cells[k].m_EnergyMine.Clear();
				m_cells[k].m_EnergyMine.TrimExcess();
			}

			//Destroy(m_cells[k].CellModel);
			PoolManager.Pools["Corridor"].Despawn(m_cells[k].CellModel.transform);
			m_cells.RemoveAt(k);			
		}	
		
		m_cells.Clear();
		m_cells.TrimExcess();
		m_cells = new List<stCell>();
	}

	// Start cell creation process
	private void CreateCells()
	{
		m_inCave = false;
		m_animateStationDoors = true;
		m_animateBay = true;
		// Setup Root Cell
		stCell rootCell = new stCell(Vector3.zero, enCellDir.North, enCellType.StandardTrack, enCellSize.Single, enCellClass.SingleTrack);
		m_distanceRun = 0;
		rootCell.CellPosition.y = m_tileBaseHeight;
		m_nrRails = 10;
		m_cells.Add(rootCell);
		CorridorPrefab = m_SingleOpen;
		if(m_nrRails == 1)
		{
			CorridorPrefab = m_SingleTrack[0];
		}
		else if(m_nrRails == 2)
		{
			CorridorPrefab = m_DoubleTrack[0];
		}
		else if(m_nrRails == 3)
		{	
			m_nrRails = 2;
			CorridorPrefab = m_SplitTrack;
		}
		else if(m_nrRails == 4)
		{	
			m_nrRails = 1;
			CorridorPrefab = m_SplitTrackRev;
		}
		else if(m_nrRails == 5)
		{
			CorridorPrefab = m_CrossoverTrack;
		}
		else if(m_nrRails == 6)
		{
			CorridorPrefab = m_FighterBay;
			m_inCave = true;
		}
		else if(m_nrRails == 7)
		{
			CorridorPrefab = m_SingleEntrance;
		}
		else if(m_nrRails == 8)
		{
			CorridorPrefab = m_SingleOpen;
		}
		else if(m_nrRails == 9)
		{
			CorridorPrefab = m_SingleOpen;
		}
		else if(m_nrRails == 10)
		{
			CorridorPrefab = m_SingleOpen;
		}
		else 
		{
			CorridorPrefab = m_SingleOpen;
		}

			//GameObject newCellModel = (GameObject)Instantiate(CorridorPrefab, rootCell.CellPosition, Quaternion.identity);
			
			// Spawn an instance (with same argument options as Instantiate())
			Transform newCellModel = PoolManager.Pools["Corridor"].Spawn(CorridorPrefab.transform, rootCell.CellPosition, Quaternion.identity);

			newCellModel.transform.parent = this.transform;
			rootCell.CellModel = newCellModel.gameObject;
			if(m_nrRails > 6 ) m_nrRails--;
			// Create track segment ready for player to run along
			CreateNewCellsIfNeeded(true);		
	}
	
	// Dependant on a number of factors (neighbouring cells, randomness) change the provided cell into an obstacle.
	private void CreateObstacle(stCell cell)
	{
		if (cell.CellType == enCellType.StandardTrack)
		{
			if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South)
			{
				if (cell.NeighbourN != null && cell.NeighbourS != null)
				{						
					if (cell.NeighbourN.CellDirection == cell.CellDirection  &&
						cell.NeighbourS.CellDirection == cell.CellDirection )
					{
						CreateObstacleCell(cell);				
					}
				}
			}				
			
			if (cell.CellDirection == enCellDir.East || cell.CellDirection == enCellDir.West)
			{	
				if (cell.NeighbourE != null && cell.NeighbourW != null)
				{						
					if (cell.NeighbourE.CellDirection == cell.CellDirection &&
						cell.NeighbourW.CellDirection == cell.CellDirection )
					{
						CreateObstacleCell(cell);			
					}
				}
			}
		}
	}
	
	private void CreateObstacleCell(stCell cell)
	{
		int j = 0;
		
		// Decide whether or not to change this tile into something else
		if (Random.Range(0.0f, 1.0f) > 0.10f && m_playerRank >= 0)
		{
			if (m_distanceRun > 30)
			{
				if(m_playerRank >= 4) j = 5;
				else if (m_playerRank >= 1) j = 4;
				else if (m_playerRank >= 1) j = 3;
				if (m_playerRank >= 1) j = 4;
				else j = 3;
			}
			int i = Random.Range(0, j);
			
			switch (i)
			{	
				// Possibly make this a narrow piece that needs to be navigated
				case 0:
					cell.CellType = enCellType.NarrowObstacle;
					cell.CellPosition.y = m_tileBaseHeight; 
					m_trackObstacleCount = 1;	
				break;
				
				// Possibly make this a narrow piece that needs to be navigated
				case 1:
					cell.CellType = enCellType.NarrowLow;
					cell.CellPosition.y = m_tileBaseHeight; 
					m_trackObstacleCount = 1;	
				break;
				
				// Possibly make this a narrow piece that needs to be navigated
				case 2:
					cell.CellType = enCellType.NarrowHigh;
					cell.CellPosition.y = m_tileBaseHeight; 
					m_trackObstacleCount = 1;	
				break;
				
				// Possibly make this a narrow tile
				case 3:
					cell.CellType = (Random.Range(0.0f, 1.0f) >= 0.5f ? enCellType.LedgeLeft : enCellType.LedgeRight);
					m_trackObstacleCount = 2;	
				break;
				
				// Possibly make this a broken piece that needs to be jumped
				case 4:
					cell.CellType = enCellType.JumpGap;
					cell.CellPosition.y = m_tileBaseHeight; 
					m_trackObstacleCount = 2;	
					break;
				
				// Possibly make this a jump obstacle
				case 5:
					cell.CellType = enCellType.DuckObstacle;
					cell.CellPosition.y = m_tileBaseHeight; 
					m_trackObstacleCount = 2;
				break;
				
				// Possibly make this a duck obstacle
				case 6:
					cell.CellType = enCellType.JumpObstacle;
					cell.CellPosition.y = m_tileBaseHeight; 
					m_trackObstacleCount = 2;
					break;

			}
		}		
	}
	
	private void CreateTurretCell(stCell cell)
	{
		// Create Turret!!
		if (Random.Range(0.0f, 1.0f) > 0.5f && m_cells.IndexOf(cell) > 2)
		{	
			
		}
	}
	
	private void CreateShieldCell(stCell cell)
	{
		// Create Turret!!
		if (Random.Range(0.0f, 1.0f) > 0.5f && m_cells.IndexOf(cell) > 2)
		{	
			// We only create landmines on "standard" cells
			if (cell.CellType == enCellType.StandardTrack)
			{
				// And not in corners.  That wouldn't be fair.
				if (!isCornerCell(cell))
				{
					// Create the landmine.
					GameObject shieldWall = (GameObject)Instantiate(m_ShieldWall, cell.CellPosition, Quaternion.identity);					
					cell.m_EnergyWall.Add(shieldWall);
				}
			}
		}
	}
	
	// Add landmine to the provided cell.  Maybe.
	private void CreateEnergyMine(stCell cell)
	{
		// Create Energy Mines!!!
		if (Random.Range(0.0f, 1.0f) > (1.0f - m_playerRank/ 10.0f) && m_cells.IndexOf(cell) > 2)
		{	
			// We only create landmines on "standard" cells
			if (cell.CellType == enCellType.StandardTrack)
			{
				// And not in corners.  That wouldn't be fair.
				if (!isCornerCell(cell))
				{
					// Create the landmine.
					GameObject energyMine = (GameObject)Instantiate(m_EnergyMine, cell.CellPosition + Vector3.up * 0.8f, Quaternion.identity);					
					cell.m_EnergyMine.Add(energyMine);
				}					
			}
		}
	}
	
	// Randomly place coins on the provided cell
	private void CreateCoins(stCell cell)
	{
		// Create Coins!
		if (Random.Range(0.0f, 1.0f) > 0.25f)
		{
			float r = Random.Range(-1, 1);
					
			m_powerUpType = Mathf.FloorToInt(Random.Range(0.0f, 3.0f));
			m_powerupRandomHeight = Random.Range(-4, 5)/ 10.0f;
			
			if (cell.CellSize == enCellSize.Double)
			{
				if (Random.Range(0.0f, 1.0f) > 0.5f)
				{
					r = 1;
				}
				else
				{
					r = -1;
				}
			}
			// Offset placement if on a ledge, so player can get the coins.  Aren't we nice?

			if (cell.CellType == enCellType.LedgeLeft)
			{
				if(cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.West) 
				{
					r = 1;
				}
				else if(cell.CellDirection == enCellDir.South || cell.CellDirection == enCellDir.East) 
				{
					r = -1;
				}
			}	
			if (cell.CellType == enCellType.LedgeRight)
			{
				if(cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.West)
				{
					r =  -1;
				}
				else if(cell.CellDirection == enCellDir.South || cell.CellDirection == enCellDir.East) 
				{
					r = 1;
				}
			}
			
			Vector3 laneOffset = Vector3.zero;

			if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South)
			{
				laneOffset.x = r * 0.3f;
			}
			
			if (cell.CellDirection == enCellDir.East || cell.CellDirection == enCellDir.West)
			{
				laneOffset.z = r * 0.3f;				
			}
			
			if (cell.CellDirection == enCellDir.Up || cell.CellDirection == enCellDir.Down)
			{
				laneOffset.y = r * 0.3f;				
			}
			
			for (float k= 0.5f; k < 1.0f; k+= 0.1f)
			{
				Vector3 pos = cell.CellPosition;
				
				if(cell.CellType == enCellType.NarrowObstacle)
				{
					pos.y = m_powerupHeight - 0.1f;
				}
				else
				{
					pos.y = m_powerupHeight + m_powerupRandomHeight;
				}
				
				float offset = (k * m_cellSpacing) - (m_cellSpacing / 2.0f);					
	
				switch (cell.CellDirection)
				{
					case enCellDir.North:
						pos.z += offset;
						break;
		
					case enCellDir.South:
						pos.z -= offset;
						break;
		
					case enCellDir.East:
						pos.x += offset;
						break;
		
					case enCellDir.West:
						pos.x -= offset;
						break;
					
					case enCellDir.Up:
						pos.y += offset;
						break;
					
					case enCellDir.Down:
						pos.y -= offset;
						break;
				}

				if (cell.CellType == enCellType.JumpGap || cell.CellType == enCellType.JumpObstacle)
				{
					pos.y += 0.5f + (Mathf.Sin(k * 10.0f) * 0.1f);
					if (cell.CellDirection == enCellDir.North) pos.z -= (m_cellSpacing / 5.0f);
					if (cell.CellDirection == enCellDir.East)  pos.x -= (m_cellSpacing / 5.0f);
					if (cell.CellDirection == enCellDir.Up)  pos.y -= (m_cellSpacing / 5.0f);
				}

				//PowerupPrefab = (GameObject)Instantiate(m_powerUp[m_powerUpType], pos + laneOffset, Quaternion.Euler(0, 360.0f / (k + 0.5f),0));
				Transform PowerupPrefab = PoolManager.Pools["Powerup"].Spawn(m_powerUp[m_powerUpType].transform, pos + laneOffset, Quaternion.Euler(0, 360.0f / (k + 0.5f),0));
			
				cell.m_coins.Add(PowerupPrefab.gameObject);
				if (m_powerUpType == 0) PowerupPrefab.gameObject.name = "life";
				else if (m_powerUpType == 1) PowerupPrefab.gameObject.name = "energy";
				else if (m_powerUpType == 2) PowerupPrefab.gameObject.name = "parts";
			}	
		}
	}
	
	// Recursive function to create cells.  
	private bool CreateNextCell(stCell previous, int cellCount)
	{
		// Can't do any more?  
		if (cellCount == m_maxCells) return false;

		// Create New Cell
		stCell newCell = new stCell(Vector3.zero, enCellDir.North, enCellType.StandardTrack, enCellSize.Single, enCellClass.SingleTrack);	
		
		stCell prevCell	= previous;
		
		// Determine position of new cell
		Vector3 newCell_Position = prevCell.CellPosition;
		
		// Determine Height of new cell
		newCell_Position.y =  m_tileBaseHeight;
		
		// Offset new cell from it's previous cell based on direction
		switch (prevCell.CellDirection)
		{
			case enCellDir.North:
				newCell_Position.z += m_cellSpacing;
				break;

			case enCellDir.South:
				newCell_Position.z -= m_cellSpacing;
				break;

			case enCellDir.East:
				newCell_Position.x += m_cellSpacing;
				break;

			case enCellDir.West:
				newCell_Position.x -= m_cellSpacing;
				break;
			
			case enCellDir.Up:
				newCell_Position.y += m_cellSpacing;
				break;
			
			case enCellDir.Down:
				newCell_Position.y -= m_cellSpacing;
				break;
		}	

		newCell.CellPosition = newCell_Position;
		newCell.CellDirection = prevCell.CellDirection;
		
		// Should we change direction?
		bool changeDirection = (cellCount > 1 && (Random.Range(0.0f, 1.0f) > 0.50f ? true : false) );
		// Should we add tracks? 2 -> and 1 -> 2
		bool change2Tracks = (cellCount > 2 && (Random.Range(0.0f, 1.0f) > 0.70f ? true : false) );
		bool change1Tracks = (cellCount > 1 && (Random.Range(0.0f, 1.0f) > 0.10f ? true : false) );
		
		
		// Should we add tracks? CrossOverTrack
		bool xfrTrack = (Random.Range(0.0f, 1.0f) > 0.01f ? true : false);
				
		if(m_nrRails == 2)
		{
			m_playerClass = enCellClass.DoubleTrack;
		}
		
		if (change2Tracks && m_distanceRun >= 40) // 40
		{
			if (m_nrRails == 1)
			{
				m_nrRails = 3;				
				m_playerClass = enCellClass.WyeOutTrack;
				change2Tracks = false;
			}
		}
			
		if(change1Tracks && m_nrRails == 2 || m_nrRails == 5)
		{
			m_nrRails = 4;
			m_playerClass = enCellClass.WyeInTrack;
			change1Tracks = false;
		}
		
		if (m_nrRails == 2 || m_nrRails == 4 && xfrTrack && m_distanceRun >= 80) //80
		{
			m_nrRails = 5;
			m_playerClass = enCellClass.CrossoverTrack;
		}
		
		if (changeDirection && m_distanceRun >= m_turnObstacleDist)		
		{
			// Determine whether to turn left or right
			// Bit of a dirty trick, but we don't yet cater for T junctions or doubling back.
			// This prevents the track from ever crossing itself.

			float LR = (m_lastTurnHDir < 0.0f? -0.5f : 0.5f);
			float UD = (m_lastTurnVDir < 0.0f? -0.5f : 0.5f);
			//bool turnType = (Random.Range(0.0f, 1.0f) > 0.50f ? true : false);
			bool turnType = true;
			
			switch (newCell.CellDirection)
			{
				case enCellDir.North:
					if(turnType)
					{
						newCell.CellDirection = LR < 0.0f ? enCellDir.West : enCellDir.East;
						if (m_trackTurnCount > 1) m_lastTurnHDir *= -1.0f;
					}
					else
					{
						newCell.CellDirection = UD < 0.0f ? enCellDir.Up : enCellDir.Down;
						m_lastTurnVDir *= -1.0f;
					}
					break;

				case enCellDir.South:
					if(turnType)
					{
						newCell.CellDirection = LR < 0.0f ? enCellDir.East : enCellDir.West;
						if (m_trackTurnCount > 1)  m_lastTurnHDir *= -1.0f;
					}
					else
					{
						newCell.CellDirection = UD < 0.0f ? enCellDir.Up : enCellDir.Down;
						m_lastTurnVDir *= -1.0f;
					}
					break;

				case enCellDir.East:
					if(turnType)
					{
						newCell.CellDirection = LR < 0.0f ? enCellDir.North : enCellDir.South;
						if (m_trackTurnCount > 1) m_lastTurnHDir *= -1.0f;
					}
					else
					{
						newCell.CellDirection = UD < 0.0f ? enCellDir.Up : enCellDir.Down;
						m_lastTurnVDir *= -1.0f;
					}
					break;
				
				case enCellDir.West:
					if(turnType)
					{
						newCell.CellDirection = LR < 0.0f ? enCellDir.South : enCellDir.North;
						if (m_trackTurnCount > 1)  m_lastTurnHDir *= -1.0f;
					}
					else
					{
						newCell.CellDirection = UD < 0.0f ? enCellDir.Up : enCellDir.Down;
						m_lastTurnVDir *= -1.0f;
					}
					break;
				
				case enCellDir.Up:
					if(turnType)
					{
						newCell.CellDirection = LR < 0.0f ? enCellDir.West : enCellDir.East;
						//m_lastTurnHDir *= -1.0f;
					}
					else
					{
						newCell.CellDirection = UD < 0.0f ? enCellDir.South : enCellDir.North;
						m_lastTurnVDir *= -1.0f;
					}
					break;
				
				case enCellDir.Down:
					if(turnType)
					{
						newCell.CellDirection = LR < 0.0f ? enCellDir.East : enCellDir.West;
						//m_lastTurnHDir *= -1.0f;
					}
					else
					{
						newCell.CellDirection = UD < 0.0f ? enCellDir.North : enCellDir.South;
						m_lastTurnVDir *= -1.0f;
					}
					break;
			}
		}

		//TODO: "Look ahead" to make sure we are not going to run into existing cells, and change direction if we are.	
		// Maybe in the next version.			
		
		// Link cells together using neighbour indices	
		if (prevCell.CellDirection == enCellDir.North)
		{
			prevCell.NeighbourN = newCell;
			newCell .NeighbourS = previous;
		}

		if (prevCell.CellDirection == enCellDir.South)
		{
			prevCell.NeighbourS = newCell;
			newCell .NeighbourN = previous;
		}

		if (prevCell.CellDirection == enCellDir.East)
		{
			prevCell.NeighbourE = newCell;
			newCell .NeighbourW = previous;
		}

		if (prevCell.CellDirection == enCellDir.West)
		{
			prevCell.NeighbourW = newCell;
			newCell .NeighbourE = previous;
		}
		
		if (prevCell.CellDirection == enCellDir.Up)
		{
			prevCell.NeighbourU = newCell;
			newCell .NeighbourD = previous;
		}
		
		if (prevCell.CellDirection == enCellDir.Down)
		{
			prevCell.NeighbourD = newCell;
			newCell .NeighbourU = previous;
		}

		// Add new cell to list	
		m_cells.Add (newCell);		
		
		// Recursive call to create next cell
		CreateNextCell(newCell, cellCount + 1);
		
		return true;		
	}
	
	// places the correct 3d model in the scene for a cell based on direction, type and neighbours
	// Simple nested switch statements and model rotations, nothing complex here.
	private void CreateCellModel(stCell cell)
	{
		GameObject prefabToInstantiate = null;
		GameObject m_StraightTrack = null;
		GameObject m_ObstacleJump = null;
		GameObject m_TrackBrokenHalf = null;
		GameObject m_TrackJump = null;
		GameObject m_TrackDuck = null;
		GameObject m_TrackNarrow = null;
		
		Quaternion rotation = Quaternion.identity;
		m_maxCells = 4;
		int cellType;
		
		m_trackObstacleCount--;
		m_trackDoorCount--;
		if(m_trackObstacleCount <= 0) m_trackObstacleCount = 0;	
		if(m_trackDoorCount <= 0) m_trackDoorCount = 0;	
		m_trackTurnCount--;
		if(m_trackTurnCount <= 0) m_trackTurnCount = 0;	

		switch (cell.CellType)
		{
			case enCellType.NarrowObstacle:
			
				if(cell.CellSize == enCellSize.Double)
				{
					m_TrackNarrow = m_DoubleNarrow;
				}
				else
				{
					m_TrackNarrow = m_SingleNarrow;
				}
				prefabToInstantiate = m_TrackNarrow;

				if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South) 
				{
					rotation = Quaternion.Euler(0.0f,  0.0f, 0.0f);
				}
				if (cell.CellDirection == enCellDir.East  || cell.CellDirection == enCellDir.West )
				{
					rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				}
			break;
			
			case enCellType.NarrowLow:
			
				if(cell.CellSize == enCellSize.Double)
				{
					m_TrackNarrow = m_DoubleNarrowLow;
				}
				else
				{
					m_TrackNarrow = m_SingleNarrowLow;
				}
				prefabToInstantiate = m_TrackNarrow;

				if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South) 
				{
					rotation = Quaternion.Euler(0.0f,  0.0f, 0.0f);
				}
				if (cell.CellDirection == enCellDir.East  || cell.CellDirection == enCellDir.West )
				{
					rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				}
			break;
				
			case enCellType.NarrowHigh:
			
				if(cell.CellSize == enCellSize.Double)
				{
					m_TrackNarrow = m_DoubleNarrowHigh;
				}
				else
				{
					m_TrackNarrow = m_SingleNarrowHigh;
				}
				prefabToInstantiate = m_TrackNarrow;

				if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South) 
				{
					rotation = Quaternion.Euler(0.0f,  0.0f, 0.0f);
				}
				if (cell.CellDirection == enCellDir.East  || cell.CellDirection == enCellDir.West )
				{
					rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				}
			break;
			
			case enCellType.JumpObstacle:

				if(cell.CellSize == enCellSize.Double)
				{
					m_ObstacleJump = m_Double_ObstacleJump;
				}
				else
				{
					m_ObstacleJump = m_Single_ObstacleJump;
				}
				prefabToInstantiate = m_ObstacleJump;

				if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South) 
				{
					rotation = Quaternion.Euler(0.0f,  0.0f, 0.0f);
				}
				if (cell.CellDirection == enCellDir.East  || cell.CellDirection == enCellDir.West )
				{
					rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				}
			break;

			case enCellType.DuckObstacle:
					
				if(cell.CellSize == enCellSize.Double)
				{
					m_TrackDuck = m_DoubleDuck[Random.Range(0, 2)];
				}
				else
				{
					m_TrackDuck = m_SingleDuck[Random.Range(0, 2)];
				}
			
				prefabToInstantiate = m_TrackDuck;

				if (cell.CellDirection == enCellDir.North || cell.CellDirection == enCellDir.South) 
				{
					rotation = Quaternion.Euler(0.0f,  0.0f, 0.0f);
				}
				if (cell.CellDirection == enCellDir.East  || cell.CellDirection == enCellDir.West)  
				{
					rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				}
			break;
				
			case enCellType.LedgeLeft:

				if(cell.CellSize == enCellSize.Double)
				{
					m_TrackBrokenHalf = m_DoubleHalfBroken;
				}
				else
				{
					m_TrackBrokenHalf = m_SingleHalfBroken;
				}
				prefabToInstantiate = m_TrackBrokenHalf;
			
				switch (cell.CellDirection)
				{	
					case enCellDir.North:

						rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
						break;

					case enCellDir.South:

						rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
						break;

					case enCellDir.East:
				
						rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
						break;

					case enCellDir.West:

						rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
						break;
				}
			break;
			
			case enCellType.LedgeRight:

				if(cell.CellSize == enCellSize.Double)
				{
					m_TrackBrokenHalf = m_DoubleHalfBroken;
				}
				else
				{
					m_TrackBrokenHalf = m_SingleHalfBroken;
				}
				prefabToInstantiate = m_TrackBrokenHalf;
			
				switch (cell.CellDirection)
				{	
					case enCellDir.North:

						rotation = Quaternion.Euler(0.0f,180.0f,0.0f);
						break;

					case enCellDir.South:

						rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
						break;

					case enCellDir.East:

						rotation = Quaternion.Euler(0.0f,270.0f,0.0f);
						break;

					case enCellDir.West:
						
						rotation = Quaternion.Euler(0.0f,90.0f,0.0f);
						break;
				}
			break;

			case enCellType.JumpGap:

				if(cell.CellSize == enCellSize.Double)
				{
				
					m_TrackJump = m_DoubleJump[Random.Range(0, 2)];
				}
				else
				{
					m_TrackJump = m_SingleJump[Random.Range(0, 2)];
				}
				prefabToInstantiate = m_TrackJump;
			
				switch (cell.CellDirection)
				{	
					case enCellDir.North:

						rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
						break;

					case enCellDir.South:

						rotation = Quaternion.Euler(0.0f,180.0f,0.0f);
						break;

					case enCellDir.East:

						rotation = Quaternion.Euler(0.0f,90.0f,0.0f);
						break;

					case enCellDir.West:

						rotation = Quaternion.Euler(0.0f,270.0f,0.0f);				
						break;					
				}
			break;

			case enCellType.StandardTrack:
				
				if(m_nrRails == 1)
				{
					if(m_trackDoorCount == 0) cellType = Random.Range(0, 2);
					else cellType = 0;
					m_StraightTrack = m_SingleTrack[cellType];
					cell.CellSize = enCellSize.Single;
					if (cellType == 0)
					{		
						cell.CellClass = enCellClass.SingleTrack;
					}
					else
					{
						cell.CellClass = enCellClass.SingleDoor;
						m_trackDoorCount = 4;
					}
					m_LHTile = m_SingleLHTrack;
				}
				else if(m_nrRails == 2)
				{
					if(m_trackDoorCount == 0) cellType = Random.Range(0, 2);
					else cellType = 0;
					m_StraightTrack = m_DoubleTrack[cellType];
					cell.CellSize = enCellSize.Double;
					if (cellType == 0)
					{
						cell.CellClass = enCellClass.DoubleTrack;
					}
					else
					{
						cell.CellClass = enCellClass.DoubleDoor;
						m_trackDoorCount = 4;
					}
					m_LHTile = m_DoubleLHTrack;
				}
				else if(m_nrRails == 3)
				{	
					m_nrRails = 2;
					m_StraightTrack = m_SplitTrack;
					cell.CellSize = enCellSize.Double;
					cell.CellClass = enCellClass.WyeOutTrack;
					m_LHTile = m_DoubleLHTrack;
				}
		
				else if(m_nrRails == 4)
				{	
					m_nrRails = 1;
					m_StraightTrack = m_SplitTrackRev;
					cell.CellSize = enCellSize.Single;
					cell.CellClass = enCellClass.WyeInTrack;
					m_LHTile = m_SingleLHTrack;
				}
				
				else if(m_nrRails == 5)
				{
					m_nrRails = 2;
					m_StraightTrack = m_CrossoverTrack;
					cell.CellSize = enCellSize.Double;
					cell.CellClass = enCellClass.CrossoverTrack;
					m_LHTile = m_DoubleLHTrack;
				}
				else if(m_nrRails == 6)
				{
					m_nrRails = 1;
					m_StraightTrack = m_FighterBay;
					cell.CellClass = enCellClass.FighterBay;
					cell.CellSize = enCellSize.Single;
					m_inCave = true;
				}
		
				else if(m_nrRails == 7)
				{
					m_nrRails = 6;
					m_StraightTrack = m_SingleEntrance;
					cell.CellClass = enCellClass.StationEntrance;
					cell.CellSize = enCellSize.Single;
				}
				else if(m_nrRails == 8)
				{
					m_nrRails = 7;
					m_StraightTrack = m_SingleOpen;
					cell.CellClass = enCellClass.OpenTrack;
					cell.CellSize = enCellSize.Single;
				}
		
				else if(m_nrRails == 9)
				{
					m_nrRails = 8;
					m_StraightTrack = m_SingleOpen;
					cell.CellClass = enCellClass.OpenTrack;
					cell.CellSize = enCellSize.Single;
				}
				else if(m_nrRails == 10)
				{
					m_nrRails = 9;
					m_StraightTrack = m_SingleOpen;
					cell.CellClass = enCellClass.OpenTrack;
					cell.CellSize = enCellSize.Single;
				}
				else if(m_nrRails == 11)
				{
					m_nrRails = 10;
					m_StraightTrack = m_SingleOpen;
					cell.CellClass = enCellClass.OpenTrack;
					cell.CellSize = enCellSize.Single;
				}
				else if(m_nrRails == 12)
				{
					m_nrRails = 11;
					m_StraightTrack = m_SingleOpen;
					cell.CellClass = enCellClass.OpenTrack;
					cell.CellSize = enCellSize.Single;
				}
			
				switch (cell.CellDirection)
				{
					case enCellDir.North:
					
						if (cell.NeighbourS != null) 
						{
							prefabToInstantiate = m_StraightTrack;	
							rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);				
						}

						if (cell.NeighbourW != null) // Direction Changes - West
						{
							prefabToInstantiate = m_LHTile;	
							cell.CellClass = enCellClass.TurnTrackL;
							rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);	
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
						}

						if (cell.NeighbourE != null) // East
						{
							prefabToInstantiate = m_LHTile;		
							cell.CellClass = enCellClass.TurnTrackR;
							rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);	
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
						}
					break;
					
					case enCellDir.South:
						
						if (cell.NeighbourN != null) 
						{
							prefabToInstantiate = m_StraightTrack;	
							rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);				
						}
				
						if (cell.NeighbourW != null) // Direction Changes - West
						{
							prefabToInstantiate = m_LHTile;	
							cell.CellClass = enCellClass.TurnTrackR;
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
							rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);		
						}
				
						if (cell.NeighbourE != null) // East
						{
							prefabToInstantiate = m_LHTile;		
							cell.CellClass = enCellClass.TurnTrackL;
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
							rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
						}
					break;
				
					case enCellDir.East:
						
						if (cell.NeighbourW != null) 
						{
							prefabToInstantiate = m_StraightTrack;	
							rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);				
						}

						if (cell.NeighbourS != null) 
						{
							prefabToInstantiate = m_LHTile;	
							cell.CellClass = enCellClass.TurnTrackR;
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
							rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);		//90
						}
								
						if (cell.NeighbourN != null) 
						{
							prefabToInstantiate = m_LHTile;	
							cell.CellClass = enCellClass.TurnTrackL;
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
							rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);		
						}
					break;

					case enCellDir.West:
						
						if (cell.NeighbourE != null) 
						{
							prefabToInstantiate = m_StraightTrack;	
							rotation = Quaternion.Euler(0.0f,270.0f,0.0f);				
						}

						if (cell.NeighbourS != null) 
						{
							prefabToInstantiate = m_LHTile;
							cell.CellClass = enCellClass.TurnTrackL;
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
							rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
						}	
						if (cell.NeighbourN != null) // new one
						{
							prefabToInstantiate = m_LHTile;
							cell.CellClass = enCellClass.TurnTrackR;
							m_trackTurnCount = 3;
							m_trackObstacleCount = 2;
							rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
						}	
						break;
				}
				break;				
		}
		
		if (prefabToInstantiate != null)
		{
			Transform newCellModel = PoolManager.Pools["Corridor"].Spawn(prefabToInstantiate.transform, cell.CellPosition, rotation);
			//GameObject newCellModel = (GameObject)Instantiate(prefabToInstantiate, cell.CellPosition, rotation);
			newCellModel.parent = this.transform;
			cell.CellModel = newCellModel.gameObject;
		}
	}
	
	// Is the provided cell a corner?
	private bool isCornerCell(stCell cell)
	{
		if (cell.CellDirection == enCellDir.North)
		{
			if (   cell.NeighbourE != null
				|| cell.NeighbourW != null 
				|| cell.NeighbourU != null 
				|| cell.NeighbourD != null) return true;
		}

		if (cell.CellDirection == enCellDir.East)
		{
			if (   cell.NeighbourN != null 
				|| cell.NeighbourS != null 
				|| cell.NeighbourU != null 
				|| cell.NeighbourD != null) return true;
		}

		if (cell.CellDirection == enCellDir.West)
		{
			if (   cell.NeighbourN != null 
				|| cell.NeighbourS != null 
				|| cell.NeighbourU != null 
				|| cell.NeighbourD != null) return true;
		}
		
		if (cell.CellDirection == enCellDir.South)
		{
			if  (  cell.NeighbourE != null 
				|| cell.NeighbourW != null 
				|| cell.NeighbourU != null 
				|| cell.NeighbourD != null) return true;
		}
		
		if (cell.CellDirection == enCellDir.Up)
		{
			if  (  cell.NeighbourN != null 
				|| cell.NeighbourS != null 
				|| cell.NeighbourE != null 
				|| cell.NeighbourW != null) return true;
		}
		
		if (cell.CellDirection == enCellDir.Down)
		{
			if  (  cell.NeighbourN != null 
				|| cell.NeighbourS != null 
				|| cell.NeighbourE != null 
				|| cell.NeighbourW != null) return true;
		}
		return false;
	}
	
	#endregion
	
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
	
	public void GameCenterReportAchievement(int achievementNr, float percentNr)
	{
		switch(achievementNr)
		{
			case 0:
				GameCenterBinding.reportAchievement("bigSpender", percentNr);
			break;
			case 1:
				GameCenterBinding.reportAchievement("rank_ensign", percentNr);
			break;
			case 2:
				GameCenterBinding.reportAchievement("rank_ltjg", percentNr);
			break;
			case 3:
				GameCenterBinding.reportAchievement("rank_lt", percentNr);
			break;
			case 4:
				GameCenterBinding.reportAchievement("rank_ltcmdr", percentNr);
			break;
			case 5:
				GameCenterBinding.reportAchievement("rank_cmdr", percentNr);
			break;
			case 6:
				GameCenterBinding.reportAchievement("captain", percentNr);
			break;
		}
	}
	
	private void GameCenterReportScore(int scoreType)
	{
		switch(scoreType)
		{
			case 0: 
				GameCenterBinding.reportScore(PlayerPrefs.GetInt("BestTime", 0), "bestTime");
			break;
			case 1:
				GameCenterBinding.reportScore(m_distanceRunBest, "bestDist");
			break;
			case 2:
				GameCenterBinding.reportScore(PlayerPrefs.GetInt("PlayerMissions", 0), "numberMissions");
			break;
			case 3:
				GameCenterBinding.reportScore(PlayerPrefs.GetInt("PlayerCoins", 0), "numParts");
			break;
			case 4:
				GameCenterBinding.reportScore(PlayerPrefs.GetInt("PlayerDist", 0), "totalDist");
			break;
		}		
	}
		
	#endregion
	
	private void GetMissionObjectives()
	{
		switch(m_playerRank)
		{
			case 0:
				m_missionObj1 = "Collect parts, energy and shields";
				m_missionObj2 = "Watch for the turns";
				m_missionObj3 = string.Empty;
			break;
			case 1:
				m_missionObj1 = "Collect parts, energy and shields";
				m_missionObj2 = "Watch for blocked corridors";
				m_missionObj3 = string.Empty;
			break;
			case 2:
				m_missionObj1 = "Collect parts, energy and shields";
				m_missionObj2 = "Avoid the seeking energy mines";
				m_missionObj3 = "Watch for blocked corridors";
			break;
			case 3:
				m_missionObj1 = "Collect parts, energy and shields";
				m_missionObj2 = "Avoid the seeking energy mines";
				m_missionObj3 = "Watch for blocked corridors";
			break;
			case 4:
				m_missionObj1 = "Collect parts, energy and shields";
				m_missionObj2 = "Avoid the seeking energy mines";
				m_missionObj3 = "Watch for blocked corridors";
			break;
			case 5:
				m_missionObj1 = "Federation piracy patrol";
				m_missionObj2 = "Ship captured";
				m_missionObj3 = "Hacked Mission Computer";
			break;
		}
	}
	
	private void SetPlayerData()
	{
		
		string medalName = string.Empty;
		for (int i = 0; i <=9; i++)
		{	
			medalName = "Medal" + i.ToString();
			PlayerPrefs.SetInt(medalName , m_medalAwarded[i]);
		}
		
		PlayerPrefs.SetInt("PlayerRankType", m_playerRank);
		PlayerPrefs.SetString("PlayerRank", m_rankName[m_playerRank]);
		PlayerPrefs.SetInt("PlayerMissions", m_playerMissions);
		PlayerPrefs.SetFloat ("MissionPercent", m_playerRankComplete);
		PlayerPrefs.SetInt("PlayerDist", m_playerTotalDist);	
		PlayerPrefs.SetInt("PlayerCoins", m_playerTotalParts);
		PlayerPrefs.SetInt("PlayerKills", m_playerTotalKills);
		PlayerPrefs.SetFloat("PlayerEngine", m_engineMultiplier);
		PlayerPrefs.GetInt("PlayerDecal", m_playerDecal);
		PlayerPrefs.GetInt ("PlayerGun", m_gunType);
		PlayerPrefs.GetInt ("PlayerCargo", m_cargoType);
		PlayerPrefs.GetInt ("PlayerMissile", m_missileType);
		PlayerPrefs.GetInt ("PlayerShield", m_shieldType);
	}
	
	private void CreateMissionHintsGUI()
	{
		MissionHintsGUI = (GameObject)Instantiate(MissionHintsPrefab, Vector3.zero, Quaternion.identity);
		MissionHintsGUI.name = "MissionHints";
		MissionHintsGUI.transform.parent = this.transform;
		MissionHintsGUI.transform.localPosition = new Vector3(150.0f, 80.0f, 0.0f);
		MissionHintsGUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
	
	private void CreateInGameGUI()
	{
		if(InGameGUI == null)
		{
			InGameGUI = (GameObject)Instantiate(InGameGUIPrefab, Vector3.zero, Quaternion.identity);
			InGameGUI.name = "InGameGUI";
			InGameGUI.transform.parent = this.transform;
			InGameGUI.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			InGameGUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateNextLevelButton()
	{
		if(NextLevelButton == null)
		{
			NextLevelButton = (GameObject)Instantiate(NextLevelButtonPrefab, Vector3.zero, Quaternion.identity);
			NextLevelButton.name = "NextLevelButton";
			//NextLevelButton.transform.parent = this.transform;
			NextLevelButton.transform.localPosition = new Vector3(-185.0f, -280.0f, 0.0f);
			NextLevelButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateExitButton()
	{
		if(ExitButton == null)
		{
			ExitButton = (GameObject)Instantiate(ExitButtonPrefab, Vector3.zero, Quaternion.identity);
			ExitButton.name = "ExitButton";
			//NextLevelButton.transform.parent = this.transform;
			ExitButton.transform.localPosition = new Vector3(-185.0f, -280.0f, 0.0f);
			ExitButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateRetryButton()
	{
		if(RetryButton == null)
		{
			RetryButton = (GameObject)Instantiate(RetryButtonPrefab, Vector3.zero, Quaternion.identity);
			RetryButton.name = "RetryButton";
			//NextLevelButton.transform.parent = this.transform;
			RetryButton.transform.localPosition = new Vector3(-185.0f, -280.0f, 0.0f);
			RetryButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateMissionReport()
	{
		if(MissionReport == null)
		{
			MissionReport = (GameObject)Instantiate(MissionReportPrefab, Vector3.zero, Quaternion.identity);
			MissionReport.name = "MissionReport";
			//NextLevelButton.transform.parent = this.transform;
			MissionReport.transform.localPosition = new Vector3(185.0f, -280.0f, 0.0f);
			MissionReport.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateJoystick()
	{
		if(PlayerPrefs.GetInt("InputType", 0) == 1)
		{
			Joystick = (GameObject)Instantiate(JoystickPrefab, Vector3.zero, Quaternion.identity);
			Joystick.name = "Joystick";
			Joystick.transform.parent = this.transform;
			Joystick.transform.localPosition = new Vector3(-185.0f, -280.0f, 0.0f);
			Joystick.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateFireButton()
	{
		if(FireButton == null)
		{
			FireButton = (GameObject)Instantiate(FireButtonPrefab, Vector3.zero, Quaternion.identity);
			FireButton.name = "FireButton";
			FireButton.transform.parent = this.transform;
			FireButton.transform.localPosition = new Vector3(185.0f, -270.0f, 0.0f);
			FireButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateMissileButton()
	{
		if(MissileButton == null)
		{
			MissileButton = (GameObject)Instantiate(MissileButtonPrefab, Vector3.zero, Quaternion.identity);
			MissileButton.name = "MissileButton";
			MissileButton.transform.parent = this.transform;
			MissileButton.transform.localPosition = new Vector3(185.0f, -270.0f, 0.0f);
			MissileButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	private void CreateSpeedControl()
	{
		if(SpeedControl == null)
		{
			SpeedControl = (GameObject)Instantiate(SpeedControlPrefab, Vector3.zero, Quaternion.identity);
			SpeedControl.name = "SpeedControl";
			SpeedControl.transform.parent = this.transform;
			SpeedControl.transform.localPosition = new Vector3(265.0f, -180.0f, 0.0f);
			SpeedControl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
}

