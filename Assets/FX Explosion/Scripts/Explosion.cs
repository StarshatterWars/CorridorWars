using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private string FxName;

    public void Awake()
    {
        name = "FxExplo" + Time.frameCount;
        FxName = this.name;
    }

    public void Main()
    {
    }

    public void Update()
    {
        GameObject.Find(this.FxName + "/ExploLight").GetComponent<Light>().range -= 6.5f * Time.deltaTime;
        Destroy(this.gameObject, (float) 5);
    }
}

