using UnityEngine;
using System.Collections;

public class csLoadingBar : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
