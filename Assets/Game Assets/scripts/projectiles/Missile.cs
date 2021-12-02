using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	private RangerWars grGlobals;
	
	public float mslTimer;
	public GameObject explosionPrefab;
	private GameObject explosion = null;
	public float mslSpeed = 0.0005f;
	private bool mslDestroyed = false;
	public GameObject target = null; 

	// Use this for initialization
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	// Use this for initialization
	void Start () 
	{
		 mslSpeed += grGlobals.m_playerVelocity;
		 mslTimer = Time.time + 1.5f; 
		 mslDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Time.deltaTime * mslSpeed * transform.forward;
		if(Time.time > mslTimer && !mslDestroyed)
		{
			OnDestroy();
		}
	}
	
	private void OnDestroy()
	{
		mslDestroyed = true;
		explosion = (GameObject) Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
	
	 private void OnCollisionEnter(Collision other) 
	 {
		if(other.gameObject.tag != "gameCollider" 
		&& other.gameObject.tag != "powerups" 
		&& other.gameObject.tag != "Player" 
		&& !mslDestroyed)
		{
			Debug.LogError(other.gameObject.name);
			OnDestroy();
		}
	}
}
