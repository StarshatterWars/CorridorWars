using UnityEngine;
using System.Collections;

public class csAboutScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void UnloadAboutScreen()
	{
		if(GameObject.Find("MissionObjectivesGUI")) 
		{
			GameObject missobjGUIMM = GameObject.Find("MissionObjectivesGUI");
			missobjGUIMM.transform.localPosition = new Vector3(100.0f, 160.0f, 0.0f);
		}
	}
	
	public void OnAboutButton()
	{
		csMainMenu grGlobals = GameObject.Find("MenuManager").GetComponent<csMainMenu>();
		grGlobals.aboutScreenActivate = true;
	}
}
