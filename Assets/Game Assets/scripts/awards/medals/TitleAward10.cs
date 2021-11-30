using UnityEngine;
using System.Collections;

public class TitleAward10 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Award #10",
		"Junior Award #10", 
		"Senior Award #10", 
		"Veteran Award #10",
		"Elite Award #10"
	};

	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[9]];
		if(grGlobals.gc_medalAwarded[9] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
