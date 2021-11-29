using UnityEngine;
using System.Collections;

public class csMenuRotate : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f, Space.Self);
	}
}
