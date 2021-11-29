using UnityEngine;
using System.Collections;

public class EntranceBar : MonoBehaviour {
	private RangerWars grGlobals;
	
	private Color colorStart = Color.white;
    private Color colorEnd = Color.red;
	private float duration = 1.0f;
	private float intensity = 2.0f;
	
	void Awake()
	{
		grGlobals = GameObject.Find("MainGame").GetComponent<RangerWars>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
        GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
