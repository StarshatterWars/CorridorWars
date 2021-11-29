using UnityEngine;
using System.Collections;

public class AS_rotate : MonoBehaviour
{

   
    public float XRotatingSpeed = 0;
    public float YRotatingSpeed = 0;
    public float ZRotatingSpeed = 0;


	// Update is called once per frame
	void Update () {
	
        transform.Rotate(XRotatingSpeed * Time.deltaTime, YRotatingSpeed * Time.deltaTime ,ZRotatingSpeed * Time.deltaTime, Space.Self);

	}
}
