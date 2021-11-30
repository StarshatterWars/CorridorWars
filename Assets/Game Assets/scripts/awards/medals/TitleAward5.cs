using UnityEngine;
using System.Collections;

public class TitleAward5 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Award #5",
		"Junior Award #5", 
		"Senior Award #5", 
		"Veteran Award #5",
		"Elite Award #5"
	};

	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[4]];
		if(grGlobals.gc_medalAwarded[4] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
