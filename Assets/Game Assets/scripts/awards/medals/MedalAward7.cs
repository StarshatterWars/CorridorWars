using UnityEngine;
using System.Collections;

public class MedalAward7 : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		ProfileScreen grGlobals = GameObject.Find("ProfileScreen").GetComponent<ProfileScreen>();
		UISprite medalPic = this.gameObject.GetComponent<UISprite>();
		if(grGlobals.gc_medalAwarded[6] >= grGlobals.d_rankDisplay) 
		{
			medalPic.spriteName = grGlobals.medalPicType[grGlobals.gc_medalAwarded[6] + 3];	
		}
		else
		{
			medalPic.spriteName = grGlobals.medalPicType[grGlobals.d_rankDisplay - 1];	
		}	
	}
}
