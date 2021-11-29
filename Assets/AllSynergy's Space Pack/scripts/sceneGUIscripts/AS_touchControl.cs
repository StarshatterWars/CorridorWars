using UnityEngine;
using System.Collections;

public class AS_touchControl : MonoBehaviour {


	void Update ()
    {

#if UNITY_IPHONE || UNITY_ANDROID
      Debug.Log("Iphone or Android");

        RaycastHit hit = new RaycastHit();

        for (int i = 0; i < Input.touchCount; ++i)
        {

            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {

                //if (Input.GetTouch(i).phase.Equals(TouchPhase.Stationary)) {  
                // Construct a ray from the current touch coordinates

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit))
                {

                    hit.transform.gameObject.SendMessage("OnMouseUp");

                }

            }


        }

      
#endif


    }//update
}
