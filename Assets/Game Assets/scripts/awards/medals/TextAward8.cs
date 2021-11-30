using UnityEngine;
using System.Collections;

public class TextAward8 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Award #8 at Rookie, Senior, Veteran and Elite Levels.",
		"Description of Rookie Award #8. Next level: Senior Award #8.", 
		"Description of Senior Award #8. Next level: Veteran Award #8.", 
		"Description of Veteran Award #8. Next level: Elite Award #8.",
		"Description of Elite Award #8."
	};

	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[7]];
		if(grGlobals.gc_medalAwarded[7] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
