using UnityEngine;
using System.Collections;

public class csTextAward3 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Awarded to pilots at 30, 90, 270 and 810 missions completed.",
		"Awarded to pilots that complete a total of 30 missions. Next level: 90 missions completed.", 
		"Awarded to pilots that complete a total of 90 missions. Next level: 270 missions completed.", 
		"Awarded to pilots that complete a total of 270 missions. Next level: 810 missions completed.",
		"Awarded to pilots that complete a total of 810 missions."
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		
		medalText.text = medalTextType[grGlobals.gc_medalAwarded[2]];
		if(grGlobals.gc_medalAwarded[2] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
