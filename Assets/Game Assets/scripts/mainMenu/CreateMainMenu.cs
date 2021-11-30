using UnityEngine;
using System.Collections;

public class CreateMainMenu : MonoBehaviour {
	public GameObject TitleGUIPrefab;
	private GameObject TitleGUI;
	
	public GameObject MissionLogPrefab;
	private GameObject MissionLogGUI;
	
	public GameObject PlayButtonPrefab;
	private GameObject PlayButton;
		
	public GameObject AboutButtonPrefab;
	private GameObject AboutButton;
	
	public GameObject SettingsButtonPrefab;
	private GameObject SettingsButton;
	
	public GameObject ProfileButtonPrefab;
	private GameObject ProfileButton;
	
	public GameObject HangerButtonPrefab;
	private GameObject HangerButton;
	
	// Use this for initialization
	void Start () {
		CreateElements ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void CreateElements()
	{
		//if(!GameObject.Find("TitleGUI")) 
		//{
			TitleGUI = (GameObject)Instantiate(TitleGUIPrefab, Vector3.zero, Quaternion.identity);
			TitleGUI.name = "TitleGUI";
			TitleGUI.transform.parent = this.transform;
			TitleGUI.transform.localPosition = new Vector3(-120.0f, 280.0f, 0.0f);
		//}
		
		//if(!GameObject.Find("MissionObjectivesGUI")) 
		//{
			MissionLogGUI = (GameObject)Instantiate(MissionLogPrefab, Vector3.zero, Quaternion.identity);
			MissionLogGUI.name = "MissionObjectivesGUI";
			MissionLogGUI.transform.parent = this.transform;
			MissionLogGUI.transform.localPosition = new Vector3(50.0f, 160.0f, 0.0f);
		//}
		
		//if(!GameObject.Find("PlayButtonGUI")) 
		//{
			PlayButton = (GameObject)Instantiate(PlayButtonPrefab, Vector3.zero, Quaternion.identity);
			PlayButton.name = "PlayButtonGUI";
			PlayButton.transform.parent = this.transform;
			PlayButton.transform.localPosition = new Vector3(187.5f, -285.0f, 0.0f);
			PlayButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		//}
		//if(!GameObject.Find("SettingsButton")) 
		//{
			SettingsButton = (GameObject)Instantiate(SettingsButtonPrefab, Vector3.zero, Quaternion.identity);
			SettingsButton.name = "SettingsButton";
			SettingsButton.transform.parent = this.transform;
			SettingsButton.transform.localPosition = new Vector3(200.0f, -150.0f, 0.0f);
			SettingsButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		//}
		//if(!GameObject.Find("ProfileButton")) 
		//{
			ProfileButton = (GameObject)Instantiate(ProfileButtonPrefab, Vector3.zero, Quaternion.identity);
			ProfileButton.name = "ProfileButton";
			ProfileButton.transform.parent = this.transform;
			ProfileButton.transform.localPosition = new Vector3(200.0f, -90.0f, 0.0f);
			ProfileButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		//}
		//if(!GameObject.Find("HangerButton")) 
		//{
			HangerButton = (GameObject)Instantiate(HangerButtonPrefab, Vector3.zero, Quaternion.identity);
			HangerButton.name = "HangerButton";
			HangerButton.transform.parent = this.transform;
			HangerButton.transform.localPosition = new Vector3(200.0f, -30.0f, 0.0f);
			HangerButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		//}
		//if(!GameObject.Find("AboutButton")) 
		//{
			AboutButton = (GameObject)Instantiate(AboutButtonPrefab, Vector3.zero, Quaternion.identity);
			AboutButton.name = "AboutButton";
			AboutButton.transform.parent = this.transform;
			AboutButton.transform.localPosition = new Vector3(200.0f, 30.0f, 0.0f);
			AboutButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		//}
	}
}
