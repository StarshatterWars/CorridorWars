using UnityEngine;
using System.Collections;

public class AS_MeteorStrike : MonoBehaviour {


    public Vector2 xSpeed = new Vector2(-40,40);
    public Vector2 ySpeed = new Vector2(-90, -70);
    public Vector2 zSpeed = new Vector2(-40, 40);
    public GameObject meteorExplosionPrefab;
    public Vector3 startPosition;

    Vector3 direction;

	// Use this for initialization
	void Start () {

        direction = new Vector3(Random.Range(xSpeed.x,xSpeed.y), Random.Range(ySpeed.x, ySpeed.y), Random.Range(zSpeed.x, zSpeed.y));
        startPosition = transform.position;

	}
	

	void Update () {

        transform.position += direction * Time.deltaTime;

	}


    void OnCollisionEnter(Collision collision)
    {

        Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
        startAgain();
     
       // Destroy(gameObject);
    }

  


    void startAgain()
    {
      
        transform.position = startPosition + new Vector3(Random.Range(-10,10), Random.Range(-10,10), Random.Range(-10,10));
        direction = new Vector3(Random.Range(xSpeed.x, xSpeed.y), Random.Range(ySpeed.x, ySpeed.y), Random.Range(zSpeed.x, zSpeed.y));

    }

  
}
