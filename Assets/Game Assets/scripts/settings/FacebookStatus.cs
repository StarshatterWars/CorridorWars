using UnityEngine;
using System.Collections;

public class FacebookStatus : MonoBehaviour {
		
	// Use this for initialization
	void Start () {
		UILabel gameFBStatus = this.gameObject.GetComponent<UILabel>();
		gameFBStatus.text = "Logged Out";
		gameFBStatus.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {

		SettingsScreen grGlobals = GameObject.Find("SettingsScreen").GetComponent<SettingsScreen>();
		UILabel gameFBStatus = this.gameObject.GetComponent<UILabel>();
		#if UNITY_IPHONE
		if(FacebookBinding.isSessionValid())
		{
			if(!grGlobals.fb_publishAccess)
			{
				gameFBStatus.text = "Allow to\nPublish";
				gameFBStatus.color = Color.yellow;
			}
			else
			{
				gameFBStatus.text = "Post\nMessage";
				gameFBStatus.color = Color.green;
			}
		}
		else
		{
			gameFBStatus.text = "Logged Out";
			gameFBStatus.color = Color.red;
		}
		#endif
	}
}
