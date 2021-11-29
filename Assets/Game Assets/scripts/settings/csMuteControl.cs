using UnityEngine;
using System.Collections;

public class csMuteControl : MonoBehaviour {

	void OnClick()
	{
		if( (enabled) && AudioListener.volume != 1 )
		AudioListener.volume= 1;

		else
			AudioListener.volume= 0;
	}
}
