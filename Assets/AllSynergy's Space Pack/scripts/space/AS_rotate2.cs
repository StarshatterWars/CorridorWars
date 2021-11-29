using UnityEngine;
using System.Collections;

public class AS_rotate2 : MonoBehaviour {

    public float rotationSpeed = 22;

    public int chooseRotation = 1;


	void Update () {
	
        if (chooseRotation == 0)
    transform.Rotate(0,rotationSpeed*Time.deltaTime,0);

        else if (chooseRotation == 1)
    transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);

        else if (chooseRotation == 2)
    transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
	}
}
