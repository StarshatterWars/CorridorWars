using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	private RangerWars grGlobals;
	private Vector3 normalPosition  = new Vector3(260.4f, -00.0f, 0.0f);
	private Vector3 crossHairPosition = Vector3.zero;
	private float height = 0.0f;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
		this.transform.localPosition = normalPosition;
		crossHairPosition = new Vector3(260.4f, 25.0f, 0.0f);
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		crossHairPosition.y = 25.0f;
		
		if(grGlobals.m_displayTilt <= 0.005f)
		{
			crossHairPosition.y = grGlobals.m_displayTilt * -100.0f + 25.0f;
			if(crossHairPosition.y >= 75.0) crossHairPosition.y = 75.0f;
			
		}
		else if( grGlobals.m_displayTilt >= 0.005f)
		{
			crossHairPosition.y = grGlobals.m_displayTilt * -600.0f + 25.0f;
			if (crossHairPosition.y <= -275.0) crossHairPosition.y = -275.0f;
		}
		this.transform.localPosition = crossHairPosition;
	}
}
