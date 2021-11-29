using UnityEngine;
using System.Collections;

public class MoveShipMM : MonoBehaviour {
	public float shipSpeed = 10.0f;
	public GameObject target;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.transform);
			
		transform.position += Time.deltaTime * shipSpeed * transform.forward;
		if(shipSpeed <= 50.0f) shipSpeed += 1.0f;
	}
}
