using UnityEngine;
using System.Collections;

public class AS_StarTextures2 : MonoBehaviour {
    
   //scrolling maintexture+bump

    public float scrollX = 0.02f;
    public float scrollY = 0.02f;


 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    float changeX= scrollX * Time.time;
        float changeY= scrollY * Time.time;
     
        GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", new Vector2(changeX, changeY));
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(changeX, changeY));

	}
}
