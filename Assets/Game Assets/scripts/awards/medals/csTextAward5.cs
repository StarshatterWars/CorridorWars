using UnityEngine;
using System.Collections;

public class csTextAward5 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Award #5 at Rookie, Senior, Veteran and Elite Levels.",
		"Description of Rookie Award #5. Next level: Senior Award #5.", 
		"Description of Senior Award #5. Next level: Veteran Award #5.", 
		"Description of Veteran Award #5. Next level: Elite Award #5.",
		"Description of Elite Award #5."
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[4]];
		if(grGlobals.gc_medalAwarded[4] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
