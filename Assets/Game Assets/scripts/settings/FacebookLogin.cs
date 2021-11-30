using UnityEngine;
using System.Collections;

public class FacebookLogin : MonoBehaviour {
	public bool fb_loggedIn = false;
	public bool fb_loginFailed = false;
	
	private static string fb_AppID = "297788260333867";
	private string[] fb_readPermissions = new string[] { "email", "user_games_activity" };
	private string[] fb_publishPermissions = new string[] { "publish_stream", "photo_upload", "publish_actions" };
	private static string fb_AppSecret = "2fc16ecaf458f3cbc5cbe69737e7917f";
	private string fb_accessToken = string.Empty;
	
	public GameObject fb_publishBtn;
	public GameObject fb_postBtn;
	
	public bool fb_publishAccess = false;
	
	// Use this for initialization
	void Start () {
		#if UNITY_IPHONE
		FacebookBinding.init();
		#endif
	}
	
		// common event handler used for all graph requests that logs the data to the console
	void completionHandler( string error, object result )
	{
		if( error != null )
			Debug.LogError( error );
		else
			ResultLogger.logObject( result );
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_IPHONE
		fb_loggedIn = FacebookBinding.isSessionValid();
		
		if(fb_loggedIn)
		{
			if(fb_publishAccess)
			{
				fb_publishBtn.SetActive(false);
				fb_postBtn.SetActive(true);
			}
			else
			{
				fb_publishBtn.SetActive(true);
				fb_postBtn.SetActive(false);
			}
		}
		else
		{
			fb_publishBtn.SetActive(false);
			fb_postBtn.SetActive(false);
		}
		#endif
	}
	
	public void OnFacebookLogin() // login/out toggle
    {
		#if UNITY_IPHONE
		FacebookBinding.init();
		if (!fb_loggedIn)
        {
            FacebookBinding.loginWithReadPermissions( fb_readPermissions );
        }
        else
		{
            FacebookBinding.logout();
        }
		#endif
    }
	
	public void OnFacebookPublishMessage()
	{
		#if UNITY_IPHONE
		FacebookBinding.init( );
		if(fb_loggedIn && PlayerPrefs.GetInt("FacebookLogin", 0) == 1)
		{
			FacebookBinding.reauthorizeWithPublishPermissions( fb_publishPermissions, FacebookSessionDefaultAudience.OnlyMe );
		}
		#endif
	}
	
	public void OnFacebookPostMessage()
	{
		#if UNITY_IPHONE
		if(fb_loggedIn && PlayerPrefs.GetInt("FacebookLogin", 0) == 2)
		{
			Debug.LogError("OK can post");
		}
		#endif
	}
}
