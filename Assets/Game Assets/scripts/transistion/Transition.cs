using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {
	private MissionLoading grGlobals;
	public float shipSpeed;
	public string shipName;
	public GameObject warpPrefab;
	private GameObject warpEffect;
	private bool m_WarpCreated = false;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MissionLoading").GetComponent<MissionLoading>();
		if(this.gameObject.name == "1") DontDestroyOnLoad(this.gameObject); 
	}
	
	// Use this for initialization
	void Start () {
		transform.localRotation = Quaternion.Euler(new Vector3(340.0f, 0.0f, 0.0f));
		shipName = transform.name;
		shipSpeed = grGlobals.shipSpeed[int.Parse(shipName) - 1];
		m_WarpCreated = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(int.Parse(shipName) > 1) 
		{
			shipSpeed += 0.025f;
			transform.position += Time.deltaTime * shipSpeed * transform.forward;
		}
		
		if(shipSpeed > 0.5f)
		{
			MakeWarpEffect();
			Destroy(this.gameObject);
		}
		transform.Rotate(0.077f, 0.0f, 0.0f);
		if(transform.rotation.x > 359.9f) transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
	}
	
	private void MakeWarpEffect()
	{
		if(!m_WarpCreated)
		{
			warpEffect = (GameObject)Instantiate(warpPrefab, this.transform.position, Quaternion.identity);
			warpEffect.name = "WarpEffect";
			m_WarpCreated = true;
			Destroy(warpEffect, 5);
		}
	}
}
