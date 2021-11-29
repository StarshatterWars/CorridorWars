using UnityEngine;
using System.Collections;

public class csFighterControl : MonoBehaviour {
	private csRangerWars grGlobals;
	public GameObject missilePrefab;
	
	public GameObject explosionPrefab;
	private bool shipDestroyed = false;
	private GameObject explosion = null;
	public float shipSpeed;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
	}
	// Use this for initialization
	void Start () 
	{
		 shipDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		shipSpeed = grGlobals.m_playerVelocity;
		
		if(grGlobals.m_playerMissileFire)
		{
			if(grGlobals.s_shipMissileCount > 0) 
			{
				grGlobals.s_shipMissileCount--;
				grGlobals.m_playerMissileFire = false;
				OnFireMissile();
			}
		}
	}
	
	private void OnFireMissile()
	{
		GameObject projectile = (GameObject) Instantiate (missilePrefab, transform.position, transform.rotation);
	}	
	
	private void OnCollisionEnter(Collision other) 
	 {
		if(!shipDestroyed)
		{
			if(other.gameObject.tag == "gameCollider" || other.gameObject.tag != "powerups" )
			{
				// no damage
			}
			
			else if(other.gameObject.tag == "wall") OnFighterDamage(50);
			else if(other.gameObject.tag == "missile") OnFighterDamage(25);
			//else if(other.gameObject.tag == "mine") OnFighterDamage(10);
		}
	}
	
	private void OnShipDestroy()
	{
		shipDestroyed = true;
		explosion = (GameObject) Instantiate (explosionPrefab, transform.position, transform.rotation);
		//explosion.name = "explosion";
		Destroy(this.gameObject);
	}
	
	private void OnFighterDamage(float amount)
	{
		grGlobals.s_primaryShield -= amount / 100.0f;
		if(grGlobals.s_primaryShield <= 0.0f) OnShipDestroy();	
	}
}
