using UnityEngine;
using System.Collections;

public class csTextAward1 : MonoBehaviour {
	private string[] medalTextType = new string[5] { 
		"Awarded to pilots collecting 1K, 5K, 25K and 125K parts",
		"Awarded to pilots that collect 1,000 parts. Next level: 5K parts collected.", 
		"Awarded to pilots that collect 5,000 parts. Next level: 25K parts collected.", 
		"Awarded to pilots that collect 25,000 parts. Next level: 125K parts collected.",
		"Awarded to pilots that collect 125,000 parts. "
	};

	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();

		medalText.text = medalTextType[grGlobals.gc_medalAwarded[0]];
		if(grGlobals.gc_medalAwarded[0] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = grGlobals.m_dbColorGood;
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
