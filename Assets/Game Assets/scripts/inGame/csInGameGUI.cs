using UnityEngine;
using System.Collections;

public class csInGameGUI : MonoBehaviour {
	public GameObject PlayerStatsGUIPrefab;
	private GameObject PlayerStatsGUI;
	
	public GameObject MFDHudGUIPrefab;
	private GameObject MFDHudGUI;
	
	public GameObject ShieldGUIPrefab;
	private GameObject ShieldGUI;
	
	public GameObject GameMusicPrefab;
	private GameObject GameMusic;
	
	public GameObject GameSoundsPrefab;
	private GameObject GameSounds;
	
	public GameObject CrosshairPrefab;
	private GameObject Crosshair;
	
	public GameObject TargeterPrefab;
	private GameObject Targeter;
	
	//public GameObject VCControllerPrefab;
	//private GameObject VCController;
	
	private csRangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		CreateElements ();
	}
	
	// Update is called once per frame
	void Update () {
		Targeter.SetActive(grGlobals.m_targetLocked);
	}
	
	private void CreateElements()
	{
		PlayerStatsGUI = (GameObject)Instantiate(PlayerStatsGUIPrefab, Vector3.zero, Quaternion.identity);
		PlayerStatsGUI.name = "PlayerStats";
		PlayerStatsGUI.transform.parent = this.transform;
		PlayerStatsGUI.transform.localPosition = new Vector3(156.25f, 0.0f, 0.0f);
		PlayerStatsGUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		MFDHudGUI = (GameObject)Instantiate(MFDHudGUIPrefab, Vector3.zero, Quaternion.identity);
		MFDHudGUI.name = "MFDHudDisplay";
		MFDHudGUI.transform.parent = this.transform;
		MFDHudGUI.transform.localPosition = new Vector3(0.0f, -270.0f, 0.0f);
		MFDHudGUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		ShieldGUI = (GameObject)Instantiate(ShieldGUIPrefab, Vector3.zero, Quaternion.identity);
		ShieldGUI.name = "Shields";
		ShieldGUI.transform.parent = this.transform;
		ShieldGUI.transform.localPosition = new Vector3(0.0f, -270.0f, 0.0f);
		ShieldGUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		GameMusic = (GameObject)Instantiate(GameMusicPrefab, Vector3.zero, Quaternion.identity);
		GameMusic.name = "GameMusic";
		GameMusic.transform.parent = this.transform;
		GameMusic.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
		GameMusic.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		GameSounds = (GameObject)Instantiate(GameSoundsPrefab, Vector3.zero, Quaternion.identity);
		GameSounds.name = "GameSounds";
		GameSounds.transform.parent = this.transform;
		GameSounds.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
		GameSounds.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		Crosshair = (GameObject)Instantiate(CrosshairPrefab, Vector3.zero, Quaternion.identity);
		Crosshair.name = "Crosshair";
		Crosshair.transform.parent = this.transform;
		Crosshair.transform.localPosition = new Vector3(260.4f, 0.0f, 0.0f);
		Crosshair.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		Targeter = (GameObject)Instantiate(TargeterPrefab, Vector3.zero, Quaternion.identity);
		Targeter.name = "Targeter";
		Targeter.transform.parent = this.transform;
		Targeter.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
		Targeter.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		
		//VCController = (GameObject)Instantiate(VCControllerPrefab, Vector3.zero, Quaternion.identity);
		//VCController.name = "VCController";
		//VCController.transform.parent = this.transform;
		//VCController.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
		//VCController.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
}
