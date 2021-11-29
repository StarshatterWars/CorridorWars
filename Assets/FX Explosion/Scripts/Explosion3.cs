using UnityEngine;
using System.Collections;

public class Explosion3 : MonoBehaviour
{
    private string FxName;
	public float expTime = 2.0f;
   
	public void Awake()
    {
        name = "FxExplo" + Time.frameCount;
        FxName = this.name;
    }

    public void Update()
    {
		GameObject.Find(this.FxName + "/ExploLight").GetComponent<Light>().range -= 6.5f * Time.deltaTime;
		Destroy(this.gameObject, expTime);
    }
}

