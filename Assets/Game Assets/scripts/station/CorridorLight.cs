using UnityEngine;
using System.Collections;

public class CorridorLight : MonoBehaviour {
	private Color colorStart = Color.cyan;
    private Color colorEnd = Color.blue;
	private float duration = 2.0f;
	private float intensity = 2.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
        if(GetComponent<Light>() != null) GetComponent<Light>().color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
