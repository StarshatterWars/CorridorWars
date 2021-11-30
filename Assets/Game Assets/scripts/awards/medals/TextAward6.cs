using UnityEngine;
using System.Collections;

public class TextAward6 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Award #6 at Rookie, Senior, Veteran and Elite Levels.",
		"Description of Rookie Award #6. Next level: Senior Award #6.", 
		"Description of Senior Award #6. Next level: Veteran Award #6.", 
		"Description of Veteran Award #6. Next level: Elite Award #6.",
		"Description of Elite Award #6."
	};
	
	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[5]];
		if(grGlobals.gc_medalAwarded[5] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
