using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public IEnumerator OnPlayGame()
	{
		MainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		grGlobals.m_playGame = true;
		grGlobals.DisplayLoadingMissionScreen();
		DeactivateMainMenu();
		yield return new WaitForSeconds(8);
		Application.LoadLevelAsync("MissionLoading");
	}
	
	private void DeactivateMainMenu()
	{
		if(GameObject.Find("TitleGUI")) 
		{
			GameObject titleGUIMM = GameObject.Find("TitleGUI");
			Destroy (titleGUIMM);
		}
		
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			Destroy (missobjGUIMM);
		}
				
		if(GameObject.Find("SettingsButton")) 
		{
			GameObject menuButtonA = GameObject.Find("SettingsButton");
			Destroy (menuButtonA);
		}
		
		if(GameObject.Find("ProfileButton")) 
		{
			GameObject menuButtonB = GameObject.Find("ProfileButton");
			Destroy (menuButtonB);
		}
		
		if(GameObject.Find("HangerButton")) 
		{
			GameObject menuButtonC = GameObject.Find("HangerButton");
			Destroy (menuButtonC);
		}
		
		if(GameObject.Find("AboutButton")) 
		{
			GameObject menuButtonD = GameObject.Find("AboutButton");
			Destroy (menuButtonD);
		}
	}
}
