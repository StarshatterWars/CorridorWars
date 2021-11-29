using UnityEngine;
using System.Collections;

public class csTitleAward2 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Corridor Traveller",
		"Junior Corridor Traveller", 
		"Senior Corridor Traveller", 
		"Veteran Corridor Traveller",
		"Elite Corridor Traveller"
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[1]];
		if(grGlobals.gc_medalAwarded[1] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
