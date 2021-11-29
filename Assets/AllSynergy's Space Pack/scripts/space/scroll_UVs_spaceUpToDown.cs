using UnityEngine;
using System.Collections;

public class scroll_UVs_spaceUpToDown : MonoBehaviour
{


    public float ScrollingSpeed = 0.4f;
	
	void Update ()
	{


        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, ScrollingSpeed * Time.deltaTime);
    
	}


}
