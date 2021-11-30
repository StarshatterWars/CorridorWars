using UnityEngine;
using System.Collections;
using Prime31;

public class SettingsScreen : MonoBehaviour {
	
	public GameObject settingsShipPrefab;
	private GameObject SettingsShip;
	
	public GameObject shipPanel;
	public GameObject shipLogo;
	
	//Input
	public int i_inputType = 0; 
	public float i_sensitivity = 0.5f;
	
	// Sound Setup
	public float m_soundVolume = 1.0f;
	public float m_musicVolume = 1.0f;
	public int m_paintShopButton = 0;
	public int m_paintShopOld = 0;
	public bool m_colorButtonChangeR = false;
	public bool m_colorButtonChangeG = false;
	public bool m_colorButtonChangeB = false;
	
	//Player Setup
	public int m_playerSex;
	public int m_playerDecal = 0;
	public float m_engineMultiplier = 1.0f;
	public int m_missileType = 0;
	public int m_shieldType = 0;
	public int m_cargoType = 0;
	public int m_gunType = 0;
	
	// Facebook Setup
	public bool fb_loggedIn = false;
	public bool fb_loginFailed = false;
	private string[] fb_readPermissions = new string[] { "email", "user_games_activity" };
	private string[] fb_publishPermissions = new string[] { "publish_stream", "photo_upload", "publish_actions" };
	private static string fb_AppID = "297788260333867";
	private static string fb_AppSecret = "2fc16ecaf458f3cbc5cbe69737e7917f";
	private string fb_accessToken = string.Empty;
	public bool fb_publishAccess = false;
		
	public GameObject fb_publishBtn;
	public GameObject fb_postBtn;
	
	// Use this for initialization
	void Start () {
		LoadGameSettings();
		LoadSettingsShip();
		InitializeFacebook();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_IPHONE
		fb_loggedIn = FacebookBinding.isSessionValid();
		
		if(fb_loggedIn)
		{
			if(fb_publishAccess)
			{
				fb_publishBtn.SetActive(false);
				fb_postBtn.SetActive(true);
			}
			else
			{
				fb_publishBtn.SetActive(true);
				fb_postBtn.SetActive(false);
			}
		}
		else
		{
			fb_publishBtn.SetActive(false);
			fb_postBtn.SetActive(false);
		}
		if(m_paintShopOld != m_paintShopButton)
		{
			m_colorButtonChangeR = true;
			m_colorButtonChangeG = true;
			m_colorButtonChangeB = true;
			m_paintShopOld = m_paintShopButton;
		}
		#endif
	}
	
	private void SelectCharacterMale()
	{
		m_playerSex = 1;
		PlayerPrefs.SetInt("PlayerSex", m_playerSex);
	}
	
	private void SelectCharacterFemale()
	{
		m_playerSex = 2;
		PlayerPrefs.SetInt("PlayerSex", m_playerSex);
	}
	
	public void OnUseTilt()
	{
		i_inputType = 0;
		PlayerPrefs.SetInt("InputType", 0);
	}
	
	public void OnUseJoypad()
	{
		i_inputType = 1;
		PlayerPrefs.SetInt("InputType", 1);
	}
	
	public void OnSetMusicVolume()
	{
		
	}
	
	public void OnSetSoundVolume()
	{
		
	}
	
	public void UnloadSettingsScreen()
	{
		MainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		if(GameObject.Find("SettingsScreen")) 
		{
			GameObject SScreenGO = GameObject.Find("SettingsScreen");
			Destroy(SScreenGO);
		}
		
		if(GameObject.Find("SettingsShip")) 
		{
			GameObject SShipGO = GameObject.Find("SettingsShip");
			Destroy(SShipGO);
		}
		
		if(GameObject.Find("PlayButtonGUI")) 
		{
			GameObject playButton = GameObject.Find("PlayButtonGUI");
			playButton.SetActiveRecursively(true);
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
		grGlobals.reanimateMenu = true;
		grGlobals.reanimateMissionObj = true;
	}
	
	private void LoadGameSettings()
	{
		i_inputType = PlayerPrefs.GetInt("InputType", 0);
		i_sensitivity  = PlayerPrefs.GetFloat("InputSensitivity", 0.50f);
		m_playerSex = PlayerPrefs.GetInt("PlayerSex", 0);	
		m_musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);	
		m_soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
		m_playerDecal = PlayerPrefs.GetInt("PlayerDecal", 0);
		m_engineMultiplier = PlayerPrefs.GetFloat("PlayerEngine", 1.0f);
		m_gunType = PlayerPrefs.GetInt ("PlayerGun", 0);
		m_cargoType = PlayerPrefs.GetInt ("PlayerCargo", 0);
		m_missileType = PlayerPrefs.GetInt ("PlayerMissile", 0);
		m_shieldType = PlayerPrefs.GetInt ("PlayerShield", 0);
		
		m_paintShopOld= 0;
		//shipPanel.SetActiveRecursively(true);
		shipLogo.SetActive(false);
		m_colorButtonChangeR = false;
		m_colorButtonChangeG = false;
		m_colorButtonChangeB = false;

	}
	
	
	public void LoadSettingsShip()
	{
		SettingsShip = (GameObject)Instantiate(settingsShipPrefab, new Vector3(-0.44f, 0.20f, 2.15f), Quaternion.identity);
		SettingsShip.transform.localScale = new Vector3(0.012f, 0.0126f, 0.012f);
		SettingsShip.name = "SettingsShip";
	}
	
	// common event handler used for all graph requests that logs the data to the console
	void completionHandler( string error, object result )
	{
		if( error != null )
			Debug.LogError( error );
		else
			ResultLogger.logObject( result );
	}
	
	private void InitializeFacebook()
	{
		#if UNITY_IPHONE
		FacebookBinding.init();
		#endif
	}
	
	public void OnFacebookLogin() // login/out toggle
    {
		#if UNITY_IPHONE
		FacebookBinding.init();
	
		if (!fb_loggedIn)
        {
            FacebookBinding.loginWithReadPermissions( fb_readPermissions );
        }
        else
        {
             FacebookBinding.logout();
        }
		#endif
    }
	
	public void OnFacebookPublishMessage()
	{
		#if UNITY_IPHONE
		FacebookBinding.init();
		if(fb_loggedIn && PlayerPrefs.GetInt("FacebookLogin", 0) == 1)
		{
			FacebookBinding.reauthorizeWithPublishPermissions( fb_publishPermissions, FacebookSessionDefaultAudience.OnlyMe );
		}
		#endif
	}
	
	public void OnFacebookPostMessage()
	{
		#if UNITY_IPHONE
		if(fb_loggedIn && PlayerPrefs.GetInt("FacebookLogin", 0) == 2)
		{
			Debug.LogError("OK can post");
		}
		#endif
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
	
	public void SetShipColor()
	{
		m_paintShopButton = 0;
		//shipPanel.SetActiveRecursively(true);
		shipLogo.SetActive(false);
	}
	
	public void SetLogoColor()
	{
		m_paintShopButton = 1;
		//shipPanel.SetActiveRecursively(false);
		shipLogo.SetActive(true);
	}
}
