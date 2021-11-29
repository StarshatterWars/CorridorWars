using UnityEngine;
using System.Collections;

public class scroll_UVs_spaceRightToLeft : MonoBehaviour
{


    public float ScrollingSpeed = 0.1f;
	
	void Update ()
	{


        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(ScrollingSpeed * Time.deltaTime, 0);
    
	}


}
