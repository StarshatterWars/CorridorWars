using UnityEngine;
using System.Collections;

public class csTitleAward1 : MonoBehaviour {
	private string[] medalTitleType = new string[5] { 
		"Parts Collector",
		"Junior Parts Collector", 
		"Senior Parts Collector", 
		"Veteran Parts Collector",
		"Elite Parts Collector"
	};
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UILabel medalText = this.gameObject.GetComponent<UILabel>();
		medalText.text = medalTitleType[grGlobals.gc_medalAwarded[0]];
		if(grGlobals.gc_medalAwarded[0] >= grGlobals.d_rankDisplay) 
		{
			medalText.color = new Color(1.0f, 0.8f, 0.0f, 1.0f);
		}
		else
		{
			medalText.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
		}	
	}
}
