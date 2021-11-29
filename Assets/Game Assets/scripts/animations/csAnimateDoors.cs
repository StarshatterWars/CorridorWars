using UnityEngine;
using System.Collections;

public class csAnimateDoors : MonoBehaviour {
	private csRangerWars grGlobals;
	private bool m_animateDoors;
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
		this.gameObject.GetComponent<Animation>().Play("close");
		this.gameObject.GetComponent<Animation>().Rewind("open");
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(grGlobals.m_animateDoors)
		{
			grGlobals.m_animateDoors = false;
			if(this.gameObject.GetComponent<Animation>().IsPlaying("open"))
			{
				this.gameObject.GetComponent<Animation>().Stop("open");
			}
			this.gameObject.GetComponent<Animation>()["open"].speed = 1.5f;
			this.gameObject.GetComponent<Animation>().Play("open", PlayMode.StopAll);
			this.gameObject.GetComponent<Animation>().wrapMode = WrapMode.ClampForever;
		}
	}
}
