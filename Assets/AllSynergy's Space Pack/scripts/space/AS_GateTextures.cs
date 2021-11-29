using UnityEngine;
using System.Collections;

public class AS_GateTextures : MonoBehaviour {
    
   //scrolling maintexture

    public float scrollX = 0.02f;
    public float scrollY = 0.02f;


 

	
	// Update is called once per frame
	void Update () {
	    float changeX= scrollX * Time.time;
        float changeY= scrollY * Time.time;
     
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(changeX, changeY));

	}
}
