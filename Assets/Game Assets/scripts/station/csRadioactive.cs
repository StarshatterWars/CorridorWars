using UnityEngine;
using System.Collections;

public class csRadioactive : MonoBehaviour {
	private Color colorStart = new Color(0.0f, 1.0f, 0.5f, 1.0f);
    private Color colorEnd = Color.green;
	private float duration = 1.0f;
	private float intensity = 2.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
         GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
