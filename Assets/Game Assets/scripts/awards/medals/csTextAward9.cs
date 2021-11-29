using UnityEngine;
using System.Collections;

public class csTextAward9 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Award #9 at Rookie, Senior, Veteran and Elite Levels.",
		"Description of Rookie Award #9. Next level: Senior Award #9.", 
		"Description of Senior Award #9. Next level: Veteran Award #9.", 
		"Description of Veteran Award #9. Next level: Elite Award #9.",
		"Description of Elite Award #9."
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[8]];
		if(grGlobals.gc_medalAwarded[8] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
