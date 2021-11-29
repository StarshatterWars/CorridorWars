using UnityEngine;
using System.Collections;

public class csLights : MonoBehaviour {
	public float waitingTime = 5.15f;
	IEnumerator Start ()
	{
		while (true)
		{
			GetComponent<Light>().enabled = !(GetComponent<Light>().enabled); //toggle on/off the enabled property
			yield return new WaitForSeconds(waitingTime);
		}
	}
}
