using UnityEngine;
using System.Collections;

public class AS_basicSceneKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown("left alt"))
        {
            Application.LoadLevel(0);   // back to mainmenu
        }
  
   // JUST FOR QUICK TESTING
#if UNITY_IPHONE || UNITY_ANDROID
      Debug.Log("Iphone or Android");

        //RaycastHit hit = new RaycastHit();

       // for (int i = 0; i < Input.touchCount; ++i)
        if ( Input.touchCount > 1 )
        {

            Application.LoadLevel(0);   // back to mainmenu


        }

      
#endif
        



	}
}
