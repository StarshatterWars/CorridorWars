using UnityEngine;
using System.Collections;

public class DangerBar : MonoBehaviour {
	private Color colorStart = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color colorEnd = new Color(0.0f, 0.0f, 0.0f, 1.0f);
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
