using UnityEngine;
using System.Collections;

public class csTitleAward9 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Award #9",
		"Junior Award #9", 
		"Senior Award #9", 
		"Veteran Award #9",
		"Elite Award #9"
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[8]];
		if(grGlobals.gc_medalAwarded[8] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
