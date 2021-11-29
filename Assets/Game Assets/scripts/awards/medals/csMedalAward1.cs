using UnityEngine;
using System.Collections;

public class csMedalAward1 : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		csProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<csProfileScreen>();
		UISprite medalPic = this.gameObject.GetComponent<UISprite>();
		if(grGlobals.gc_medalAwarded[0] >= grGlobals.d_rankDisplay) 
		{
			medalPic.spriteName = grGlobals.medalPicType[grGlobals.gc_medalAwarded[0] + 3];	
		}
		else
		{
			medalPic.spriteName = grGlobals.medalPicType[grGlobals.d_rankDisplay - 1];	
		}	
	}
}
