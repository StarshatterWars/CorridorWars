using UnityEngine;
using System.Collections;

public class CeilingLights : MonoBehaviour {
	private RangerWars grGlobals;
	
	private Color colorStart = Color.cyan;
    private Color colorEnd = Color.blue;
	private float duration = 2.0f;
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
