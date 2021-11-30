using UnityEngine;
using System.Collections;

public class TitleAward6 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Award #6",
		"Junior Award #6", 
		"Senior Award #6", 
		"Veteran Award #6",
		"Elite Award #6"
	};

	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[5]];
		if(grGlobals.gc_medalAwarded[5] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
