using UnityEngine;
using System.Collections;

public class csTextAward2 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Awarded to pilots at 5K, 25K, 125K and 625K meters",
		"Awarded to pilots that pass 5,000 meters.  Next level: 25K meters.", 
		"Awarded to pilots that pass 25,000 meters. Next level: 125K meters.", 
		"Awarded to pilots that pass 125,000 meters. Next level: 625K meters.",
		"Awarded to pilots that pass 625,000 meters."
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();

		medalText.text = medalTextType[grGlobals.gc_medalAwarded[1]];
		if(grGlobals.gc_medalAwarded[1] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
