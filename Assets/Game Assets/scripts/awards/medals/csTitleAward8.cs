using UnityEngine;
using System.Collections;

public class csTitleAward8 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Award #8",
		"Junior Award #8", 
		"Senior Award #8", 
		"Veteran Award #8",
		"Elite Award #8"
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[7]];
		if(grGlobals.gc_medalAwarded[7] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
