using UnityEngine;
using System.Collections;

public class TitleAward7 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Award #7",
		"Junior Award #7", 
		"Senior Award #7", 
		"Veteran Award #7",
		"Elite Award #7"
	};
	
	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[6]];
		if(grGlobals.gc_medalAwarded[6] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
