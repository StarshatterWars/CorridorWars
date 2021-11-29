using UnityEngine;
using System.Collections;

public class csFireLaser : MonoBehaviour {
	private RangerWars grGlobals;
	public GameObject laserPrefab;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(grGlobals.m_playerLaserFire)
		{
			grGlobals.s_energyAvailable -= 0.03125f;
			grGlobals.m_playerLaserFire = false;
			OnFireLaser();
		}
	}
	
	private void OnFireLaser()
	{
		GameObject projectile = (GameObject) Instantiate (laserPrefab, transform.position, transform.rotation);
	}	
}
