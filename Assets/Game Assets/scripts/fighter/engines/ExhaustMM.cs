using UnityEngine;
using System.Collections;

public class ExhaustMM : MonoBehaviour {
	public float exhaustVelocity = -0.1f;
	private MoveShipMM ship;
	
	void Awake()
	{
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ship = GameObject.Find("PlayerShip").GetComponent<MoveShipMM>();
		//GetComponent<ParticleEmitter>().localVelocity = new Vector3(0.0f, 0.0f, -ship.shipSpeed/100.0f);
		//GetComponent<ParticleEmitter>().maxEmission =  ship.shipSpeed * 60.0f;
	}
}
