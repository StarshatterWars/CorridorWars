using UnityEngine;
using System.Collections;


public class ExhaustGame : MonoBehaviour {
	public float exhaustVelocity;
	private RangerWars grGlobals;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		exhaustVelocity = -grGlobals.m_playerVelocity / 2.0f; //exhaustVelocity 
		if(grGlobals.m_playerVelocity > 0.005)
		{
			//GetComponent<ParticleEmitter>().localVelocity = new Vector3(0.0f, 0.0f, exhaustVelocity);
			//GetComponent<ParticleEmitter>().maxEmission =  grGlobals.m_playerVelocity * 300.0f;
			//GetComponent<ParticleEmitter>().enabled = true;
			//GetComponent<Renderer>().enabled = true;
		}
		else
		{
			//GetComponent<ParticleEmitter>().enabled = false;
			//GetComponent<Renderer>().enabled = false;
		}
	}
}
