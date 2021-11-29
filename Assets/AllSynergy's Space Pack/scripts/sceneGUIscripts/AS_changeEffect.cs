using UnityEngine;
using System.Collections;

public class AS_changeEffect : MonoBehaviour {

    // just a list of effects 
    public GameObject TunnelVisionEffect1;  
    public GameObject TunnelVisionEffect2;
    public GameObject TunnelVisionEffect3;
    public GameObject TunnelVisionEffect4;
    public GameObject TunnelVisionEffect5;
    public GameObject TunnelVisionEffect6;
    public GameObject TunnelVisionEffect7;
  


    void update()
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


    }



    void OnGUI()
    {




        if (GUI.Button(new Rect(10, 10, 300, 20), "Effect 1"))
        {

       
            TunnelVisionEffect1.gameObject.SetActive(true);
            TunnelVisionEffect2.gameObject.SetActive(false);
            TunnelVisionEffect3.gameObject.SetActive(false);
            TunnelVisionEffect4.gameObject.SetActive(false);
            TunnelVisionEffect5.gameObject.SetActive(false);
            TunnelVisionEffect6.gameObject.SetActive(false);
            TunnelVisionEffect7.gameObject.SetActive(false);

        }


        if (GUI.Button(new Rect(320, 10, 300, 20), "Effect 2"))
        {

            TunnelVisionEffect1.gameObject.SetActive(false);
            TunnelVisionEffect2.gameObject.SetActive(true);
            TunnelVisionEffect3.gameObject.SetActive(false);
            TunnelVisionEffect4.gameObject.SetActive(false);
            TunnelVisionEffect5.gameObject.SetActive(false);
            TunnelVisionEffect6.gameObject.SetActive(false);
            TunnelVisionEffect7.gameObject.SetActive(false);

        }


        if (GUI.Button(new Rect(10, 50, 300, 20), "Effect 3"))
        {
            TunnelVisionEffect1.gameObject.SetActive(false);
            TunnelVisionEffect2.gameObject.SetActive(false);
            TunnelVisionEffect3.gameObject.SetActive(true);
            TunnelVisionEffect4.gameObject.SetActive(false);
            TunnelVisionEffect5.gameObject.SetActive(false);
            TunnelVisionEffect6.gameObject.SetActive(false);
            TunnelVisionEffect7.gameObject.SetActive(false);

        }


        if (GUI.Button(new Rect(320, 50, 300, 20), "Effect 4"))
        {
            TunnelVisionEffect1.gameObject.SetActive(false);
            TunnelVisionEffect2.gameObject.SetActive(false);
            TunnelVisionEffect3.gameObject.SetActive(false);
            TunnelVisionEffect4.gameObject.SetActive(true);
            TunnelVisionEffect5.gameObject.SetActive(false);
            TunnelVisionEffect6.gameObject.SetActive(false);
            TunnelVisionEffect7.gameObject.SetActive(false);

        }


        if (GUI.Button(new Rect(10, 90, 300, 20), "Effect 5"))
        {
            TunnelVisionEffect1.gameObject.SetActive(false);
            TunnelVisionEffect2.gameObject.SetActive(false);
            TunnelVisionEffect3.gameObject.SetActive(false);
            TunnelVisionEffect4.gameObject.SetActive(false);
            TunnelVisionEffect5.gameObject.SetActive(true);
            TunnelVisionEffect6.gameObject.SetActive(false);
            TunnelVisionEffect7.gameObject.SetActive(false);

        }


        if (GUI.Button(new Rect(320, 90, 300, 20), "Effect 6"))
        {

            TunnelVisionEffect1.gameObject.SetActive(false);
            TunnelVisionEffect2.gameObject.SetActive(false);
            TunnelVisionEffect3.gameObject.SetActive(false);
            TunnelVisionEffect4.gameObject.SetActive(false);
            TunnelVisionEffect5.gameObject.SetActive(false);
            TunnelVisionEffect6.gameObject.SetActive(true);
            TunnelVisionEffect7.gameObject.SetActive(false);

        }

        if (GUI.Button(new Rect(10, 130, 300, 20), "Effect 7"))
        {
            TunnelVisionEffect1.gameObject.SetActive(false);
            TunnelVisionEffect2.gameObject.SetActive(false);
            TunnelVisionEffect3.gameObject.SetActive(false);
            TunnelVisionEffect4.gameObject.SetActive(false);
            TunnelVisionEffect5.gameObject.SetActive(false);
            TunnelVisionEffect6.gameObject.SetActive(false);
            TunnelVisionEffect7.gameObject.SetActive(true);

        }

    }




}
