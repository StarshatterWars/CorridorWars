using UnityEngine;
using System.Collections;

public class AS_mItem : MonoBehaviour
{

    void Start() { Cursor.visible = true;  }

    void OnMouseEnter()
    {

        GetComponent<Renderer>().material.color = Color.red;



    }


    void OnMouseExit()
    {

        GetComponent<Renderer>().material.color = Color.white;



    }



    void OnMouseUp()
    {

        if (gameObject.tag == "MenuTextQuit")
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
        else if (gameObject.tag == "MenuTextSpace0")
        {
    
            Application.LoadLevel(2);
        }
        else if (gameObject.tag == "MenuTextSpace1")
        {
          
            Application.LoadLevel(3);
        }
        else if (gameObject.tag == "MenuTextSpace2")
        {
       
            Application.LoadLevel(4);
        }
        else if (gameObject.tag == "MenuTextSpace3")
        {
        
            Application.LoadLevel(5);
        }

        else if (gameObject.tag == "MenuTextSpace4")
        {

            Application.LoadLevel(6);
        }


        else if (gameObject.tag == "MenuTextSpace5")
        {
         
            Application.LoadLevel(7);
        }

        else if (gameObject.tag == "MenuTextSpace6")
        {

            Application.LoadLevel(8);
        }

        else if (gameObject.tag == "MenuTextSpace7")
        {

            Application.LoadLevel(9);
        }

        else if (gameObject.tag == "MenuTextSpace8")
        {

            Application.LoadLevel(10);
        }

        else if (gameObject.tag == "MenuTextSpace9")
        {

            Application.LoadLevel(11);
        }
        else if (gameObject.tag == "MenuTextSpace10")
        {

            Application.LoadLevel(12);
        }
        else if (gameObject.tag == "MenuTextSpace11")
        {

            Application.LoadLevel(13);
        }
        else if (gameObject.tag == "MenuTextSpace12")
        {

            Application.LoadLevel(14);
        }

        else if (gameObject.tag == "MenuTextSpace13")
        {

            Application.LoadLevel(15);
        }

        else if (gameObject.tag == "MenuTextSpace14")
        {

            Application.LoadLevel(16);
        }
        else if (gameObject.tag == "MenuTextSpace15")
        {

            Application.LoadLevel(17);
        }
            /////////////////////////////////////
        else if (gameObject.tag == "MenuTextInfo")
        {
            Debug.Log("Loading Info scene");
            Application.LoadLevel(1);
        }


    }


}
