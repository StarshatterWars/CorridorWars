using UnityEngine;
using System.Collections;

public class csTextAward7 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Award #7 at Rookie, Senior, Veteran and Elite Levels.",
		"Description of Rookie Award #7. Next level: Senior Award #7.", 
		"Description of Senior Award #7. Next level: Veteran Award #7.", 
		"Description of Veteran Award #7. Next level: Elite Award #7.",
		"Description of Elite Award #7."
	};
		
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[6]];
		if(grGlobals.gc_medalAwarded[6] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
