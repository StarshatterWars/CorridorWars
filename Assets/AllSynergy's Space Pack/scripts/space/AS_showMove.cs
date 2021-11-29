using UnityEngine;
using System.Collections;

public class AS_showMove : MonoBehaviour
{

    public float xStop1 = -100;
    public float xStop2 = 100;
    public float speed = 25;
    private bool turn = false;
	

    void Start()
    {
    // transform.position = new Vector3(0,0,0);
    }

	// Update is called once per frame
    void Update()
    {

     //   Debug.Log("X = " + transform.position.x.ToString() + " turn = " + turn.ToString());

        if (turn == false)
        {
           

            if (transform.position.x < xStop2)
                transform.position += transform.right*Time.deltaTime*speed;
            
            if (transform.position.x >= xStop2)
            {
         
                turn = true;
            }
        }


        else
        {

            if (transform.position.x > xStop1)
                transform.position += -transform.right * Time.deltaTime * speed;
            else
            {
                turn = false;
            }

        }


    }

}
