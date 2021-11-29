using UnityEngine;
using System.Collections;

public class csEnergyMine : MonoBehaviour {
	private csRangerWars grGlobals;
	
	// Use this for initialization
	public float mineDamage = 10f;
	private GameObject explosion = null;
	public GameObject explosionPrefab;
	private bool mineDestroyed = false;
	public float mineSpeed = 1f;
	public int mineType;
	public float mineTimer;
	public GameObject target = null; 
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<csRangerWars>();
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target != null)
		{	
			transform.LookAt(target.transform);
		}
		
		transform.Translate(Vector3.forward * mineSpeed * Time.deltaTime);
	}
	
	private void OnDestroy()
	{
		mineDestroyed = true;
		explosion = (GameObject) Instantiate (explosionPrefab, transform.position, transform.rotation);
		//explosion.name = "explosion";
		Destroy(this.gameObject);
	}
	
	private void OnCollisionEnter(Collision other) 
	 {
		if(other.gameObject.tag != "gameCollider" 
		&& other.gameObject.tag != "mine" 
		&& other.gameObject.tag != "Player" 
		)
		{
			Debug.LogError(other.gameObject.name);
			//OnDestroy();
		}
	}
}
