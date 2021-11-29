using UnityEngine;
using System.Collections;

public class csTextAward10 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Award #10 at Rookie, Senior, Veteran and Elite Levels.",
		"Description of Rookie Award #10. Next level: Senior Award #10.", 
		"Description of Senior Award #10. Next level: Veteran Award #10.", 
		"Description of Veteran Award #10. Next level: Elite Award #10.",
		"Description of Elite Award #10."
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[9]];
		if(grGlobals.gc_medalAwarded[9] == grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
