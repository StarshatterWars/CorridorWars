using UnityEngine;
using System.Collections;

public class AS_StarTextures : MonoBehaviour {

   //scrolling maintexture+bump

    public float scrollX = 0.02f;
    public float scrollY = 0.02f;
    public float scrollX2 = 0.02f;
    public float scrollY2 = 0.02f;

 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    float changeX= scrollX * Time.time;
        float changeY= scrollY * Time.time;
        float changeX2= scrollX2 * Time.time;
        float changeY2= scrollY2 * Time.time;
        GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", new Vector2(changeX, changeY));
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(changeX, changeY));
        GetComponent<Renderer>().materials[1].SetTextureOffset("_MainTex", new Vector2(changeX2, changeY2));
        GetComponent<Renderer>().materials[1].SetTextureOffset("_BumpMap", new Vector2(changeX2, changeY2));
	}
}
