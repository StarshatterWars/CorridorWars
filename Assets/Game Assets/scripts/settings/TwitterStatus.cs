using UnityEngine;
using System.Collections;

public class TwitterStatus : MonoBehaviour {
	private MainMenu grGlobals;
	// Use this for initialization
	
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
	}
	
	// Use this for initialization
	void Start () {
		UILabel gameTWStatus = this.gameObject.GetComponent<UILabel>();
		gameTWStatus.text = "Logged Out";
		gameTWStatus.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_IPHONE
		UILabel gameTWStatus = this.gameObject.GetComponent<UILabel>();
		if(TwitterBinding.isLoggedIn())
		{
			gameTWStatus.text = "Logged In";
			gameTWStatus.color = Color.green;
		}
		else
		{
			gameTWStatus.text = "Logged Out";
			gameTWStatus.color = Color.red;
		}
		#endif
	}
}
