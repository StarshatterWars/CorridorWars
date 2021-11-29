using UnityEngine;
using System.Collections;

public class AS_destroyThisAfterTime : MonoBehaviour
{

    public float destructionAfter = 3.0f;
    public bool detachChildrenNodes = true;

    public bool destroyAfterTime = true;        //keep this at true if you want to destroy after "destructionAfter" time...


	void Awake(){

        Invoke("DestroyThis", destructionAfter);    //  destroys itself after timeOut (default is 3)
	
	}
	
	
void DestroyThis ()
{
	if (detachChildrenNodes) {
		transform.DetachChildren ();
	}

    if (destroyAfterTime)
	DestroyObject (gameObject);

}


}



