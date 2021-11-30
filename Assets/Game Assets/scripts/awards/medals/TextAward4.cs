using UnityEngine;
using System.Collections;

public class TextAward4 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Awarded to pilots at 25, 100, 400 and 1600 drones killed.",
		"Awarded to pilots that kill 25 enemy drones. Next level: 100 drones killed.", 
		"Awarded to pilots that kill 100 enemy drones. Next level: 400 drones killed.", 
		"Awarded to pilots that kill 400 enemy drones. Next level: 1600 drones killed.",
		"Awarded to pilots that kill 1600 enemy drones." 
	};
	
	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[3]];
		if(grGlobals.gc_medalAwarded[3] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
