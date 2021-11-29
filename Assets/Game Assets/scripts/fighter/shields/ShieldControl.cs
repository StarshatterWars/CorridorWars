using UnityEngine;
using System.Collections;

public class ShieldControl : MonoBehaviour {
	private RangerWars grGlobals;
	
	// Shields
	public GameObject shieldGUI;
	public GameObject priShield;
	public GameObject priShieldA;
	public GameObject priShieldB;
	public	GameObject fwdHalfShield;
	public GameObject aftHalfShield;
	public GameObject fwdShield;
	public GameObject aftShield;
	public GameObject prtShield;
	public GameObject stbShield;
	
	private int m_shieldType;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
		m_shieldType = PlayerPrefs.GetInt ("PlayerShield", 0);
		shieldGUI.SetActive(false);
		SetShields ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShields();
	}
	
	private void SetShields()
	{
		if(m_shieldType == 0)
		{
			priShield.SetActive(true);
		}
		else if(m_shieldType == 1)
		{
			priShieldA.SetActive(false);
			priShieldB.SetActive(false);
		}
		else if(m_shieldType == 2)
		{
			priShield.SetActive(true);
			fwdHalfShield.SetActive(true);
			aftHalfShield.SetActive(true);
		}
		else if(m_shieldType == 3)
		{
			priShield.SetActive(true);
			fwdShield.SetActive(true);
			aftShield.SetActive(true);
			prtShield.SetActive(true);
			stbShield.SetActive(true);
		}
	}
	
	private void UpdateShields()
	{
		
	}
}
