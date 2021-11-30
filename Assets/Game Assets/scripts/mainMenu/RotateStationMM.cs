using UnityEngine;
using System.Collections;

public class RotateStationMM : MonoBehaviour {
	private MainMenu grGlobals;
	public GameObject shipPrefab;
	private GameObject m_player;
	private bool m_playerCreated = false;
	public int numberFighters = 6;
	private float waitTime = 0.0f;
	
	// Use this for initializatio
	void Awake()
	{
		grGlobals = GameObject.Find("MenuManager").GetComponent<MainMenu>();
		m_playerCreated = false;
		numberFighters = 0;
	}
	
	// Use this for initialization
	void Start ()
	{
		transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 235.0f, 0.0f));
	}
	
	private void MakePlayer()
	{
		//if(!m_playerCreated)
		//{
			m_player = (GameObject)Instantiate(shipPrefab, this.transform.position, Quaternion.identity);
			m_player.name = "PlayerShip";
			//m_player.transform.parent = this.transform;
			m_playerCreated = true;
			Destroy(m_player, 5);
		//}
	}
	
	// Update is called once per frame
	void Update () {
	  	transform.Rotate(Vector3.right * Time.deltaTime * 2.0f);
		if(grGlobals.m_playGame && numberFighters < 6 && Time.time > waitTime)
		{
			MakePlayer ();
			numberFighters++;
			waitTime = Time.time + 0.5f;
		}
	}
}
